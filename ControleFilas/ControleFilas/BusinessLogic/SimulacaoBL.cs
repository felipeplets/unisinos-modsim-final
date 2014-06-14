using ControleFilas.Library;
using ControleFilas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFilas.BusinessLogic
{
    public partial class Simulacao
    {
        public List<Elemento> _listElementos;
        private List<Servidor> _servidor;
        private Fila _fila;
        private float _tempomMedioTotal;
        private float _tempoMedioFila;

        public void Simular(int numeroElementos, int numeroServidores)
        {
            int servidores = numeroServidores;  // número de servidores
            int elementos = numeroElementos;    // número de elementos
            float tmt = 0;                      // tempo médio total
            float tmf = 0;                      // tempo médio gasto na fila

            float[,] tabela = new float[elementos, 6];
            _listElementos = new List<Elemento>();
            _servidor = new List<Servidor>();

            // Criando os servidores;
            for (int i = 1; i <= servidores; i++)
                _servidor.Add(new Servidor { Indice = i  });

            // Informar os tempos utilizados para o calculo
            for (int n = 0; n < elementos; n++)
            {
                Elemento elemento = new Elemento();
                float sum = 0.00F;
                if (n - 1 != -1)
                    sum += tabela[n - 1, 0];

                System.Random randomChegada = new System.Random(n + 1);
                int nextRandomChegada = randomChegada.Next(1, 1000);
                tabela[n, 0] = sum + new RandomNumbers(nextRandomChegada).NextDouble();
                elemento.InstanteChegada = sum + new RandomNumbers(nextRandomChegada).NextDouble();


                System.Random randomAtendimento = new System.Random(n + 1);
                int nextRandomAtendimento = randomAtendimento.Next(1, 1000);
                tabela[n, 1] = new RandomNumbers(nextRandomAtendimento).NextDouble();
                elemento.TempoAtendimento = new RandomNumbers(nextRandomAtendimento).NextDouble();
                _listElementos.Add(elemento);
            }
            
            // Inserindo os elementos na Fila
            _fila = new Fila { Elementos = _listElementos.OrderBy(k => k.InstanteChegada).ToList() };


            // Inserindo os primeiros elementos da fila em cada servidor
            for (int i = 0; i < _fila.Elementos.Count; i++)
            {
                if (i <= (servidores - 1))
                {
                    Elemento elemento = _fila.Elementos[i];
                    elemento.EntradaAtendimento = elemento.InstanteChegada;
                    elemento.SaidaAtendimento = elemento.TempoAtendimento + elemento.InstanteChegada;
                    elemento.TempoFila = elemento.EntradaAtendimento - elemento.InstanteChegada;
                    elemento.TempoTotal = elemento.TempoAtendimento + elemento.TempoFila;
                    elemento.Indice = 1;
                    _servidor[i].Elementos.Add(_fila.Elementos[i]);
                }
            }

           
            // Inserindo outros elementos nas filas
            for (int i = 0; i < _fila.Elementos.Count; i++)
            {
                if (i > (servidores - 1))
                {
                    List<Servidor> statusServidor = _servidor
                        .Where(k => k.Elementos.Any(j => j.SaidaAtendimento > _fila.Elementos[i].InstanteChegada))
                        .ToList();

                    // Caso o status servidor tenha varios itens, mas eles nao
                    // superem o total de servidor, então há vaga em algum servidor
                    if (statusServidor.Count() < numeroServidores)
                    {
                        // Inserir tempo entrada para o serviço 
                        // Inserir tempo de saída do serviço
                        // Inserir tempo Gasto na fila = 0
                        // Inserir tempo Total na Fila

                        // Todos os servidores livres
                        if (statusServidor.Count() == 0)
                        {
                            Elemento elementoServidor = _servidor[0].Elementos.OrderByDescending(k => k.Indice).FirstOrDefault();

                            Elemento elemento = _fila.Elementos[i];
                            elemento.Indice = elementoServidor.Indice + 1;
                            elemento.EntradaAtendimento = elemento.InstanteChegada;
                            elemento.SaidaAtendimento = elemento.TempoAtendimento + elemento.InstanteChegada;
                            elemento.TempoFila = 0;
                            elemento.TempoTotal = elemento.TempoAtendimento + elemento.TempoFila;
                            _servidor[0].Elementos.Add(_fila.Elementos[i]);
                        }
                        else
                        {
                            Servidor servidor = _servidor.FirstOrDefault(k => !statusServidor.Any(j => j.Indice == k.Indice) );
                            Elemento elementoServidor = servidor.Elementos.OrderByDescending(k => k.Indice).FirstOrDefault();

                            Elemento elemento = _fila.Elementos[i];
                            elemento.Indice = elementoServidor.Indice + 1;
                            elemento.EntradaAtendimento = elemento.InstanteChegada;
                            elemento.SaidaAtendimento = elemento.TempoAtendimento + elemento.InstanteChegada;
                            elemento.TempoFila = 0;
                            elemento.TempoTotal = elemento.TempoAtendimento + elemento.TempoFila;
                            _servidor[servidor.Indice - 1].Elementos.Add(_fila.Elementos[i]);
                        }
                    }
                    else
                    {
                        // Não existe vagas no momento, o elemento vai para a fila
                        Servidor servidor = statusServidor.FirstOrDefault();
                        Elemento elementoServidor = servidor.Elementos.OrderByDescending(k => k.Indice).FirstOrDefault();

                        Elemento elemento = _fila.Elementos[i];
                        elemento.Indice = elementoServidor.Indice + 1;
                        elemento.EntradaAtendimento = elementoServidor.SaidaAtendimento;
                        elemento.SaidaAtendimento = elemento.TempoAtendimento + elementoServidor.SaidaAtendimento;
                        elemento.TempoFila = elementoServidor.SaidaAtendimento - elemento.InstanteChegada;
                        elemento.TempoTotal = elemento.TempoAtendimento + elemento.TempoFila;
                        _servidor[servidor.Indice - 1].Elementos.Add(_fila.Elementos[i]);
                    }
                }
            }


            #region Apenas para 1 servidor

            // Calculo do Tempo do Primeiro Elemento da Fila 
            tabela[0, 2] = tabela[0, 0];                    //Tempo de Entrada para o Serviço 
            tabela[0, 3] = tabela[0, 1] + tabela[0, 0];     //Tempo de Saída do Serviço
            tabela[0, 4] = tabela[0, 2] - tabela[0, 0];     //Tempo Gasto na fila
            tabela[0, 5] = tabela[0, 1] - tabela[0, 4];     //Tempo Total na Fila

            // Calculo dos demais tempos da fila
            for (int p = 1; p < elementos; p++)
            {
                // se Tempo de Chegada(TC) < Tempo Saída Serviço (TS) (anterior) Então TE = TS 
                //ou Se Tempo de Chegada > Tempo Saída Serviço(anterior) Então TE = TC

                if (tabela[p, 0] < tabela[(p - 1), 3])
                {
                    tabela[p, 2] = tabela[(p - 1), 3];
                }
                else if (tabela[p, 0] > tabela[(p - 1), 3])
                {
                    tabela[p, 2] = tabela[p, 0];
                }

                tabela[p, 3] = tabela[p, 1] + tabela[p, 2];

                if (tabela[p, 0] < tabela[(p - 1), 3])
                {
                    tabela[p, 4] = tabela[p, 2] - tabela[p, 0];
                }
                else
                {
                    tabela[p, 4] = 0;
                }

                tabela[p, 5] = tabela[p, 1] + tabela[p, 4];
            }

            Console.Write("TC             ");//Tempo de Chegada
            Console.Write("TA             ");//Tempo de Atendimento
            Console.Write("TE             ");//Tempo de Entrada para o Serviço 
            Console.Write("TS             ");//Tempo de Saída do Serviço
            Console.Write("TF             ");//Tempo Gasto na fila
            Console.Write("TT             ");//Tempo Total na Fila
            Console.WriteLine();

            for (int i = 0; i < elementos; i++)
            {
                tmt += tabela[i, 5];
                tmf += tabela[i, 4];

                Console.Write(tabela[i, 0].ToString("#,##0.0") + "          ");
                Console.Write(tabela[i, 1].ToString("#,##0.0") + "          ");
                Console.Write(tabela[i, 2].ToString("#,##0.0") + "          ");
                Console.Write(tabela[i, 3].ToString("#,##0.0") + "          ");
                Console.Write(tabela[i, 4].ToString("#,##0.0") + "          ");
                Console.Write(tabela[i, 5].ToString("#,##0.0") + "          ");
                Console.WriteLine();
            }
            tmt = tmt / elementos;
            tmf = tmf / elementos;

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("O Tempo Médio Total é: " + tmt.ToString("#,##0.0") + " minutos");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("O Tempo Médio Gasto na Fila é: " + tmf.ToString("#,##0.0") + " minutos");

            #endregion
        }

        public void Atendimento(Elemento elemento, List<Servidor> servidores, int indiceServidor)
        {
            Servidor servidor = servidores.FirstOrDefault(k => k.Indice == indiceServidor);
            servidor.Elementos.Add(elemento);
        }
    }


}

﻿using ControleFilas.Enumerator;
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
        public List<Elemento> _listElementosTemp;
        private List<Servidor> _servidor;
        private Fila _fila;

        public List<Elemento> Simular(
            int numberElements, 
            int numberServers, 
            TypeDistribution distributionArrive,
            TypeDistribution distributionService, 
            TypeService typeService)
        {
            int servidores = numberServers;  // número de servidores
            int elementos = numberElements;    // número de elementos
            double tmt = 0;                      // tempo médio total
            double tmf = 0;                      // tempo médio gasto na fila

            double[,] tabela = new double[elementos, 6];
            _listElementos = new List<Elemento>();
            _servidor = new List<Servidor>();
            _listElementosTemp = new List<Elemento>();

            #region Criando os Servidores
            for (int i = 1; i <= servidores; i++)
                _servidor.Add(new Servidor { Indice = i });
            #endregion

            #region Informar os tempos utilizados para o calculo
            double instanteChegadaAnterior = 0d;
            for (int n = 0; n < elementos; n++)
            {
                Elemento elemento = new Elemento();
                RandomNumbersDistribuitions random = new RandomNumbersDistribuitions(distributionArrive, typeService, TypeMoment.ArrivalTime);
                double numberChegada = random.NextDouble();
                
                elemento.InstanteChegada = instanteChegadaAnterior + numberChegada;
                instanteChegadaAnterior = instanteChegadaAnterior + numberChegada;

                RandomNumbersDistribuitions randomService = new RandomNumbersDistribuitions(distributionService, typeService, TypeMoment.ServiceTime);
                double numberAtendimento = randomService.NextDouble();
                tabela[n, 1] = numberAtendimento;
                elemento.TempoAtendimento = numberAtendimento;
                _listElementos.Add(elemento);
                System.Threading.Thread.Sleep(300);
                
            }
            #endregion

            // Inserindo os elementos na Fila
            _fila = new Fila { Elementos = _listElementos.OrderBy(k => k.InstanteChegada).ToList() };

            #region Inserindo os primeiros elementos da fila em cada servidor
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
                    CriarElementoTemp(elemento);
                }
            }
            #endregion

            #region Inserindo outros elementos nas filas
            for (int i = 0; i < _fila.Elementos.Count; i++)
            {
                if (i > (servidores - 1))
                {
                    List<Servidor> statusServidor = _servidor
                        .Where(k => k.Elementos.Any(j => j.SaidaAtendimento > _fila.Elementos[i].InstanteChegada))
                        .ToList();

                    // Caso o status servidor tenha varios itens, mas eles nao
                    // superem o total de servidor, então há vaga em algum servidor
                    if (statusServidor.Count() < numberServers)
                    {
                        // Inserir tempo entrada para o serviço 
                        // Inserir tempo de saída do serviço
                        // Inserir tempo Gasto na fila = 0
                        // Inserir tempo Total na Fila

                        // Todos os servidores livres
                        if (statusServidor.Count() == 0)
                        {
                            Elemento elementoServidor = _servidor[0].Elementos.OrderByDescending(k => k.Indice).FirstOrDefault();
                            Atendimento(i, new Servidor(), elementoServidor, false);

                        }
                        else
                        {
                            Servidor servidor = _servidor.FirstOrDefault(k => !statusServidor.Any(j => j.Indice == k.Indice));
                            Elemento elementoServidor = servidor.Elementos.OrderByDescending(k => k.Indice).FirstOrDefault();
                            Atendimento(i, servidor, elementoServidor, false);
                        }
                    }
                    else
                    {
                        // Não existe vagas no momento, o elemento vai para a fila
                        Servidor servidor = statusServidor.FirstOrDefault();
                        Elemento elementoServidor = servidor.Elementos.OrderByDescending(k => k.Indice).FirstOrDefault();

                        Atendimento(i, servidor, elementoServidor, true);
                    }
                }
            }
            #endregion

            #region Exibindo os dados no Console

            //Console.Write("TC             ");//Tempo de Chegada
            //Console.Write("TA             ");//Tempo de Atendimento
            //Console.Write("TE             ");//Tempo de Entrada para o Serviço 
            //Console.Write("TS             ");//Tempo de Saída do Serviço
            //Console.Write("TF             ");//Tempo Gasto na fila
            //Console.Write("TT             ");//Tempo Total no sistema
            //Console.WriteLine();

            //for (int i = 0; i < _listElementosTemp.Count; i++)
            //{

            //    tmt += _listElementosTemp[i].TempoTotal;
            //    tmf += _listElementosTemp[i].TempoFila;

            //    Console.Write(_listElementosTemp[i].InstanteChegada.ToString("#,##0.0") + "          ");
            //    Console.Write(_listElementosTemp[i].TempoAtendimento.ToString("#,##0.0") + "          ");
            //    Console.Write(_listElementosTemp[i].EntradaAtendimento.ToString("#,##0.0") + "          ");
            //    Console.Write(_listElementosTemp[i].SaidaAtendimento.ToString("#,##0.0") + "          ");
            //    Console.Write(_listElementosTemp[i].TempoFila.ToString("#,##0.0") + "          ");
            //    Console.Write(_listElementosTemp[i].TempoTotal.ToString("#,##0.0") + "          ");
            //    Console.WriteLine();
            //}
            //tmt = tmt / elementos;
            //tmf = tmf / elementos;

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("O Tempo Médio Total é: " + tmt.ToString("#,##0.00") + " minutos");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("O Tempo Médio Gasto na Fila é: " + tmf.ToString("#,##0.00") + " minutos");

            return _listElementosTemp;

            #endregion
        }

        private void Atendimento(int i, Servidor servidor, Elemento elementoServidor, bool ocupado)
        {
            Elemento elemento = _fila.Elementos[i];
            elemento.Indice = elementoServidor.Indice + 1;

            if (!ocupado)
            {
                elemento.EntradaAtendimento = elemento.InstanteChegada;
                elemento.SaidaAtendimento = elemento.TempoAtendimento + elemento.InstanteChegada;
                elemento.TempoFila = 0;
                elemento.TempoTotal = elemento.TempoAtendimento + elemento.TempoFila;

                if (servidor.Indice > 0)
                    _servidor[servidor.Indice - 1].Elementos.Add(_fila.Elementos[i]);
                else
                    _servidor[0].Elementos.Add(_fila.Elementos[i]);
            }
            else
            {
                elemento.EntradaAtendimento = elementoServidor.SaidaAtendimento;
                elemento.SaidaAtendimento = elemento.TempoAtendimento + elementoServidor.SaidaAtendimento;
                elemento.TempoFila = elementoServidor.SaidaAtendimento - elemento.InstanteChegada;
                elemento.TempoTotal = elemento.TempoAtendimento + elemento.TempoFila;
                _servidor[servidor.Indice - 1].Elementos.Add(_fila.Elementos[i]);
            }

            CriarElementoTemp(elemento);
        }

        private void CriarElementoTemp(Elemento elemento)
        {
            Elemento elementoTemp = new Elemento();
            elementoTemp.InstanteChegada = elemento.InstanteChegada;
            elementoTemp.TempoAtendimento = elemento.TempoAtendimento;
            elementoTemp.EntradaAtendimento = elemento.EntradaAtendimento;
            elementoTemp.SaidaAtendimento = elemento.SaidaAtendimento;
            elementoTemp.TempoFila = elemento.TempoFila;
            elementoTemp.TempoTotal = elemento.TempoTotal;
            elementoTemp.Indice = _listElementosTemp.Count + 1;

            _listElementosTemp.Add(elementoTemp);
        }
    }
}

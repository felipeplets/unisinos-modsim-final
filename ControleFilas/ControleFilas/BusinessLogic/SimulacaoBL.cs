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
        public static void Simular(int nrElementos)
        {
            //float fTempoMedioTotal = 0;     // tempo médio total
            //float fTempoMedioFila = 0;     // tempo médio gasto na fila

            //float[,] tabela = new float[nrElementos, 6];

            ////taxas [n, 0] = Chegada
            ////taxas [n, 1] = Atendimento
            ////float[,] taxas = new float[nrElementos, 2];

            //for (int n = 0; n < nrElementos; n++)
            //{
            //    float sum = 0.00F;

            //for (int s = 0; s < n; s++)
            //if (n - 1 != -1)
            //    sum += tabela[n - 1, 0];

            //System.Random randomChegada = new System.Random(n + 1);
            //int nextRandomChegada = randomChegada.Next(1, 1000);
            //tabela[n, 0] = sum + new RandomNumbers(nextRandomChegada).NextDouble();

            //System.Random randomAtendimento = new System.Random(n + 1);
            //int nextRandomAtendimento = randomAtendimento.Next(1, 1000);
            //tabela[n, 1] = new RandomNumbers(nextRandomAtendimento).NextDouble();
            //}

            //// Calculo do Tempo do Primeiro Elemento da Fila 
            //tabela[0, 2] = tabela[0, 0];
            //tabela[0, 3] = tabela[0, 1] + tabela[0, 0];
            //tabela[0, 4] = tabela[0, 2] - tabela[0, 0];
            //tabela[0, 5] = tabela[0, 1] - tabela[0, 4];

            //// Calculo dos demais tempos da fila
            //for (int p = 1; p < nrElementos; p++)
            //{
            //    // se Tempo de Chegada(TC) < Tempo Saída Serviço (TS) (anterior) Então TE = TS 
            //    //ou Se Tempo de Chegada > Tempo Saída Serviço(anterior) Então TE = TC
            //    if (tabela[p, 0] < tabela[(p - 1), 3])
            //    {
            //        tabela[p, 2] = tabela[(p - 1), 3];
            //    }
            //    else if (tabela[p, 0] > tabela[(p - 1), 3])
            //    {
            //        tabela[p, 2] = tabela[p, 0];
            //    }

            //    tabela[p, 3] = tabela[p, 1] + tabela[p, 2];

            //    if (tabela[p, 0] < tabela[(p - 1), 3])
            //    {
            //        tabela[p, 4] = tabela[p, 2] - tabela[p, 0];
            //    }
            //    else
            //    {
            //        tabela[p, 4] = 0;
            //    }

            //    tabela[p, 5] = tabela[p, 1] + tabela[p, 4];
            //}


            //Console.Write("TC             "); //Tempo de Chegada
            //Console.Write("TA             ");//Tempo de Atendimento
            //Console.Write("TE             ");//Tempo de Entrada para o Serviço 
            //Console.Write("TS             ");//Tempo de Saída do Serviço
            //Console.Write("TF             ");//Tempo Gasto na fila
            //Console.Write("TT             ");//Tempo Total na Fila
            //Console.WriteLine();

            //for (int i = 0; i < nrElementos; i++)
            //{
            //    fTempoMedioTotal += tabela[i, 5];
            //    fTempoMedioFila  += tabela[i, 4];

            //    Console.Write(tabela[i, 0].ToString("#,##0.0") + "          ");
            //    Console.Write(tabela[i, 1].ToString("#,##0.0") + "          ");
            //    Console.Write(tabela[i, 2].ToString("#,##0.0") + "          ");
            //    Console.Write(tabela[i, 3].ToString("#,##0.0") + "          ");
            //    Console.Write(tabela[i, 4].ToString("#,##0.0") + "          ");
            //    Console.Write(tabela[i, 5].ToString("#,##0.0") + "          ");
            //    Console.WriteLine();

            //}

            //fTempoMedioTotal = fTempoMedioTotal / nrElementos;
            //fTempoMedioFila = fTempoMedioFila / nrElementos;

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.Write("O Tempo Médio Total é: " + fTempoMedioTotal.ToString("#,##0.0") + " minutos");
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.Write("O Tempo Médio Gasto na Fila é: " + fTempoMedioFila.ToString("#,##0.0") + " minutos");

            //Console.ReadKey();

            int elementos = 30; // número de elementos
            float tmt = 0;     // tempo médio total
            float tmf = 0;     //  tempo médio gasto na fila

            float[,] tabela = new float[elementos, 6];

            // Informar os tempos utilizados para o calculo
            for (int n = 0; n < elementos; n++)
            {
                float sum = 0.00F;

                //for (int s = 0; s < n; s++)
                if (n - 1 != -1)
                    sum += tabela[n - 1, 0];

                System.Random randomChegada = new System.Random(n + 1);
                int nextRandomChegada = randomChegada.Next(1, 1000);
                tabela[n, 0] = sum + new RandomNumbers(nextRandomChegada).NextDouble();

                System.Random randomAtendimento = new System.Random(n + 1);
                int nextRandomAtendimento = randomAtendimento.Next(1, 1000);
                tabela[n, 1] = new RandomNumbers(nextRandomAtendimento).NextDouble();
            }
            
            // Calculo do Tempo do Primeiro Elemento da Fila 
            tabela[0, 2] = tabela[0, 0];
            tabela[0, 3] = tabela[0, 1] + tabela[0, 0];
            tabela[0, 4] = tabela[0, 2] - tabela[0, 0];
            tabela[0, 5] = tabela[0, 1] - tabela[0, 4];

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
        }
    }
}

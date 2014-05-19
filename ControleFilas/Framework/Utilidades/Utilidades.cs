using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web;

namespace Comum.Framework
{
    public class Utilidades
    {
        #region Arquivos

        /// <summary>
        /// verifica se o arquivo selecionado é válido
        /// </summary>
        /// <returns>Retorna vazio se o arquivo é válido e mensagem de erro se não for.</returns>
        public static string VerificarArquivoSelecionado(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            //bool sucesso = true;

            // verifica se algum arquivo foi selecionado
            if (string.IsNullOrEmpty(fileName))
            {
                sb.Append("Selecione um arquivo.<br />");
            }
            else
            {
                // verifica se o arquivo selecionado existe
                if (!File.Exists(fileName))
                {
                    sb.Append("Arquivo não encontrado.");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gera um nome único para utilizar em arquivos temporários, baseado no ID da sessão e no imestamp atual.
        /// </summary>
        /// <param name="extensao">Extensão que se deseja gerar o arquivo.</param>
        /// <returns>Nome de arquivo </returns>
        public static string GeraNomeArquivoTemporario(string extensao)
        {
            if (string.IsNullOrEmpty(extensao))
                extensao = "txt";
            return HttpContext.Current.Session.SessionID + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extensao;
        }

        /// <summary>
        /// Gera um nome único para utilizar em arquivos temporários, baseado no ID da sessão e no imestamp atual.
        /// </summary>
        /// <returns>Nome de arquivo </returns>
        public static string GeraNomeArquivoTemporario()
        {
            return GeraNomeArquivoTemporario(null);
        }
        



        #endregion

        #region Controles (manipulação)
        
        /// <summary>
        /// Busca um controle recursivamente. Para controles aninhados.
        /// </summary>
        /// <param name="ContainerCtl">De preferencia o controle mais abaixo na hierarquia. POr exemplo, não escolha a Master Page se conhecer um painel específico onde o controle buscado possa estar.</param>
        /// <param name="IdToFind">ID do controle buscado</param>
        /// <returns>O controle encontrado, ou null se não encontrar nada</returns>
        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;
            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }
            return null;
        }

        #endregion

        #region CSS_Dinamico

        /// <summary>
        /// Monta Dinamicamente os CSS utilizados nos GridsView.
        /// </summary>
        /// <returns>String com CSS styles</returns>
        public static string DynamicCSS(string sTemplate)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/* teste CSS Dynamic para template --> {0}*/ \" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadPanelBar_{0} .rpRootGroup,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadPanelBar_{0} .rpRootGroup .rpLink\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\"{{\" + " + Environment.NewLine);
            builder.AppendFormat("\"border: none !important;\" + " + Environment.NewLine);
            builder.AppendFormat("\"color: #5F5F5F;\" + " + Environment.NewLine);
            builder.AppendFormat("\"text-decoration: none;\" + " + Environment.NewLine);
            builder.AppendFormat("\"border-bottom-width: 0px !important;\" + " + Environment.NewLine);
            builder.AppendFormat("\"}}\" + " + Environment.NewLine);
            builder.AppendFormat("\".RadPanelBar_{0} .rpOut\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\"{{\" + " + Environment.NewLine);
            builder.AppendFormat("\"border-bottom-width: 0px !important;\" + " + Environment.NewLine);
            builder.AppendFormat("\"}}\" + " + Environment.NewLine);
            builder.AppendFormat("\".RadGrid_{0} .rgAltRow\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\"{{\" + " + Environment.NewLine);
            builder.AppendFormat("\"background:#dae2e8;\" + " + Environment.NewLine);
            builder.AppendFormat("\"}}\" + " + Environment.NewLine);
            builder.AppendFormat("\"/* GRID - Fontes */\" + " + Environment.NewLine);
            builder.AppendFormat("\".RadGrid_{0} .rgRow td,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadGrid_{0} .rgAltRow td,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadGrid_{0} .rgEditRow td,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadGrid_{0} .rgFooter td,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadGrid_{0} .rgFilterRow td,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadGrid_{0} .rgHeader,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadGrid_{0} .rgResizeCol,\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\".RadGrid_{0} .rgGroupHeader td\" + " + Environment.NewLine, sTemplate);
            builder.AppendFormat("\"{{\" + " + Environment.NewLine);
            builder.AppendFormat("\"font: normal 9px Tahoma, Arial, sans-serif;\" + " + Environment.NewLine);
            builder.AppendFormat("\"}}");
            return builder.ToString();
        }
        #endregion

        #region Datas

        /// <summary>
        /// Retorna a diferença em meses entre a data fornecida e a data atual.
        /// </summary>
        /// <param name="dtInicial">Data inicial par o cálculo de diferença.</param>
        /// <returns>Valor inteiro representando a diferença em meses das datas. Retorna -1 se data for nula ou inválida.</returns>
        public static int diferencaMeses(DateTime dtInicial)
        {
            if (dtInicial == null)
                return -1;
            try
            {
                TimeSpan diferencaDatas = DateTime.Now.Subtract(dtInicial);
                DateTime idade = DateTime.MinValue + diferencaDatas;
                int mesesAnos = (idade.Year - 1) * 12;
                mesesAnos += idade.Month - 1;
                return mesesAnos;
            }
            catch (Exception e)
            {
                throw e;
                return -1;
            }
        }

        #endregion

        #region Mascaras

        /// <summary>
        /// Compara a mascara à string
        /// </summary>
        /// <param name="m">Mascara</param>
        /// <param name="val">String a comparar</param>
        /// <param name="sucesso">Retorna true se corresponde, false se não.</param>
        /// <returns>O valor adaptado à mascara fornecida, ou mensagem indicando o que houve de errado, se sucesso = false.</returns>
        public static string ComparaMascara(string m, string val, out bool sucesso)
        {
            sucesso = true;
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(m) || string.IsNullOrEmpty(val))
            {
                sucesso = false;
                return "A máscara e/ou o valor estavam vazios.<br />";
            }
            string[] partesM = m.Split('.');   // Partes da mascara
            string[] partesV = val.Split('.'); // Partes do valor

            if (partesV.Length == 1 && partesV[0].Length > 1) // String passada sem separadores. Deve ter os digitos certos, sem suprimir zeros.
            {
                int quantosM = 0;
                foreach (string s in partesM)
                {
                    quantosM += s.Length;
                }
                if (partesV[0].Length != quantosM) // Digitos incompatíveis.
                {
                    sucesso = false;
                    return "String sem separadores e com numero incorreto de digitos. Impossível determinar as possições corretas.<br />";
                }
                else // Casas corretas, tenta bater as posições.
                {
                    try
                    {
                        int valAtual = 0;
                        for (int x = 0; x < partesM.Length; x++)
                        {
                            StringBuilder sbAux = new StringBuilder();
                            for (int y = 0; y < partesM[x].Length; y++)
                            {
                                sbAux.Append(partesV[0].Substring(valAtual, 1));
                                valAtual++;
                            }
                            
                            sb.Append(sbAux.ToString());
                            if (x < partesM.Length - 1) // Adiciona pontos, exceto na última parte
                                sb.Append(".");
                        }
                    }
                    catch (Exception ex)
                    {
                        sb.Append("Erro inesperado! " + ex.Message);
                        sucesso = false;
                        return sb.ToString();
                    }
                }

            }
            else // String com separadores. Devem ser na mesma quantidade.
            {

                if (partesM.Length < partesV.Length) // Testa os níveis
                {
                    sucesso = false;
                    return "Mascara com menos níveis que o valor passado.<br />";
                }
                else // Níveis válidos, tenta bater as posições.
                {
                    //StringBuilder sbAux = new StringBuilder();
                    try
                    {
                        for (int x = 0; x < partesV.Length; x++)
                        {
                            StringBuilder sbAux = new StringBuilder();
                            for (int y = 0; y < partesV[x].Length; y++)
                                sbAux.Append(partesV[x].Substring(y, 1));

                            if (partesM[x].Length != sbAux.Length) // Haviam zeros suprimidos, completar à esquerda.
                                for (int y = 0; sbAux.Length < partesM[x].Length; y++)
                                {
                                    sbAux.Insert(0, '0');
                                }
                            sb.Append(sbAux.ToString());
                            if (x < partesV.Length - 1) // Adiciona pontos, exceto na última parte
                                sb.Append(".");
                        }
                    }
                    catch (Exception ex)
                    {
                        sb.Append("Erro inesperado! " + ex.Message);
                        sucesso = false;
                        return sb.ToString();
                    }
                }
            }
            return sb.ToString();
        }

        #endregion

        #region Validações

        public static bool ValidarCNS(string CNS)
        {
            int indice;
            int somatorio = 0;
            string cnsAux;
            int resto;
            int digitoVerificador;
            string resultado;

            long valor;

            if (!string.IsNullOrEmpty(CNS))
                CNS = CNS.Trim();

            if ((Int64.TryParse(CNS, out valor)) && (CNS.Length == 15))
            {
                if ((CNS.StartsWith("8")) || (CNS.StartsWith("9")))
                {
                    cnsAux = CNS; // Para CNS Provisório
                }
                else
                {
                    cnsAux = CNS.Substring(0, 11); //Para CNS Definitivo
                }

                // Calcula Somatório para ambos os casos
                for (indice = 0; indice < cnsAux.Length; indice++)
                {
                    somatorio += Convert.ToInt32(cnsAux.Substring(indice, 1)) * (15 - indice);
                }

                resto = (somatorio % 11);

                // Tratamento para CNS Provisório
                if ((CNS.StartsWith("8")) || (CNS.StartsWith("9")))
                {
                    return (resto == 0);
                }
                //Tratamento para CNS Definitivo
                else
                {
                    digitoVerificador = 11 - resto;

                    if (digitoVerificador == 11)
                    {
                        digitoVerificador = 0;
                    }

                    if (digitoVerificador == 10)
                    {
                        // Se o DV for 10, soma 2 ao Somatório e recalcula Resto e DV
                        somatorio = somatorio + 2;
                        resto = (somatorio % 11);
                        digitoVerificador = 11 - resto;
                        resultado = cnsAux + "001" + digitoVerificador;
                    }
                    else
                    {
                        resultado = cnsAux + "000" + digitoVerificador;
                    }

                    return (CNS == resultado);
                }
            }
            return false;
        }

        public static int GeraDgvMod10(string numero)
        {
            if (numero.Trim().Length < 10)
                numero = numero.Trim().PadLeft((10 - numero.Trim().Length), '0'); 
            int soma = 0;
            int dgv = 0;
            int multiplicador = 2;
            int[] numDobrados = new int[10];

            for (int i = numero.Length - 1; i >= 0; i--)
            {
                numDobrados[i] = int.Parse(numero[i].ToString()) * multiplicador;
                if (numDobrados[i] == 10)
                { soma += 1; }
                else if (numDobrados[i] < 10)
                { soma += numDobrados[i]; }
                else
                {
                    int soma1 = (numDobrados[i] / 10);
                    int soma2 = (numDobrados[i] % 10);

                    soma += soma1 + soma2;
                }
                multiplicador = multiplicador == 2 ? 1 : 2;
            }

            dgv = 10 - (soma % 10);
            return dgv;
        }

        /// <summary>
        ///  Função: 
        ///  Calculo do Modulo 11 para geracao do digito verificador 
        ///    de boletos bancarios conforme documentos obtidos 
        ///    da Febraban - www.febraban.org.br 
        ///
        ///  Entrada: 
        ///     $num: string numérica para a qual se deseja calcularo digito verificador; 
        ///     $base: valor maximo de multiplicacao [2-$base] 
        ///     $r: quando especificado um devolve somente o resto 
        /// 
        ///
        ///  Observações: 
        ///    - Exemplo de uso: getMod11(nossoNumero, 9,1) 
        ///    - 9 e 1 são fixos de acordo com a base 
        ///     - Assume-se que a verificação do formato das variáveis de entrada é feita antes da execução deste script. 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>  Saída: Retorna o Digito verificador
        /// </returns>
        public static string ValidarDVMod11(String numero)
        {
            int bas = 9;
            int r = 0;
            numero = numero.Trim();
            if (numero.Length >= 10)
                numero = numero.Substring(0, 10);
            else
                numero = numero.Trim().PadLeft((10), '0');

            int soma = 0;
            int fator = 2;
            String[] numeros, parcial;
            numeros = new String[numero.Length + 1];
            parcial = new String[numero.Length + 1];

            /* Separacao dos numeros */
            for (int i = numero.Length; i > 0; i--)
            {
                // pega cada numero isoladamente  
                numeros[i] = numero.Substring(i - 1, 1);
                // Efetua multiplicacao do numero pelo falor  
                parcial[i] = (Convert.ToInt32(numeros[i]) * fator).ToString();
                // Soma dos digitos  
                soma += Convert.ToInt32(parcial[i]);
                if (fator == bas)
                {
                    // restaura fator de multiplicacao para 2  
                    fator = 1;
                }
                fator++;
            }
            /* Calculo do modulo 11 */
            if (r == 0)
            {
                soma *= 10;
                int digito = soma % 11;
                if (digito == 10)
                {
                    digito = 0;
                }
                return digito.ToString();
            }
            else
            {
                int resto = soma % 11;
                return resto.ToString();
            }
        }

        #endregion
    }
}

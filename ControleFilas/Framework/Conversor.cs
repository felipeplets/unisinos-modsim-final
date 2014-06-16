using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Castle.ActiveRecord;

namespace Comum.Framework
{
    public class Conversor
    {
        /// <summary>
        /// Converte uma DataTable gerada pelo metodo "ConverterParaDataTable" de volta a uma coleção de objetos.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto principal. Ex.: Paciente</typeparam>
        /// <param name="dtObjeto">DataTable com os dados.</param>
        /// <returns>Lista de objetos do tipo informado, com as propriedades setadas conforme as colunas da DataTable</returns>
        public static IList<T> ConverterParaObjetos<T>(DataTable dtObjeto) where T : new()
        {
            IList<T> oLista = new List<T>();
            T obj;
            foreach(DataRow row in dtObjeto.Rows) // Para cada linha da DataTable
            {
                obj = new T();
                PropertyInfo[] props = obj.GetType().GetProperties();
                obj = (T)Conversor.VarrePropriedades(obj, row, dtObjeto.Columns);
                oLista.Add(obj);
            }
            return oLista;
        }

        /// <summary>
        /// Varre recursivamente as propriedades do objeto informado, setando todas conforme as colunas da DataTable
        /// </summary>
        /// <param name="obj">Objeto principal</param>
        /// <param name="row">Linha da DataTable com os dados.</param>
        /// <param name="dcc">Coleção de colunas da DataTable, para obter a lista de propriedades.</param>
        /// <returns>Objeto Setado com os valores da linha da DataTable.</returns>
        private static object VarrePropriedades(object obj, DataRow row, DataColumnCollection dcc)
        {
            foreach (DataColumn dc in dcc) // Varre colunas da DataTable
            {
                foreach (PropertyInfo property in obj.GetType().GetProperties()) // Varre as propriedades
                {
                    bool achou = false;
                    foreach (string parte in dc.ColumnName.Split('_'))
                    {
                        if (parte == property.Name)
                        {
                            achou = true;
                            break;
                        }
                    }
                    //if (dc.ColumnName.Split('_')[dc.ColumnName.Split('_').Length - 1] == property.Name)
                    if(achou)
                    {
                        if (property.PropertyType.FullName.StartsWith("System") && !property.PropertyType.FullName.StartsWith("System.Collection")) // Propriedades da classe T
                        {
                            obj.GetType().GetProperty(property.Name).SetValue(obj, row[dc.ColumnName].ToString() == String.Empty ? null : row[dc.ColumnName], null);
                            //dc.ColumnName = dc.ColumnName;
                            break;
                        }
                        else // Propriedades tipo objeto da classe T
                        {
                            Type tipo = property.PropertyType;
                            object subObj;
                            if (property.PropertyType.FullName.Contains("IList"))
                            {
                                #region exemplo
                                /*
                                 * string t = name + "`" + types.Length;
      Type generic = Type.GetType(t).MakeGenericType(types);
      return Activator.CreateInstance(generic);
                                 */
                                #endregion
                                string t = "System.Collections.Generic.List`1";
                                subObj = Activator.CreateInstance(Type.GetType(t).MakeGenericType(property.PropertyType.GetGenericArguments()));
                            }
                            else
                            {
                                subObj = Activator.CreateInstance(property.PropertyType);
                            }
                            subObj = VarrePropriedades(subObj, row, dcc);
                            obj.GetType().GetProperty(property.Name).SetValue(obj, subObj, null);
                            break;
                        }
                    }
                }
            }
            return obj;
        }

        //private static T RetornarObjeto(T poObjetoBanco, T poObjetoInterface)
        //{
        //    foreach (PropertyInfo piPropriedadeAtual in poObjetoInterface.GetType().GetProperties())
        //    {
        //        if ((piPropriedadeAtual.Name != "NomeChavePrimaria") && !(piPropriedadeAtual.PropertyType.Name.Contains("IList")) && (piPropriedadeAtual.CanWrite))
        //            poObjetoBanco.GetType().GetProperty(piPropriedadeAtual.Name).SetValue(poObjetoBanco, piPropriedadeAtual.GetValue(poObjetoInterface, null), null);
        //    }

        //    return poObjetoBanco;
        //}

        /// <summary>
        /// Converte uma lista de objetos para uma DataTable.
        /// </summary>
        /// <typeparam name="T">O tipo da lista de objetos.</typeparam>
        /// <param name="ploObjeto">A lista de objetos.</param>
        /// <param name="pstNomeDataTable">O nome da DataTable a ser gerada.</param>
        /// <param name="propriedades">O nome das propriedades cujas colunas da DataTable serão geradas.</param>
        /// <returns>DataTable</returns>
        public static DataTable ConverterParaDataTable<T>(IList<T> ploObjeto, string pstNomeDataTable, params string[] propriedades)
        {
            return Conversor.ConverterParaDataTableAuxiliar<T>(ploObjeto, pstNomeDataTable, propriedades);
        }

        /// <summary>
        /// Converte uma lista de objetos para uma DataTable.
        /// </summary>
        /// <param name="ploObjeto">A lista de objetos.</param>
        /// <param name="pstNomeDataTable">O nome da DataTable a ser gerada.</param>
        /// <param name="propriedades">O nome das propriedades cujas colunas da DataTable serão geradas.</param>
        /// <returns>DataTable</returns>
        public static DataTable ConverterParaDataTable(IList ploObjeto, string pstNomeDataTable, params string[] propriedades)
        {
            return Conversor.ConverterParaDataTableAuxiliar<object>((IList<object>)ploObjeto, pstNomeDataTable, propriedades);
        }

        /// <summary>
        /// Converte uma lista de objetos para uma DataTable.
        /// Este método deve ser utilizado em casos onde cada posição da lista é um array de objetos. Exemplo: HqlQuery utilizando o tipo objects.
        /// Ou seja HqlQuery que retorna exatamente as colunas desejadas.
        /// </summary>
        /// <param name="ploObjeto">A lista de objetos.</param>
        /// <param name="pstNomeDataTable">O nome da DataTable a ser gerada.</param>
        /// <param name="propriedades">O nome das propriedades cujas colunas da DataTable serão geradas. Caso não for passado valor nenhum,
        /// serão criadas colunas cujo nome é um número sequencial de acordo com o número de posições dos arrays dentro da lista.</param>
        /// <returns>DataTable</returns>
        public static DataTable ConverterParaDataTable(IList<object> ploObjeto, string pstNomeDataTable, params string[] pstPropriedades)
        {
            DataTable oDataTable = new DataTable(pstNomeDataTable); string teste = "";

            //Verifica se o parâmetro dos nomes das colunas veio maior que zero. Se sim, adiciona uma coluna para cada posição do array.
            //Caso contrário, adiciona os nomes das colunas sequencialmente de acordo com o número de posições do array.
            if (pstPropriedades.Length > 0)
            {
                foreach (string oPropriedadeAtual in pstPropriedades)
                    oDataTable.Columns.Add(oPropriedadeAtual);
            }
            else
            {
                if (ploObjeto.Count > 0)
                {
                    for (int iIndice = 0; iIndice < ((object[])ploObjeto[0]).Length; iIndice++)
                        oDataTable.Columns.Add(iIndice.ToString());
                }
            }

            foreach (object oObjetoAtual in ploObjeto)
                oDataTable.Rows.Add((object[])oObjetoAtual);

            return oDataTable;
        }

        /// <summary>
        /// Converte uma lista de objetos para uma DataTable.
        /// </summary>
        /// <param name="ploObjeto">A lista de objetos.</param>
        /// <param name="pstNomeDataTable">O nome da DataTable a ser gerada.</param>
        /// <param name="propriedades">O nome das propriedades cujas colunas da DataTable serão geradas.</param>
        /// <returns>DataTable</returns>
        private static DataTable ConverterParaDataTableAuxiliar<T>(IList<T> ploObjeto, string pstNomeDataTable, params string[] propriedades)
        {
            DataTable dt = new DataTable(pstNomeDataTable);
            int i;

            foreach (string prop in propriedades)
                dt.Columns.Add(prop.Replace('.', '_'), ReflectionUtil.GetPropertyType(typeof(ActiveRecordBase), prop));

            foreach (object obj in ploObjeto)
            {
                i = 0;
                object[] vals = new object[propriedades.Length];
                foreach (string prop in propriedades)
                {
                    vals[i] = ReflectionUtil.GetPropertyValue(obj, prop);
                    i++;
                }
                dt.Rows.Add(vals);
            }
            return dt;
        }
    }

    #region Utilidades

    internal class ReflectionUtil
    {
        ReflectionUtil()
        {
        }

        public static bool InstanceOf<T>(Object instance)
        {
            return typeof(T).IsInstanceOfType(instance);
        }

        #region Assembly Loading

        /// <summary>
        /// Checks if the assembly is loaded in the current AppDomain
        /// </summary>
        /// <param name="assemblyName">The full assembly name to search for.</param>
        /// <returns>true if the assembly is loaded otherwise false</returns>
        public static bool AssemblyLoaded(String assemblyName)
        {
            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (ass.GetName().Name.Equals(assemblyName))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Loads the assembly into the current AppDomain
        /// </summary>
        /// <param name="assemblyName">The full assembly name to load into the current AppDomain</param>
        /// <returns>The loaded assembly</returns>
        public static Assembly LoadAssembly(String assemblyName)
        {
            return Assembly.Load(assemblyName);
        }

        #endregion

        #region Activate Classes

        /// <summary>
        /// Attempts to create an instance by calling the default constructor of the class.
        /// </summary>
        /// <param name="className">The full class name of the class to activate.</param>
        /// <param name="assemblyName">The full assembly name containing the class to activate.</param>
        /// <returns>The activated class</returns>
        /// <remarks>The class name must be the full name eg. MyNamespace.ClassName</remarks>
        public static Object CreateLocalInstance(String className, String assemblyName)
        {
            Object obj = null;
            try
            {
                Assembly ass = LoadAssembly(assemblyName);
                obj = Activator.CreateInstance(ass.GetType(className, true, true));
            }
            catch
            {
            }
            return obj;
        }

        /// <summary>
        /// Attempts to create an instance by calling the default constructor of the class.
        /// </summary>
        /// <typeparam name="T">The Type to return.</typeparam>
        /// <param name="className">The full class name of the class to activate.</param>
        /// <param name="assemblyName">The full assembly name containing the class to activate.</param>
        /// <returns>The activate class casted to type T</returns>
        /// <remarks>The class name must be the full name eg. MyNamespace.ClassName</remarks>
        public static T CreateLocalInstance<T>(String className, String assemblyName)
        {
            return (T)CreateLocalInstance(className, assemblyName);
        }

        public static T CreateLocalInstance<T>(Type type)
        {
            return (T)Activator.CreateInstance(type);
        }

        /// <summary>
        /// Attempts to create an instance by calling the default constructor of the class.
        /// </summary>
        /// <typeparam name="T">The Type to return.</typeparam>
        /// <param name="className">The class to activate.</param>
        /// <returns>The activate class casted to type T</returns>
        /// <remarks>The class name must be the full name eg. MyNamespace.ClassName</remarks>
        public static T CreateLocalInstance<T>(String className)
        {
            return (T)Activator.CreateInstance(Type.GetType(className));
        }

        #endregion

        #region Type Getters

        /// <summary>
        /// Returns the Type represented by the assemblyName and className
        /// </summary>
        /// <param name="assemblyName">The full assembly name to check for the Type</param>
        /// <param name="className">The full class name of the Type to get.</param>
        /// <returns>The Type if found otherwise null.</returns>
        /// <remarks>The class name must be the full name eg. MyNamespace.ClassName</remarks>
        public static Type GetType(String assemblyName, String className)
        {
            Type t = null;
            try
            {
                t = Type.GetType(className, true, true);
            }
            catch
            {
                try
                {
                    Assembly ass = LoadAssembly(assemblyName);
                    t = ass.GetType(className, true, true);
                }
                catch
                {
                    t = null;
                }
            }
            return t;
        }

        #endregion

        public static Object GetPropertyValue(Object rootInstance, String propertyPath)
        {
            if (rootInstance == null)
                return null;

            Type t = rootInstance.GetType();
            if (String.IsNullOrEmpty(propertyPath))
                return null;

            int dotIdx = propertyPath.IndexOf('.');
            if (dotIdx <= 0)
            {
                return SafeGetProperty(t, propertyPath).GetValue(rootInstance, null);
            }

            String prop = propertyPath.Substring(0, dotIdx);
            return GetPropertyValue(SafeGetProperty(t, prop).GetValue(rootInstance, null), propertyPath.Substring(dotIdx + 1));
        }

        private static PropertyInfo SafeGetProperty(Type t, string property)
        {
            try
            {
                return t.GetProperty(property);
            }
            catch (AmbiguousMatchException)
            {
                return t.GetProperty(property, BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
            }
            return null;
        }

        public static T GetPropertyValue<T>(Object rootInstance, String propertyPath)
        {
            if (rootInstance == null)
                return default(T);

            Type t = rootInstance.GetType();
            if (String.IsNullOrEmpty(propertyPath))
                return default(T);

            int dotIdx = propertyPath.IndexOf('.');
            if (dotIdx <= 0)
                return (T)SafeGetProperty(t, propertyPath).GetValue(rootInstance, null);

            String prop = propertyPath.Substring(0, dotIdx);
            return GetPropertyValue<T>(SafeGetProperty(t, prop).GetValue(rootInstance, null), propertyPath.Substring(dotIdx + 1));
        }

        public static Type GetPropertyType(Type rootType, String propertyPath)
        {
            PropertyInfo pi;
            if (rootType == null)
                throw new ArgumentNullException("rootType", "root type is null for property path " + propertyPath);

            if (String.IsNullOrEmpty(propertyPath))
                throw new ArgumentException("propertyPath", "propertyPath cannot be null or empty for type " + rootType.FullName);

            int dotIdx = propertyPath.IndexOf('.');
            if (dotIdx <= 0)
            {
                pi = rootType.GetProperty(propertyPath);
                if (pi != null) return pi.PropertyType;
                foreach (Type t in rootType.GetInterfaces())
                {
                    pi = SafeGetProperty(t, propertyPath);
                    if (pi != null) return pi.PropertyType;
                }
                return typeof(Object);
            }

            String prop = propertyPath.Substring(0, dotIdx);
            pi = SafeGetProperty(rootType, prop);
            if (pi != null) return GetPropertyType(pi.PropertyType, propertyPath.Substring(dotIdx + 1));
            foreach (Type t in rootType.GetInterfaces())
            {
                pi = SafeGetProperty(t, prop);
                if (pi != null) break;
            }
            if (pi == null) return typeof(Object);
            return GetPropertyType(pi.PropertyType, propertyPath.Substring(dotIdx + 1));
        }
    }

    #endregion
}

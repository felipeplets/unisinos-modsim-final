using ControleFilas.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFilas.Converter
{
    public class ElementoTotalConverter
    {
        public static ElementoTotal ConverterParaElementoTotal(Elemento elementoServir, Elemento elementoPagar, int constanteTempoComer)
        {
            ElementoTotal elementoTotal = new ElementoTotal();

            elementoTotal.Indice = elementoServir.Indice;
            elementoTotal.TempoTotal = elementoServir.TempoTotal + elementoPagar.TempoTotal + constanteTempoComer;
            elementoTotal.TempoFila = elementoServir.TempoFila + elementoPagar.TempoFila;
            
            return elementoTotal;
        }

        public static List<ElementoTotal> ConverterParaListElementoTotal(List<Elemento> listElementoServir, List<Elemento> listElementoPagar, int constanteTempoComer)
        {
            List<ElementoTotal> listElementoTotal = new List<ElementoTotal>();

            for (int i = 0; i < listElementoServir.Count; i++)
            {
                listElementoTotal.Add(ElementoTotalConverter.ConverterParaElementoTotal(listElementoServir[i], listElementoPagar[i], constanteTempoComer));
            }

            return listElementoTotal;
        }
    }
}

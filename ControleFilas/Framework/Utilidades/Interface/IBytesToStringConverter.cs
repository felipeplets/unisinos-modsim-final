using System;
using System.Collections.Generic;
using System.Text;

namespace Comum.Framework.Utilidade
{
    public interface IBytesToStringConverter
    {
        string Converter(byte[] bytes);
    }
}

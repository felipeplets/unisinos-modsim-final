using System;
using System.Collections.Generic;
using System.Text;

namespace Ecosistemas.Framework.Utilidade
{
    public interface IBytesToStringConverter
    {
        string Converter(byte[] bytes);
    }
}

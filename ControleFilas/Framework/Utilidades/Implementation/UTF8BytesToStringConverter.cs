using System;
using System.Collections.Generic;
using System.Text;

namespace Ecosistemas.Framework.Utilidade
{
    public class UTF8BytesToStringConverter : IBytesToStringConverter
    {
        public string Converter(byte[] bytes)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(bytes);
        }
    }
}

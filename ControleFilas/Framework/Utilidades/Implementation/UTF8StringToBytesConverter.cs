using System;
using System.Collections.Generic;
using System.Text;

namespace Comum.Framework.Utilidade
{
    public class UTF8StringToBytesConverter : IStringToBytesConverter
    {
        public byte[] Converter(string value)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(value);
        }
    }
}

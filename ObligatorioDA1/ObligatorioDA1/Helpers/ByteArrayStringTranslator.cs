using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class ByteArrayStringTranslator
    {
        public static byte[] ToByteArray(string entry)
        {
            byte[] result = new byte[entry.Length];

            for(int i = 0; i < entry.Length; i++)
            {
                result[i] = (byte)entry[i];
            }

            return result;
        }

        public static string ToString(byte[] entry)
        {
            string result = "";

            for (int i = 0; i < entry.Length; i++)
            {
                result += (char)entry[i];
            }

            return result;
        }
    }
}

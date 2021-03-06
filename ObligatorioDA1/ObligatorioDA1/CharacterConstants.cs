using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CharacterConstants
    {
        public static readonly char[] ALL_MAYUS_CHARACTERS =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S' , 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z', 'Ñ'
        };

        public static readonly char[] ALL_MINUS_CHARACTERS =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's' , 't', 'u', 'v',
            'w', 'x', 'y', 'z', 'ñ'
        };

        public static readonly char[] ALL_DIGIT_CHARACTERS =
        {
            '0', '1', '2', '3', '4', '5', '6',
            '7', '8', '9'
        };

        public static readonly char[] ALL_SYMBOL_CHARACTERS =
        {
            '!', '@', '#', '$', '%', '^', '&',
            '+', '=', '_', '-', ')', '(', '*',
            '`', '~', '/', '\\', '.' , ',', '>', '<',
            '[', ']', ':', '"', ';', '{', '}', 
            '|', '?', ' ', '`', ("'").ToCharArray()[0]
        };
    }
}

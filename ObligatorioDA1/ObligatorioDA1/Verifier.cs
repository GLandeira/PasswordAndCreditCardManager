using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;


namespace Domain
{
    public static class Verifier
    {
        //estos dos son de prueba
        private const int MAXIMUM_CHARACTERS_CATEGORY_NAME = 15;
        private const int MINIMUM_CHARACTERS_CATEGORY_NAME = 3;

        //hago asi para diferenciar o ponemos una variable y ya fue?
        private const int MAXIMUM_CHARACTERS_CREDITCARD_NAME = 25;
        private const int MINIMUM_CHARACTERS_CREDITCARD_NAME = 3;
        private const int CHARACTERS_CREDITCARD_NUMBER = 16;
        private const int CHARACTERS_CREDITCARD_SECURITYCODE = 3;

        public static void VerifyCreditCard(CreditCard creditCardTested)
        {
            VerifyCreditCardName(creditCardTested);
            VerifyCreditCardNumber(creditCardTested);
            VerifyCreditCardSecurityCode(creditCardTested);
        }

        private static void VerifyCreditCardName(CreditCard creditCardTested)
        {
            if (creditCardTested.Name.Length <= MINIMUM_CHARACTERS_CREDITCARD_NAME
                                        || creditCardTested.Name.Length >= MAXIMUM_CHARACTERS_CREDITCARD_NAME)
            {
                throw new NameCreditCardException();
            }
        }

        private static void VerifyCreditCardNumber(CreditCard creditCardTested)
        {
            if (creditCardTested.Number.Length != CHARACTERS_CREDITCARD_NUMBER 
                                        || !creditCardTested.Number.All(itIsNumber))
            {
                throw new NumberCreditCardException();
            }
        }

        private static void VerifyCreditCardSecurityCode(CreditCard creditCardTested)
        {
            if (creditCardTested.SecurityCode.Length != CHARACTERS_CREDITCARD_SECURITYCODE
                                        || !creditCardTested.SecurityCode.All(itIsNumber))
            {
                throw new SecurityCodeCreditCardException();
            }
        }

        private static bool itIsNumber(char numberSubString)
        {
            return (numberSubString >= '0' && numberSubString <= '9');
        }


        //Creditcard
        //        Largo máximo de los campos:
        //- Name: Mínimo 3 caracteres y máximo 25 -> ver despues si puedo combinarlo con el sitio de password
        //- type: se selecciona de las disponibles en el sistema
        //- number: 16 caracteres, todos numeros
        //- security code: 3 numeros
        //- Categoría: Se selecciona de las disponibles en el sistema
        //- Notas: Sin mínimo y máximo 250 caracteres

        //password
        //        Largo máximo de los campos:
        //- Usuario: Mínimo 5 caracteres y máximo 25
        //- Contraseña: Mínimo 5 caracteres y máximo 25
        //- Sitio: Mínimo 3 caracteres y máximo 25
        //- Notas: Sin mínimo y máximo 250 caracteres
        //- Categoría: Se selecciona de las disponibles en el sistema
    }
}

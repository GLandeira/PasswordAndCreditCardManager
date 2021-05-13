using System.Linq;
using System;
using Domain.Exceptions;

//Creditcard
//     Largo máximo de los campos:
//- Name: Mínimo 3 caracteres y máximo 25 
//- type: se selecciona de las disponibles en el sistema -> lista
//- number: 16 caracteres, todos numeros
//- security code: 3 numeros
//- Categoría: Se selecciona de las disponibles en el sistema -> lista
//- Notas: Sin mínimo y máximo 250 caracteres

//password
//   Largo máximo de los campos:
//- Usuario: Mínimo 5 caracteres y máximo 25
//- Contraseña: Mínimo 5 caracteres y máximo 25
//- Sitio: Mínimo 3 caracteres y máximo 25
//- Notas: Sin mínimo y máximo 250 caracteres
//- Categoría: Se selecciona de las disponibles en el sistema -> lista

namespace Domain
{
    public class Verifier
    {
        //Users Variables
        private const int MAXIMUM_CHARACTERS_USER_NAMExMAINPASSWORD = 25;
        private const int MINIMUM_CHARACTERS_USER_NAMExMAINPASSWORD = 5;

        //Credit Variables
        private const int MAXIMUM_CHARACTERS_CREDITCARD_NAME = 25;
        private const int MINIMUM_CHARACTERS_CREDITCARD_NAME = 3;
        private const int CHARACTERS_CREDITCARD_NUMBER = 16;
        private const int MAXIMUM_CHARACTERS_CREDITCARD_SECURITYCODE = 4;
        private const int MINIMUM_CHARACTERS_CREDITCARD_SECURITYCODE = 3;

        //Password Variables
        private const int MAXIMUM_CHARACTERS_PASSWORD_USERxPASSWORDxSITE = 25;
        private const int MINIMUM_CHARACTERS_PASSWORD_USERxPASSWORD = 5;
        private const int MINIMUM_CHARACTERS_PASSWORD_SITE = 3;

        //Category Variables
        private const int MAXIMUM_CHARACTERS_CATEGORY_NAME = 15;
        private const int MINIMUM_CHARACTERS_CATEGORY_NAME = 3;

        //Variables in common
        private const int CHARACTERS_NOTES = 250;

        public static void VerifyUser(User userTested)
        {
            VerifyUserName(userTested);
            VerifyUserMainPassword(userTested);
        }

        public static void VerifyCreditCard(CreditCard creditCardTested)
        {
            VerifyCreditCardName(creditCardTested);
            VerifyCreditCardNumber(creditCardTested);
            VerifyCreditCardSecurityCode(creditCardTested);
            VerifyCreditCardNotes(creditCardTested);
            VerifyCreditCardValidDue(creditCardTested);
        }

        public static void VerifyPassword(Password passwordTested)
        {
            VerifyPasswordSite(passwordTested);
            VerifyPasswordPasswordString(passwordTested);
            VerifyPasswordUsername(passwordTested);
            VerifyPasswordNotes(passwordTested);
        }

        public static void VerifyCategory(Category categoryTested)
        {
            if (categoryTested.Name.Length < MINIMUM_CHARACTERS_CATEGORY_NAME
                                        || categoryTested.Name.Length > MAXIMUM_CHARACTERS_CATEGORY_NAME)
            {
                throw new NameCategoryException();
            }
        }

        private static void VerifyUserName(User userTested)
        {
            if (userTested.Name.Length < MINIMUM_CHARACTERS_USER_NAMExMAINPASSWORD
                                        || userTested.Name.Length > MAXIMUM_CHARACTERS_USER_NAMExMAINPASSWORD)
            {
                throw new NameUserException();
            }
        }

        private static void VerifyUserMainPassword(User userTested)
        {
            if (userTested.MainPassword.Length < MINIMUM_CHARACTERS_USER_NAMExMAINPASSWORD
                                        || userTested.MainPassword.Length > MAXIMUM_CHARACTERS_USER_NAMExMAINPASSWORD)
            {
                throw new MainPasswordUserException();
            }
        }

        private static void VerifyCreditCardName(CreditCard creditCardTested)
        {
            if (creditCardTested.Name.Length < MINIMUM_CHARACTERS_CREDITCARD_NAME
                                        || creditCardTested.Name.Length > MAXIMUM_CHARACTERS_CREDITCARD_NAME)
            {
                throw new NameCreditCardException();
            }
        }

        private static void VerifyCreditCardNumber(CreditCard creditCardTested)
        {
            if (creditCardTested.Number.Length != CHARACTERS_CREDITCARD_NUMBER 
                                        || !creditCardTested.Number.All(ItIsNumber))
            {
                throw new NumberCreditCardException();
            }
        }

        private static void VerifyCreditCardSecurityCode(CreditCard creditCardTested)
        {
            if (creditCardTested.SecurityCode.Length < MINIMUM_CHARACTERS_CREDITCARD_SECURITYCODE
                            || creditCardTested.SecurityCode.Length > MAXIMUM_CHARACTERS_CREDITCARD_SECURITYCODE
                                        || !creditCardTested.SecurityCode.All(ItIsNumber))
            {
                throw new SecurityCodeCreditCardException();
            }
        }

        private static void VerifyCreditCardNotes(CreditCard creditCardTested)
        {
            if (creditCardTested.Notes.Length > CHARACTERS_NOTES)
            {
                throw new NotesCreditCardException();
            }
        }

        private static void VerifyCreditCardValidDue(CreditCard creditCardTested)
        {
            if (creditCardTested.ValidDue < DateTime.Today)
            {
                throw new ValidDueCreditCardException();
            }
        }

        private static void VerifyPasswordSite(Password passwordTested)
        {
            if (passwordTested.Site.Length < MINIMUM_CHARACTERS_PASSWORD_SITE
                            || passwordTested.Site.Length > MAXIMUM_CHARACTERS_PASSWORD_USERxPASSWORDxSITE)
            {
                throw new SitePasswordException();
            }   
        }

        private static void VerifyPasswordPasswordString(Password passwordTested)
        {
            if (passwordTested.PasswordString.Length < MINIMUM_CHARACTERS_PASSWORD_USERxPASSWORD
                            || passwordTested.PasswordString.Length > MAXIMUM_CHARACTERS_PASSWORD_USERxPASSWORDxSITE)
            {
                throw new PasswordStringPasswordException();
            }
        }

        private static void VerifyPasswordUsername(Password passwordTested)
        {
            if (passwordTested.Username.Length < MINIMUM_CHARACTERS_PASSWORD_USERxPASSWORD
                            || passwordTested.Username.Length > MAXIMUM_CHARACTERS_PASSWORD_USERxPASSWORDxSITE)
            {
                throw new UsernamePasswordException();
            }
        }

        private static void VerifyPasswordNotes(Password passwordTested)
        {
            if (passwordTested.Notes.Length > CHARACTERS_NOTES)
            {
                throw new NotesPasswordException();
            }
        }

        private static bool ItIsNumber(char numberSubString)
        {
            return (numberSubString >= '0' && numberSubString <= '9');
        }



    }
}

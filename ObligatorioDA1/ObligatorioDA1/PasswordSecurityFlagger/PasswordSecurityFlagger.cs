using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions;

namespace Domain.PasswordSecurityFlagger
{
    public class PasswordSecurityFlagger
    {
        public static SecurityLevelPasswords GetSecurityLevel(String password)
        {
            ColorClassifier colorClassifier = new RedClassifier();

            return DetermineSecurityLevel(colorClassifier, password);
        }

        private static SecurityLevelPasswords DetermineSecurityLevel(ColorClassifier colorClassifier, String password)
        {
            if (colorClassifier.MeetsColorCriteria(password)) return colorClassifier.AssociatedSecurityLevel;

            colorClassifier = DetermineNextColorClassifierType(colorClassifier);

            return DetermineSecurityLevel(colorClassifier, password);
        }  
        
        private static ColorClassifier DetermineNextColorClassifierType(ColorClassifier colorClassifier)
        {
            // Switch sobre el tipo del Classifier ya que hacemos uso de polimorfismo.
            // La llamada recursiva sigue un orden especifico de classifiers:
            switch (colorClassifier)
            {
                case RedClassifier red:
                    // Si no es una contraseña Roja: Fijarnos si es Naranja
                    return new OrangeClassifier();
                case OrangeClassifier orange:
                    // Si no es una contraseña Naranja: Fijarnos si es Verde Oscuro
                    return new DarkGreenClassifier();
                case YellowClassifier yellow:
                    // Si no es una contraseña Amarilla: No es ningun tipo de contraseña y tiramos error.
                    throw new CouldntAssignSecurityLevelException();
                case LightGreenClassifier lightGreen:
                    // Si no es una contraseña Verde Clara: Fijarnos si es amarilla
                    return new YellowClassifier();
                case DarkGreenClassifier darkGreen:
                    // Si no es una contraseña Verde Oscura: Fijarnos si es Verde Clara.
                    return new LightGreenClassifier();
                default:
                    throw new CouldntAssignSecurityLevelException();
            }
        }
    }
}

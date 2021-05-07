using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RedClassifier
    {
        public static bool MeetsColorCriteria(String password)
        {
            bool meetsCriteria = password.Length < 8;

            return meetsCriteria;
        }
    }
}

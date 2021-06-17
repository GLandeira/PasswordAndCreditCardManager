using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordRecommender
{
    public struct SecurityCondition
    {
        public bool IsNotBreached;
        public bool IsNotInUse;
        public bool IsNotLowSecurityLevel;

    }
}

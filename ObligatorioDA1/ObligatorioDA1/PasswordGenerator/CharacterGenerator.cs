using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordGenerator
{
    public abstract class CharacterGenerator
    {
        public CharacterGenerator()
        {
            _thisRandom = new Random();
        }

        protected Random _thisRandom;

        protected abstract int MinimumAsciiThreshold { get; }
        protected abstract int MaximumAsciiThreshold { get; }

        public abstract char GenerateCharacter();
    }
}

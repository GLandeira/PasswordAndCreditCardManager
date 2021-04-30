using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordGenerator
{
    public class MinusCharacterGenerator : CharacterGenerator
    {
        protected override int MinimumAsciiThreshold => 97;

        protected override int MaximumAsciiThreshold => 122;

        public override char GenerateCharacter()
        {
            int generatedCharacterNumber = _thisRandom.Next(MinimumAsciiThreshold, MaximumAsciiThreshold + 1);
            char newCharacter = (char)generatedCharacterNumber;

            return newCharacter;
        }
    }
}

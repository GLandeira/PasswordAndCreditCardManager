using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordGenerator
{
    public class MayusCharacterGenerator : CharacterGenerator
    {
        protected override int MinimumAsciiThreshold => 65;

        protected override int MaximumAsciiThreshold => 90;

        public override char GenerateCharacter()
        {
            int generatedCharacterNumber = _thisRandom.Next(MinimumAsciiThreshold, MaximumAsciiThreshold + 1);
            char newCharacter = (char)generatedCharacterNumber;

            return newCharacter; 
        }
    }
}

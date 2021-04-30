using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PasswordGenerator
{
    public class SymbolCharacterGenerator : CharacterGenerator
    {
        protected override int MinimumAsciiThreshold => 32;

        protected override int MaximumAsciiThreshold => 126;

        private const int AMOUNT_OF_THRESHOLDS = 4;
        private const int MIN_ASCII_THRESHOLD_ONE = 32;
        private const int MAX_ASCII_THRESHOLD_ONE = 47;
        private const int MIN_ASCII_THRESHOLD_TWO = 58;
        private const int MAX_ASCII_THRESHOLD_TWO = 64;
        private const int MIN_ASCII_THRESHOLD_THREE = 91;
        private const int MAX_ASCII_THRESHOLD_THREE = 96;
        private const int MIN_ASCII_THRESHOLD_FOUR = 123;
        private const int MAX_ASCII_THRESHOLD_FOUR = 126;

        public override char GenerateCharacter()
        {
            int generatedCharacterNumber = GenerateCharacterBasedOnRandomThreshold();

            char newCharacter = (char)generatedCharacterNumber;

            return newCharacter;
        }

        private int GenerateCharacterBasedOnRandomThreshold()
        {
            int chosenThreshold = _thisRandom.Next(0, AMOUNT_OF_THRESHOLDS);

            switch (chosenThreshold)
            {
                case 0:
                    return _thisRandom.Next(MIN_ASCII_THRESHOLD_ONE, MAX_ASCII_THRESHOLD_ONE + 1);
                case 1:
                    return _thisRandom.Next(MIN_ASCII_THRESHOLD_TWO, MAX_ASCII_THRESHOLD_TWO + 1);
                case 2:
                    return _thisRandom.Next(MIN_ASCII_THRESHOLD_THREE, MAX_ASCII_THRESHOLD_THREE + 1);
                case 3:
                    return _thisRandom.Next(MIN_ASCII_THRESHOLD_FOUR, MAX_ASCII_THRESHOLD_FOUR + 1);
                default:
                    return -1;
            }
        }
    }
}

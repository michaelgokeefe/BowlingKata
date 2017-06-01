using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class BowlingGame
    {
        private int rollIndex = 0;
        private int[] rolls = new int[21];
       
        public void Roll(int numberOfPins)
        {
            if (numberOfPins < 0 || numberOfPins > 10)
                throw new ArgumentOutOfRangeException();

            rolls[rollIndex++] = numberOfPins;
        }

        public int CalculateScore()
        {
            int score = 0;
            int roll = 0; 

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + GetStrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + GetSpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    score += GetPinsKnockedDownInFrame(roll);
                    roll += 2;
                }
            }
            return score;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private int GetStrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private int GetSpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private int GetPinsKnockedDownInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }
    }
}

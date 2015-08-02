namespace BowlingGame
{
    public class Game
    {
        int score = 0;
        int currentRoll = 0;
        int[] rolls = new int[21];

        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int GetScore()
        {
            currentRoll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike())
                {
                    score += GetScoreForStrike();
                    currentRoll++;
                }
                else if (isSpare())
                {
                    score += GetFrameScoreForSpare();
                    currentRoll += 2;
                }
                else
                {
                    score += GetFrameScore();
                    currentRoll += 2;
                }
            }
            return score;
        }

        bool isStrike()
        {
            return rolls[currentRoll] == 10;
        }

        int GetScoreForStrike()
        {
            return rolls[currentRoll] + rolls[currentRoll + 1] + rolls[currentRoll + 2];
        }

        bool isSpare()
        {
            return rolls[currentRoll] + rolls[currentRoll + 1] == 10;
        }

        int GetFrameScoreForSpare()
        {
            return rolls[currentRoll] + rolls[currentRoll + 1] + rolls[currentRoll + 2];
        }

        int GetFrameScore()
        {
            return rolls[currentRoll] + rolls[currentRoll + 1];
        }


    }
}

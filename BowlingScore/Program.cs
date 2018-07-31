using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlinGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myScores = new int[21];
            myScores[20] = -1;
            bowlingTotal(myScores);
            // Check for a pulse, make sure the machine is stil alive
            for (int z = 0; z < 4; z++)
            {
                Console.Beep();
            }
        }
        /*
         * To Know:
         * A frame is a small round where the player has two chance to knock down all of the pins
         * 
         * Assumptions: 
         * Data will be recieved as an array
         * If a strike is rolled, then 10 is the first number in a frame and a zero is the second
         */
        public static int bowlingTotal(int[] scores)
        {
            int total = 0;
            // Use i+= 2 to move to a new frame each iteration
            for (int i = 0; i < scores.Length; i += 2)
            {
                // Only used for the current frame, reset to 0 every new frame
                int frameTotal = 0;
                // Inefficient to check this condition everytime
                if (i == 18 && scores[20] == -1)
                {
                    frameTotal = scores[i] + scores[i + 1] + scores[i + 2];
                }
                else
                {
                    // Get frame total score
                    frameTotal = scores[i] + scores[i + 1];
                    // Use if else to check for strike or spare
                    if (scores[i] == 10)
                    {
                        frameTotal += Strike(scores, i);
                    }
                    else if (frameTotal == 10)
                    {
                        frameTotal += Spare(scores, i);
                    }
                }

                total += frameTotal;

            }
            return total;
        }

        // Add the next two rolls to the current frame
        public static int Strike(int[] scores, int position)
        {
            int bonusPoints = 0;
            // Add next roll
            // Since te current frame was a strike, the next roll will be +2 away from current position
            bonusPoints += scores[position + 2];
            // If next roll also strike, then second roll will be +4 from current position
            if (scores[position + 2] == 10)
            {
                bonusPoints += scores[position + 4];
            }
            // If not, then second roll will be +3 from current position
            else
            {
                bonusPoints += scores[position + 3];
            }
            return bonusPoints;
        }

        // Just add the next roll to the current frame
        public static int Spare(int[] scores, int position)
        {
            int bonusPoints = 0;
            bonusPoints += scores[position + 2];
            return bonusPoints;
        }
    }
}


        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DartsAssistant.Models
{
    public class GameMode
    {
        /// <summary>
        /// The current type of game mode
        /// </summary>
        public EGameMode ModeType;

        /// <summary>
        /// Starting score for each player
        /// </summary>
        public int StartingScore;

        /// <summary>
        /// Checkout option
        /// </summary>
        public ESectorType Checkout;

        public GameMode(EGameMode mode, ESectorType checkout)
        {
            ModeType = mode;
            Checkout = checkout;
            StartingScore = GetStartingScore();
        }

        /// <summary>
        /// Determines starting score based on the current type of mode
        /// </summary>
        /// <returns>Starting score</returns>
        private int GetStartingScore()
        {
            switch (ModeType)
            {
                case EGameMode.Game301:
                    return 301;
                case EGameMode.Game501:
                    return 501;
                case EGameMode.Game701:
                    return 701;
                case EGameMode.Cricket:
                    return 0;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Determines whether the winning condition is met based on the current game mode, 
        /// the player's score, and their throws.
        /// </summary>
        /// <param name="score">The player's current score.</param>
        /// <param name="throws">A list of the player's throws, where the last throw is used for validation.</param>
        /// <returns>
        /// True if the winning condition is satisfied:
        /// False otherwise.
        /// </returns>
        public bool IsWinningConditionMet(int score, List<int> throws)
        {
            // Standard games (301, 501, 701)
            if (ModeType == EGameMode.Game501 || ModeType == EGameMode.Game301 || ModeType == EGameMode.Game701)
            {
                // The player's score must be exactly zero
                if (score == 0)
                {
                    // The last throw must meet the Checkout requirement
                    if (throws.Count > 0)
                    {
                        int lastThrow = throws[^1]; // The last throw

                        // Check if the last throw satisfies the Checkout requirement
                        return IsValidCheckout(lastThrow, Checkout);
                    }
                }
            }

            // For Cricket, check the appropriate rules
            if (ModeType == EGameMode.Cricket)
            {
                // In this simple example, we assume that reaching the score is enough to win
                // For more complex Cricket rules, additional checks are required
                if (score == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validates whether a given throw satisfies the checkout requirement for the specified sector type.
        /// </summary>
        /// <param name="points">The points scored in the throw.</param>
        /// <param name="requiredSector">The sector type required for a valid checkout (e.g., Double, Triple, Bullseye).</param>
        /// <returns>
        /// True if the throw meets the requirements of the specified sector type:
        /// - Double: Points must be even.
        /// - Triple: Points must be divisible by three.
        /// - Bullseye: Points must be 50 (Bullseye) or 25 (Half Bullseye).
        /// - Single: Any points are acceptable.
        /// False otherwise.
        /// </returns>
        private bool IsValidCheckout(int points, ESectorType requiredSector)
        {
            // Assume a simple example: the points and sector must match
            switch (requiredSector)
            {
                case ESectorType.Double:
                    return points % 2 == 0; // The points must be even

                case ESectorType.Triple:
                    return points % 3 == 0; // The points must be divisible by three

                case ESectorType.Bullseye:
                    return points == 50 || points == 25; // The points must be Bullseye (50) or Half Bullseye (25)

                case ESectorType.Single:
                default:
                    return true; // Any points are acceptable for the Single sector
            }
        }
    }
}

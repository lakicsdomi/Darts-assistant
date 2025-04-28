using DartsAssistant.Models;

namespace DartsAssistantTests
{
    [TestFixture]
    public class GameModeTests
    {
        [TestCase(EGameMode.Game301, 301)]
        [TestCase(EGameMode.Game501, 501)]
        [TestCase(EGameMode.Game701, 701)]
        [TestCase(EGameMode.Cricket, 0)]
        public void GetStartingScore_ShouldReturnCorrectScore(EGameMode mode, int expectedScore)
        {
            // Tests that the starting score is correctly set based on the game mode.
            var gameMode = new GameMode(mode, ESectorType.Single);
            int startingScore = gameMode.StartingScore;
            Assert.That(startingScore, Is.EqualTo(expectedScore));
        }

        [TestCase(0, new int[] { 50 }, ESectorType.Bullseye, true)]
        [TestCase(0, new int[] { 25 }, ESectorType.Bullseye, true)]
        [TestCase(0, new int[] { 40 }, ESectorType.Double, true)]
        [TestCase(0, new int[] { 39 }, ESectorType.Double, false)]
        [TestCase(0, new int[] { 45 }, ESectorType.Triple, true)]
        [TestCase(0, new int[] { 44 }, ESectorType.Triple, false)]
        [TestCase(0, new int[] { 20 }, ESectorType.Single, true)]
        [TestCase(10, new int[] { 20 }, ESectorType.Single, false)]
        public void IsWinningConditionMet_ShouldValidateWinningCondition(
            int score,
            int[] throws,
            ESectorType checkout,
            bool expectedResult)
        {
            // Verifies that the winning condition is met only when the score is zero 
            // and the last throw satisfies the checkout requirement.
            var gameMode = new GameMode(EGameMode.Game501, checkout);
            bool result = gameMode.IsWinningConditionMet(score, new List<int>(throws));
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(50, ESectorType.Bullseye, true)]
        [TestCase(25, ESectorType.Bullseye, true)]
        [TestCase(40, ESectorType.Double, true)]
        [TestCase(39, ESectorType.Double, false)]
        [TestCase(45, ESectorType.Triple, true)]
        [TestCase(44, ESectorType.Triple, false)]
        [TestCase(20, ESectorType.Single, true)]
        public void IsValidCheckout_ShouldValidateCheckout(int points, ESectorType sectorType, bool expectedResult)
        {
            // Ensures that the last throw meets the requirements for the specified sector type.
            var gameMode = new GameMode(EGameMode.Game501, sectorType);
            var result = gameMode.IsWinningConditionMet(0, new List<int> { points });
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IsWinningConditionMet_CricketMode_ShouldReturnTrueWhenScoreIsZero()
        {
            // Confirms that in Cricket mode, the winning condition is met when the score is zero.
            var gameMode = new GameMode(EGameMode.Cricket, ESectorType.Single);
            bool result = gameMode.IsWinningConditionMet(0, new List<int>());
            Assert.IsTrue(result);
        }

        [Test]
        public void IsWinningConditionMet_CricketMode_ShouldReturnFalseWhenScoreIsNotZero()
        {
            // Confirms that in Cricket mode, the winning condition is not met when the score is not zero.
            var gameMode = new GameMode(EGameMode.Cricket, ESectorType.Single);
            bool result = gameMode.IsWinningConditionMet(10, new List<int>());
            Assert.IsFalse(result);
        }
    }
}

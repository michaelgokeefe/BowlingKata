using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingKata;

namespace BowlingTests
{
    [TestClass]
    public class BowlingTests
    {
        private BowlingGame bowlingGame;

        [TestInitialize]
        public void Initialize()
        {
            bowlingGame = new BowlingGame();
        }

        [TestCleanup]
        public void Cleanup()
        {
            bowlingGame = null;
        }

        [TestMethod]
        public void CanCallRoll()
        {
            bowlingGame.Roll(1);
        }

        [TestMethod]
        public void CanCallCalculateScore()
        {
            bowlingGame.CalculateScore();
        }

        [TestMethod]
        public void StartingScoreIsZero()
        {
            Assert.AreEqual(0, bowlingGame.CalculateScore());
        }

        [TestMethod]
        public void RollingAddsToScore()
        {
            bowlingGame.Roll(1);
            bowlingGame.Roll(3);
            Assert.AreEqual(4, bowlingGame.CalculateScore());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotRollNegativePins()
        {
            bowlingGame.Roll(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotRollOverTenPins()
        {
            bowlingGame.Roll(11);
        }

        [TestMethod]
        public void CanCalculateAllZeroGame()
        {
            RollMany(0, 20);
            Assert.AreEqual(0, bowlingGame.CalculateScore());
        }
        
        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(1, 20);
            Assert.AreEqual(20, bowlingGame.CalculateScore());
        }

        [TestMethod]
        public void CanRollAGameWithoutSparesOrStrikes()
        {
            bowlingGame.Roll(1);
            bowlingGame.Roll(7);
            bowlingGame.Roll(9);
            bowlingGame.Roll(0);
            bowlingGame.Roll(5);
            RollMany(0, 15);
            Assert.AreEqual(22, bowlingGame.CalculateScore());
        }

        [TestMethod]
        public void CanRollAGameWithOneSpare()
        {
            bowlingGame.Roll(1);
            bowlingGame.Roll(9);
            bowlingGame.Roll(8);
            Assert.AreEqual(26, bowlingGame.CalculateScore());
        }

        [TestMethod]
        public void CanRollAGameWithOneStrike()
        {
            bowlingGame.Roll(10);
            bowlingGame.Roll(5);
            bowlingGame.Roll(6);
            Assert.AreEqual(32, bowlingGame.CalculateScore());
        }

        [TestMethod]
        public void CanRollAVariedGameWithStrikesAndSpares()
        {
            bowlingGame.Roll(1);
            bowlingGame.Roll(4);
            bowlingGame.Roll(4);
            bowlingGame.Roll(5);
            bowlingGame.Roll(6);
            bowlingGame.Roll(4);
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(10);
            bowlingGame.Roll(0);
            bowlingGame.Roll(1);
            bowlingGame.Roll(7);
            bowlingGame.Roll(3);
            bowlingGame.Roll(6);
            bowlingGame.Roll(4);
            bowlingGame.Roll(10);
            bowlingGame.Roll(2);
            bowlingGame.Roll(8);
            bowlingGame.Roll(6);
            Assert.AreEqual(133, bowlingGame.CalculateScore());

        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(10, 12);
            Assert.AreEqual(300, bowlingGame.CalculateScore());
        }

        private void RollMany(int numberOfPins, int numberOfRolls)
        {
            for (int i = 0; i < numberOfRolls; i++)
            {
                bowlingGame.Roll(numberOfPins);
            }
        }
    }
}

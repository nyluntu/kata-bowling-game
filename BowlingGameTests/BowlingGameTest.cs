using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    [TestFixture]
    public class BowlingGameTest
    {
        Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void RollBall()
        {
            Assert.DoesNotThrow(() => game.Roll(0));
        }

        [Test]
        public void PlayGutterGame()
        {
            RollBalls(20, 0);
            Assert.AreEqual(0, game.GetScore());
        }

        [Test]
        public void PlayDrunkGame()
        {
            RollBalls(20, 1);
            Assert.AreEqual(20, game.GetScore());
        }

        [Test]
        public void PlayOneFrame()
        {
            game.Roll(2);
            game.Roll(6);
            RollBalls(18, 0);
            Assert.AreEqual(8, game.GetScore());
        }

        [Test]
        public void PlayOneSpare()
        {
            game.Roll(3);
            game.Roll(7); // 15
            game.Roll(5);
            game.Roll(2); // 22
            RollBalls(16, 0);
            Assert.AreEqual(22, game.GetScore());
        }

        [Test]
        public void PlayOneStrike()
        {
            game.Roll(10); // 17
            game.Roll(4);
            game.Roll(3); // 24
            RollBalls(16, 0);
            Assert.AreEqual(24, game.GetScore());
        }

        [Test]
        public void PlayPerfectGame()
        {
            RollBalls(12, 10);
            Assert.AreEqual(300, game.GetScore());
        }

        [Test]
        public void RealGame()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);
            game.Roll(7);
            game.Roll(2);
            game.Roll(8);
            game.Roll(2);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);
            game.Roll(3);
            game.Roll(5);
            game.Roll(6);
            game.Roll(3);
            game.Roll(9);
            game.Roll(1);
            game.Roll(10);
            game.Roll(3);
            game.Roll(3);
            Assert.AreEqual(145, game.GetScore());
        }

        void RollBalls(int throws, int pins)
        {
            for (int i = 0; i < throws; i++)
                game.Roll(pins);
        }
        // Test one spare (if spare, add next roll points)
        // Test one Strike (if strike, add two next roll points)
        // Test perfect game (all strikes)
        // Acceptance test
    }
}

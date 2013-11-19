using CodoDojo29;
using Moq;
using NUnit.Framework;

namespace CodeDojo29.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IPlayer> _player1;
        private Mock<IPlayer> _player2;

        [SetUp]
        public void SetUp()
        {
            _player1 = new Mock<IPlayer>();
            _player2 = new Mock<IPlayer>();
        }

        [Test]
        public void PlayGame_EachPlayerDoesThreeTurns()
        {
            var game = new Game(_player1.Object, _player2.Object);

            game.PlayGame();

            _player1.Verify(x=>x.GetHand(), Times.Exactly(3));
            _player2.Verify(x=>x.GetHand(), Times.Exactly(3));
        }

        [Test]
        public void PlayHand_EachPlayerTakesATurn()
        {
            var game = new Game(_player1.Object, _player2.Object);

            game.PlayHand();

            _player1.Verify(x=>x.GetHand(), Times.Exactly(1));
            _player2.Verify(x=>x.GetHand(), Times.Exactly(1));
        }

        [TestCase("rock", "scissors")]
        [TestCase("scissors", "paper")]
        [TestCase("paper", "rock")]
        public void PlayHand_RockPaperScissorsRules_CanDeterminWinningConditions(string winner, string loser)
        {
            var game = new Game(_player1.Object, _player2.Object);

            _player1.Setup(x => x.GetHand()).Returns(winner);
            _player2.Setup(x => x.GetHand()).Returns(loser);
            
            var result = game.PlayHand();

            Assert.That(result.WinningPlayer, Is.EqualTo(1));
        }

        [TestCase("scissors", "rock")]
        [TestCase("paper", "scissors")]
        [TestCase("rock", "paper")]
        public void PlayHand_RockPaperScissorsRules_CanLosingWinningConditions(string winner, string loser)
        {
            var game = new Game(_player1.Object, _player2.Object);

            _player1.Setup(x => x.GetHand()).Returns(winner);
            _player2.Setup(x => x.GetHand()).Returns(loser);
            
            var result = game.PlayHand();

            Assert.That(result.WinningPlayer, Is.EqualTo(2));
        }

    }
}

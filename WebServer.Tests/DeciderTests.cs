using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace WebServer.Tests
{
    [TestFixture]
    public class DeciderTests
    {
        private Decider _decider;
        private Mock<IRandomNumberGenerator> _randomNumberGenerator;

        [SetUp]
        public void SetUp()
        {
            _randomNumberGenerator = new Mock<IRandomNumberGenerator>();
            _decider = new Decider(_randomNumberGenerator.Object);
        }

        [Test]
        public void MakeDecision_ReturnsAValidDecision()
        {
            var decision = _decider.MakeDecision();

            Assert.That(_decider.ValidDecisions.Contains(decision));
        }

        [Test]
        public void MakeThreeDecisions_ThreeRandomNumbers_GetThreeDifferentValues()
        {
            var decisions = new List<string>();
            
            _randomNumberGenerator.Setup(x => x.GenerateRandomNumberBetweenZeroAndTwo()).Returns(0);
            decisions.Add(_decider.MakeDecision());

            _randomNumberGenerator.Setup(x => x.GenerateRandomNumberBetweenZeroAndTwo()).Returns(1);
            decisions.Add(_decider.MakeDecision());

            _randomNumberGenerator.Setup(x => x.GenerateRandomNumberBetweenZeroAndTwo()).Returns(2);
            decisions.Add(_decider.MakeDecision());

            Assert.That(decisions.Contains("rock"));
            Assert.That(decisions.Contains("paper"));
            Assert.That(decisions.Contains("scissors"));
        }
    }
}
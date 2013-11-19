using System;
using CodoDojo29;
using Moq;
using NUnit.Framework;

namespace CodeDojo29.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        private Mock<IDoAHttpGet> _httpMock;
        private Player _player;

        [SetUp]
        public void SetUp()
        {
            _httpMock = new Mock<IDoAHttpGet>(); 
            _player = new Player(_httpMock.Object);
        }

        [Test]
        public void Ctor_GetterIsNull_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Player(null));
        }

        [Test]
        public void Ctor_CanConstructClient()
        {
            new Player(_httpMock.Object);
        }

        [Test]
        public void GetHand_ServerExists_ReturnsSomething()
        {
            _httpMock.Setup(x => x.GetUrl("http://localhost:8888/")).Returns("something");

            var response = _player.GetHand();

            Assert.That(response, Is.Not.Null);
        }

        [TestCase("stone")]
        [TestCase("paper")]
        [TestCase("scissors")]
        public void GetHand_WebServerReturnsStone_ReturnsStone(string testCase)
        {
            _httpMock.Setup(x => x.GetUrl("http://localhost:8888/")).Returns(testCase);

            var response = _player.GetHand();

            Assert.That(response, Is.EqualTo(testCase));
        }
    }
}

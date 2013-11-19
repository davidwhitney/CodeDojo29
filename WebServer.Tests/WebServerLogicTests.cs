using Moq;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace WebServer.Tests
{
    [TestFixture]
    public class WebServerLogicTests
    {
        private Mock<IPickRockPaperOrScissors> _mockDecider;
        private WebServerLogic _logicModule;
        private Browser _browser;

        [SetUp]
        public void Setup()
        {
            _mockDecider = new Mock<IPickRockPaperOrScissors>();
            _logicModule = new WebServerLogic(_mockDecider.Object);
            _browser = new Browser(configurator => configurator.Module(_logicModule));
        }

        [Test]
        public void GetRoot_ReturnsAHttpRepsonseWithAStringInTheBody()
        {
            var result = _browser.Get("/", with => with.HttpRequest());

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase("rock")]
        [TestCase("paper")]
        [TestCase("scissors")]
        public void GetRoot_AsksTheDeciderToMakeADecision_ReturnsIt(string gameSelection)
        {
            _mockDecider.Setup(x => x.MakeDecision()).Returns(gameSelection);

            var result = _browser.Get("/", with => with.HttpRequest());

            Assert.That(result.Body.AsString(), Is.EqualTo(gameSelection));
        }
    }
}

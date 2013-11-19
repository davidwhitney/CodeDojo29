using CodoDojo29;
using NUnit.Framework;

namespace CodeDojo29.Tests.IntegrationTests
{
    [TestFixture]
    public class DoAHttpGetTests
    {
        [Test]
        public void GetUrl_ServerIsRunning_ReturnsRoot()
        {
            var doer = new DoAHttpGet();

            var response = doer.GetUrl("http://localhost:8888/");

            Assert.That(response, Is.Not.Null);
        }
    }
}
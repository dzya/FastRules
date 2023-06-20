using FastRules.Engine.ReteNetwork;
using FastRules.Engine.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.ReteNetwork
{
    public class NetworkTests
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly Network _network;

        public NetworkTests() 
        {
            _network = new Network();
        }

        [Fact]
        public void Run_NewSessionEmptyFacts_NoException()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var fact = _fixture.Create<TestFact>();

            // Act
            var action = () => _network.Run(session, fact);

            // Assert
            action.Should().NotThrow();
        }
    }
}

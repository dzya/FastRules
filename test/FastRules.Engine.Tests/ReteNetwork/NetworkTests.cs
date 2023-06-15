using FastRules.Engine.ReteNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.ReteNetwork
{
    public class NetworkTests
    {
        private readonly Network _network;

        public NetworkTests() 
        {
            _network = new Network();
        }

        [Fact]
        public void Run_NewSessionEmptyFacts_NoException()
        {
            // Arrange
            var session = Mock.Of<ISession>();
            var fact = new Fact();

            // Act
            var action = () => _network.Run(session, fact);

            // Assert
            action.Should().NotThrow();
        }
    }
}

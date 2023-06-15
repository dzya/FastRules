using FastRules.Engine.ReteNetwork.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.ReteNetwork.Builders
{
    public class SessionBuilderTests
    {
        private readonly SessionBuilder _sessionBuilder;

        public SessionBuilderTests() 
        { 
            _sessionBuilder = new SessionBuilder();
        }

        [Fact]
        public void Build_ByDefault_NoExceptions()
        {
            // Arrange

            // Act
            var action = () => _sessionBuilder.Build();

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Build_ByDefault_ReturnsSession()
        {
            // Arrange

            // Act
            var session = _sessionBuilder.Build();

            // Assert
            session.Should().NotBeNull();
        }

    }
}

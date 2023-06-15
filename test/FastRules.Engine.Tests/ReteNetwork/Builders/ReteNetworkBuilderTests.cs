using FastRules.Engine.ReteNetwork.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.ReteNetwork.Builders
{
    public class ReteNetworkBuilderTests
    {
        private readonly ReteNetworkBuilder _builder;

        public ReteNetworkBuilderTests() 
        {
            _builder = new ReteNetworkBuilder();
        }

        [Fact]
        public void Build_ByDefault_NoExceptions()
        {
            // Arrange

            // Act
            var action = () => _builder.Build();

            // Assert
            action.Should().NotThrow();
        }
    }
}

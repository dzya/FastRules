using FastRules.Engine.ReteNetwork.Builders;
using FastRules.Engine.Rules;
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
        private readonly Mock<INodesBuilder> _nodesBuilder;

        public ReteNetworkBuilderTests() 
        {
            _nodesBuilder = new Mock<INodesBuilder>();
            _builder = new ReteNetworkBuilder(_nodesBuilder.Object);
        }

        [Fact]
        public void Build_ByDefault_NoExceptions()
        {
            // Arrange
            var items = new List<IRule<object>>();
            var rules = new Mock<IEnumerable<IRule<object>>>();
            rules.Setup(x => x.GetEnumerator()).Returns(items.GetEnumerator);

            // Act
            var action = () => _builder.Build(rules.Object);

            // Assert
            action.Should().NotThrow();
        }
    }
}

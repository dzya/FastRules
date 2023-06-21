using FastRules.Engine.ReteNetwork.Builders;
using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.ReteNetwork.Builders
{
    public class RootNodeBuilderTests
    {
        [Fact]
        public void Constructed_ByDefault_NoExceptions()
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => new RootNodeBuilder());

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Build_ByDefault_NoExceptions()
        {
            // Arrange
            var builder = new RootNodeBuilder();
            var rules = new Mock<IEnumerable<IRule<object>>>();

            // Act
            var exception = Record.Exception(() => builder.Build(rules.Object));

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Build_ByDefault_ReturnsRootNode()
        {
            // Arrange
            var builder = new RootNodeBuilder();
            var rules = new Mock<IEnumerable<IRule<object>>>();

            // Act
            var rootNode = builder.Build(rules.Object);

            // Assert
            rootNode.Should().NotBeNull();
        }
    }
}

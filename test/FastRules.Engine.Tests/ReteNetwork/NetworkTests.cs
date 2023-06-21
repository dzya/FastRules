using FastRules.Engine.ReteNetwork;
using FastRules.Engine.ReteNetwork.Builders;
using FastRules.Engine.Rules;
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
        private readonly Mock<INodesBuilder> _nodesBuilder;
        private readonly Network _network;
        public NetworkTests() 
        {
            _nodesBuilder = new Mock<INodesBuilder>();
            _network = new Network(_nodesBuilder.Object);
        }

        [Fact]
        public void Run_NewSessionEmptyFacts_NoException()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var fact = _fixture.Create<TestFact>();
            _network.Build();

            // Act
            var action = () => _network.Run(session, fact);

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Run_WithoutBuild_ThrowsException()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var fact = _fixture.Create<TestFact>();

            // Act
            var action = () => _network.Run(session, fact);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void AddRule_AfterBuild_ThrowsException()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var fact = _fixture.Create<TestFact>();
            var rule = new Mock<IRule<object>>();

            _network.Build();
           
            // Act
            var action = () => _network.AddRule(rule.Object);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Run_OneRuleIsPositive_ReturnsCorrectRuleAction()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var fact = _fixture.Create<TestFact>();

            var rule1 = new Mock<IRule<object>>();
            rule1.Setup(x => x.Fire(fact)).Returns((RuleAction)null);

            var ruleAction2 = _fixture.Create<RuleAction>();
            var rule2 = new Mock<IRule<object>>();
            rule2.Setup(x => x.Fire(fact)).Returns(ruleAction2);

            _network.AddRule(rule1.Object);
            _network.AddRule(rule2.Object);
            _network.Build();

            // Act
            var result = _network.Run(session, fact);

            // Assert
            result.Count().Should().Be(1);
            result.Should().Contain(ruleAction2);
        }

        [Fact]
        public void Run_MultipleRulesArePositive_ReturnsMultipleRuleActions()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var fact = _fixture.Create<TestFact>();

            var ruleAction1 = _fixture.Create<RuleAction>();
            var rule1 = new Mock<IRule<object>>();
            rule1.Setup(x => x.Fire(fact)).Returns(ruleAction1);

            var ruleAction2 = _fixture.Create<RuleAction>();
            var rule2 = new Mock<IRule<object>>();
            rule2.Setup(x => x.Fire(fact)).Returns(ruleAction2);

            _network.AddRule(rule1.Object);
            _network.AddRule(rule2.Object);
            _network.Build();

            // Act
            var result = _network.Run(session, fact);

            // Assert
            result.Count().Should().Be(2);
            result.Should().Contain(ruleAction1);
            result.Should().Contain(ruleAction2);
        }

        [Fact]
        public void Run_AllRulesAreNegative_ReturnsEmptyRuleActions()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var fact = _fixture.Create<TestFact>();

            var rule1 = new Mock<IRule<object>>();
            rule1.Setup(x => x.Fire(fact)).Returns((RuleAction)null);

            var rule2 = new Mock<IRule<object>>();
            rule2.Setup(x => x.Fire(fact)).Returns((RuleAction)null);

            _network.AddRule(rule1.Object);
            _network.AddRule(rule2.Object);
            _network.Build();

            // Act
            var result = _network.Run(session, fact);

            // Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public void AddRule_NonEmptyRule_NoException()
        {
            // Arrange
            var session = Mock.Of<ISession>(MockBehavior.Strict);
            var rule = Mock.Of<IRule<object>>(MockBehavior.Strict);

            // Act
            var action = () => _network.AddRule(rule);

            // Assert
            action.Should().NotThrow();
        }
    }
}

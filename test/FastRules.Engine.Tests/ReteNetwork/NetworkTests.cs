using FastRules.Engine.ReteNetwork;
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

            // Act
            var result = _network.Run(session, fact);

            // Assert
            result.Should().Contain(ruleAction2);
        }

        [Fact]
        public void AddRule_NonEmptyRule_NoExceptio1n()
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

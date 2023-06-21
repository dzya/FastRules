using Castle.Components.DictionaryAdapter;
using FastRules.Engine.Conditions;
using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.Rules
{
    public class ConditionRuleTests
    {
        private readonly Fixture _fixture;

        public ConditionRuleTests() 
        {
            _fixture = new Fixture();
        } 

        [Fact]
        public void Constructed_WithDefaultRule_NoExceptions()
        {
            // Arrange
            var condition = Mock.Of<ICondition<object>>();
            var ruleAction = _fixture.Create<RuleAction>();

            // Act
            var exception = Record.Exception(() => new ConditionRule<object>(condition, ruleAction));

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Constructed_WithSomeCondition_GetsThisCondition()
        {
            // Arrange
            var condition = Mock.Of<ICondition<object>>();
            var ruleAction = _fixture.Create<RuleAction>();

            // Act
            var rule = new ConditionRule<object>(condition, ruleAction);

            // Assert
            rule.Condition.Should().Be(condition);
        }

        [Fact]
        public void Fire_WithAnyFact_NoExceptions()
        {
            // Arrange
            var ruleAction = _fixture.Create<RuleAction>();
            var fact = Mock.Of<object>();
            var condition = Mock.Of<ICondition<object>>();
            var rule = new ConditionRule<object>(condition, ruleAction);

            // Act
            var exception = Record.Exception(() => rule.Fire(fact));

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Fire_WithNegativeFact_ReturnsNullAction()
        {
            // Arrange
            var ruleAction = _fixture.Create<RuleAction>();
            var fact = Mock.Of<object>();
            var condition = new Mock<ICondition<object>>();
            condition.Setup(x => x.IsPositive(fact)).Returns(false);

            var rule = new ConditionRule<object>(condition.Object, ruleAction);

            // Act
            var result = rule.Fire(fact);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Fire_WithPositiveFact_ReturnsAction()
        {
            // Arrange
            var ruleAction = _fixture.Create<RuleAction>();
            var fact = Mock.Of<object>();
            var condition = new Mock<ICondition<object>>();
            condition.Setup(x => x.IsPositive(fact)).Returns(true);

            var rule = new ConditionRule<object>(condition.Object, ruleAction);

            // Act
            var result = rule.Fire(fact);

            // Assert
            result.Should().Be(ruleAction);
        }
    }
}

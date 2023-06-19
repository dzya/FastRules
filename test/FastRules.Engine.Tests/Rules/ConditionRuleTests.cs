using Castle.Components.DictionaryAdapter;
using FastRules.Engine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICondition = FastRules.Engine.Conditions.ICondition;

namespace FastRules.Engine.Tests.Rules
{
    public class ConditionRuleTests
    {
        [Fact]
        public void Constructed_WithDefaultRule_NoExceptions()
        {
            // Arrange
            var condition = Mock.Of<ICondition>();

            // Act
            var exception = Record.Exception(() => new ConditionRule(condition));

            // Assert
            exception.Should().BeNull();
        }
    }
}

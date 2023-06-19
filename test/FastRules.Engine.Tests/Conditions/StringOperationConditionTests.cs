using FastRules.Engine.Conditions;
using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.Conditions
{
    public class StringOperationConditionTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void Constructed_ByDefault_NoExceptions() 
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => new StringOperationCondition());

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void IsPositive_OperationNotSet_ThrowsInvalidOperationException()
        {
            // Arrange
            var stringCondition = new StringOperationCondition();
            var fact = _fixture.Create<Fact>();

            // Act
            var exception = Record.Exception(() => stringCondition.IsPositive(fact));

            // Assert
            exception.Should().NotBeNull(); 
            exception.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public void IsPositive_OperationOperandsAreNotSet_ThrowsException()
        {
            // Arrange
            var stringCondition = new StringOperationCondition();
            var fact = _fixture.Create<Fact>();
            stringCondition.Operation = new StringEqualsOperation();

            // Act
            var exception = Record.Exception(() => stringCondition.IsPositive(fact));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public void IsPositive_OperationIsSet_NoExceptions()
        {
            // Arrange
            var stringCondition = new StringOperationCondition();
            var fact = _fixture.Create<Fact>();
            stringCondition.Operation = new StringEqualsOperation();
            stringCondition.GetLeftOperand = (x) => { return "Name"; };
            stringCondition.GetRightOperand = (x) => { return "Value"; };

            // Act
            var exception = Record.Exception(() => stringCondition.IsPositive(fact));

            // Assert
            exception.Should().BeNull();
        }

        [Theory]
        [InlineData("Name", "Name")]
        [InlineData(null, null)]
        public void IsPositive_OperationOperandsEquals_ReturnsTrue(string left, string right)
        {
            // Arrange
            var stringCondition = new StringOperationCondition();
            var fact = _fixture.Create<Fact>();
            stringCondition.Operation = new StringEqualsOperation();
            stringCondition.GetLeftOperand = (x) => { return left; };
            stringCondition.GetRightOperand = (x) => { return right; };

            // Act
            var result = stringCondition.IsPositive(fact);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("Name1", "Name2")]
        [InlineData("Name1", null)]
        [InlineData(null, "Name2")]
        public void IsPositive_OperationOperandsNotEquals_ReturnsFalse(string left, string right)
        {
            // Arrange
            var stringCondition = new StringOperationCondition();
            var fact = _fixture.Create<Fact>();
            stringCondition.Operation = new StringEqualsOperation();
            stringCondition.GetLeftOperand = (x) => { return left; };
            stringCondition.GetRightOperand = (x) => { return right; };

            // Act
            var result = stringCondition.IsPositive(fact);

            // Assert
            result.Should().BeFalse();
        }
    }
}

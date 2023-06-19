using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FastRules.Engine.Tests.Operations
{
    public class StringEqualsOperationTest
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void Constructed_ByDefault_NoExceptions()
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => new StringEqualsOperation());

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Id_Always_ReturnsStringEquals()
        {
            // Arrange
            var operation = new StringEqualsOperation();

            // Act
            var result = operation.Id;

            // Assert
            result.Should().Be(OperationIds.StringEquals);
        }

        [Theory]
        [InlineData("ValueA", "ValueA")]
        [InlineData(null, null)]
        public void Result_OperandsAreEqual_ReturnsTrue(string leftOperand, string rightOperand)
        {
            // Arrange
            var operation = new StringEqualsOperation
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };
            

            // Act
            var result = operation.Result;

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("ValueA", "ValueB")]
        [InlineData(null, "ValueB")]
        [InlineData("ValueA", null)]
        public void Result_OperandsNotEqual_ReturnsFalse(string leftOperand, string rightOperand)
        {
            // Arrange
            var operation = new StringEqualsOperation
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };

            // Act
            var result = operation.Result;

            // Assert
            result.Should().BeFalse();
        }
    }
}

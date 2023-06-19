using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.Operations
{
    public class IntEqualsOperationTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void Constructed_ByDefault_NoExceptions()
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => new IntEqualsOperation());

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Id_Always_ReturnsIntEquals()
        {
            // Arrange
            var operation = new IntEqualsOperation();

            // Act
            var result = operation.Id;

            // Assert
            result.Should().Be(OperationIds.IntEquals);
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(default(int), default(int))]
        public void Result_OperandsAreEqual_ReturnsTrue(int leftOperand, int rightOperand)
        {
            // Arrange
            var operation = new IntEqualsOperation
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
        [InlineData(10, 20)]
        [InlineData(default(int), 20)]
        [InlineData(10, default(int))]
        public void Result_OperandsNotEqual_ReturnsFalse(int leftOperand, int rightOperand)
        {
            // Arrange
            var operation = new IntEqualsOperation
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

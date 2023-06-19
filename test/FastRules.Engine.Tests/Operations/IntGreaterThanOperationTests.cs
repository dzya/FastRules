using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.Operations
{
    public class IntGreaterThanOperationTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void Constructed_ByDefault_NoExceptions()
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => new IntGreaterThanOperation());

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Id_Always_ReturnsIntGreaterThan()
        {
            // Arrange
            var operation = new IntGreaterThanOperation();

            // Act
            var result = operation.Id;

            // Assert
            result.Should().Be(OperationIds.IntGreaterThan);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(default(int), 1)]
        [InlineData(20, 20)]
        public void Result_LeftOperandIsLessThanOrEqual_ReturnsFalse(int leftOperand, int rightOperand)
        {
            // Arrange
            var operation = new IntGreaterThanOperation
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };


            // Act
            var result = operation.Result;

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(20, 1)]
        [InlineData(10, default(int))]
        public void Result_LeftOperandIsGreater_ReturnsTrue(int leftOperand, int rightOperand)
        {
            // Arrange
            var operation = new IntGreaterThanOperation
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand
            };

            // Act
            var result = operation.Result;

            // Assert
            result.Should().BeTrue();
        }
    }
}

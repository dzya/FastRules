using FastRules.Engine.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRules.Engine.Tests.Operations
{
    public class IntLessThanOperationTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void Constructed_ByDefault_NoExceptions()
        {
            // Arrange

            // Act
            var exception = Record.Exception(() => new IntLessThanOperation());

            // Assert
            exception.Should().BeNull();
        }

        [Fact]
        public void Id_Always_ReturnsIntLessThan()
        {
            // Arrange
            var operation = new IntLessThanOperation();

            // Act
            var result = operation.Id;

            // Assert
            result.Should().Be(OperationIds.IntLessThan);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(default(int), 1)]
        public void Result_LeftOperandLessThan_ReturnsTrue(int leftOperand, int rightOperand)
        {
            // Arrange
            var operation = new IntLessThanOperation
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
        [InlineData(20, 1)]
        [InlineData(20, 20)]
        [InlineData(10, default(int))]
        public void Result_LeftOperandMoreOrEqual_ReturnsFalse(int leftOperand, int rightOperand)
        {
            // Arrange
            var operation = new IntLessThanOperation
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

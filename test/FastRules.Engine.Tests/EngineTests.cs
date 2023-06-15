using System.Data;

namespace FastRules.Engine.Tests
{
    public class EngineTests
    {
        private readonly Engine _engine;
        private readonly Fixture _auto;

        public EngineTests() {
            _engine = new Engine();
            _auto = new Fixture();
        }

        [Fact]
        public void Run_EmptyFactEmptyRules_ReturnEmptyActions()
        {
            // Arrange
            var fact = new Fact();

            // Act
            var result = _engine.Run(fact);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public void Build_EmptyFactEmptyRules_NoExceptions()
        {
            // Arrange
            var fact = new Fact();

            // Act
            var action = () => _engine.Build();

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void AddRule_AnyRule_NoExceptions()
        {
            // Arrange
            var rule = new Mock<IRule>();

            // Act
            var action = () => _engine.AddRule(rule.Object);

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Run_WithoutBuildAfterAddingRule_ThrowsException()
        {
            // Arrange
            var fact = new Fact();
            var rule = new Mock<IRule>();
            _engine.AddRule(rule.Object);

            // Act
            var action = () => _engine.Run(fact);

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Run_WithBuildAfterAddingRule_NoExceptions()
        {
            // Arrange
            var fact = new Fact();
            var rule = new Mock<IRule>();
            _engine.AddRule(rule.Object);
            _engine.Build();

            // Act
            var action = () => _engine.Run(fact);

            // Assert
            action.Should().NotThrow();
        }

        [Fact]
        public void GetRules_RulesAdded_ReturnsAllRules()
        {
            // Arrange
            var rule1 = new Mock<IRule>();
            var rule2 = new Mock<IRule>();
            var rule3 = new Mock<IRule>();
            _engine.AddRule(rule1.Object);
            _engine.AddRule(rule2.Object);
            _engine.AddRule(rule3.Object);

            // Act
            var rulesCount = _engine.Rules.Count();

            // Assert
            rulesCount.Should().Be(3);
        }
    }
}
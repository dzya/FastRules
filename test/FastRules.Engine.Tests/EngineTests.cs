namespace FastRules.Engine.Tests
{
    public class EngineTests
    {
        private readonly Engine engine;

        public EngineTests() {
            engine = new Engine();
        }

        [Fact]
        public void Run_EmptyFactEmptyRules_ReturnEmptyActions()
        {
            // Arrange
            var fact = new Fact();

            // Act
            var result = engine.Run(fact);

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
            var action = () => engine.Build();

            // Assert
            action.Should().NotThrow();
        }

    }
}
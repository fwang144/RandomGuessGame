using FluentAssertions;


[TestClass]
public class SimpleRandomTests
{
    [TestMethod]
    public void Easy_Success()
    {
        // Arrange
        int a = 5;
        bool expected = true;

        // Act
        bool result = SimpleRandom.Easy(a);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void Easy_Failed()
    {
        // Arrange
        int a = 11;
        bool expected = 11 <= 10;

        // Act
        bool result = SimpleRandom.Easy(a);

        // Assert
        result.Should().Be(expected);
    }
    

}

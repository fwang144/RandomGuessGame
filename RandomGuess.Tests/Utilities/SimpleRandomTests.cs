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
        bool result = SimpleRandom.ValidEasy(a);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void Medium_Success()
    {
        // Arrange
        int a = 15;
        bool expected = true;

        // Act
        bool result = SimpleRandom.ValidMedium(a);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void Hard_Success()
    {
        // Arrange
        int a = 500;
        bool expected = true;

        // Act
        bool result = SimpleRandom.ValidHard(a);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void Easy_Failed()
    {
        // Arrange
        int a = 11;
        bool expected = false;

        // Act
        bool result = SimpleRandom.ValidEasy(a);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void Hard_Negative_Failed()
    {
        // Arrange
        int a = -100;
        bool expected = false;

        //Act
        bool result = SimpleRandom.ValidHard(a);

        //Assert
        result.Should().Be(expected);

    }
    

}

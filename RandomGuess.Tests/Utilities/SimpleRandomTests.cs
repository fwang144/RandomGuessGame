using FluentAssertions;
using RandomGuess;

namespace RandomGuessTests;

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
    
    [TestMethod]
    public void CheckGuess_Hard_TooLow()
    {
        // Arrange
        DifficultyLevel difficulty = DifficultyLevel.Hard;
        int answer = 250;
        int guess = 125;
        ComparisonResult expected = ComparisonResult.TooLow;

        // Act
        var result = SimpleRandom.CheckGuess(difficulty, answer, guess);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void CheckGuess_Medium_TooHigh()
    {
        // Arrange
        DifficultyLevel difficulty = DifficultyLevel.Medium;
        int answer = 25;
        int guess = 32;
        ComparisonResult expected = ComparisonResult.TooHigh;

        // Act
        var result = SimpleRandom.CheckGuess(difficulty, answer, guess);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void CheckGuess_Easy_Equal()
    {
        // Arrange
        DifficultyLevel difficulty = DifficultyLevel.Easy;
        int answer = 5;
        int guess = 5;
        ComparisonResult expected = ComparisonResult.Equal;

        // Act
        var result = SimpleRandom.CheckGuess(difficulty, answer, guess);

        // Assert
        result.Should().Be(expected);
    }

    [TestMethod]
    public void CheckGuess_InvalidEasyGuess_ThrowsException()
    {
        // Arrange
        DifficultyLevel difficulty = DifficultyLevel.Easy;
        int answer = 10;
        int guess = 15;

        // Act
        // https://fluentassertions.com/exceptions/
        // The "Act" method is a lambda expression, ask Copilot "what is a lambda expression in C#"
        // Follow-up question: "Are lambda expressions in C# like the ones in Python?"
        var act = () => SimpleRandom.CheckGuess(difficulty, answer, guess);

        // Assert
        // We wrote this test case using string formatting, as we change the test variables, we don't need to remember to change the expected message!
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"The {difficulty} guess of {guess} is not within range (0, 10]*");
    }

    [TestMethod]
    public void CheckGuess_InvalidMediumGuess_ThrowsException()
    {
        // Arrange
        DifficultyLevel difficulty = DifficultyLevel.Medium;
        int answer = 75;
        int guess = 1200;

        // Act
        // https://fluentassertions.com/exceptions/
        // The "Act" method is a lambda expression, ask Copilot "what is a lambda expression in C#"
        // Follow-up question: "Are lambda expressions in C# like the ones in Python?"
        var act = () => SimpleRandom.CheckGuess(difficulty, answer, guess);

        // Assert
        // We wrote this test case using string formatting, as we change the test variables, we don't need to remember to change the expected message!
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"The {difficulty} guess of {guess} is not within range (0, 100]*");
    }

    [TestMethod]
    public void CheckGuess_InvalidHardGuess_ThrowsException()
    {
        // Arrange
        DifficultyLevel difficulty = DifficultyLevel.Hard;
        int answer = 250;
        int guess = 1200;

        // Act
        // https://fluentassertions.com/exceptions/
        // The "Act" method is a lambda expression, ask Copilot "what is a lambda expression in C#"
        // Follow-up question: "Are lambda expressions in C# like the ones in Python?"
        var act = () => SimpleRandom.CheckGuess(difficulty, answer, guess);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"The {difficulty} guess of {guess} is not within range (0, 1000]*");
    }

    [TestMethod]
    public void CheckGuess_InvalidInsaneGuess_ThrowsException()
    {
        // Arrange
        DifficultyLevel difficulty = DifficultyLevel.Insane;
        int answer = 5000;
        int guess = 120000;

        // Act
        // https://fluentassertions.com/exceptions/
        // The "Act" method is a lambda expression, ask Copilot "what is a lambda expression in C#"
        // Follow-up question: "Are lambda expressions in C# like the ones in Python?"
        var act = () => SimpleRandom.CheckGuess(difficulty, answer, guess);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage($"The {difficulty} guess of {guess} is not within range (0, 100000]*");
    }
}

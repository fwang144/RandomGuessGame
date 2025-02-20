
public class SimpleRandom
{
    /// <summary>
    /// Check if the guess is a valid easy guess in the range (0, 10].
    /// </summary>
    /// <param name="guess">The guess.</param>
    /// <returns>Returns true if valid, false if invalid.</returns>
    public static bool ValidEasy(int guess)
    {
        // (0, 10]   
        return 0 < guess && guess <= 10;
    }

    /// <summary>
    /// Check if the guess is a valid medium guess in the range (0, 100].
    /// </summary>
    /// <param name="guess">The guess.</param>
    /// <returns>Returns true if valid, false if invalid.</returns>
    public static bool ValidMedium(int guess)
    {
        // (0, 100]   
        return 0 < guess && guess <= 100;
    }

    /// <summary>
    /// Check if the guess is a valid hard guess in the range (0, 1000].
    /// </summary>
    /// <param name="guess">The guess.</param>
    /// <returns>Returns true if valid, false if invalid.</returns>
    public static bool ValidHard(int guess)
    {
        // (0, 1000]   
        return 0 < guess && guess <= 1000;
    }

    /// <summary>
    /// Checks a guess for a specific difficulty level against the known answer.
    /// </summary>
    /// <param name="difficulty">The difficulty level.</param>
    /// <param name="answer">The randomly generated answer.</param>
    /// <param name="guess">The guess from the user.</param>
    /// <returns>The comparison result of the <paramref name="guess"/> against the <paramref name="answer"/>.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ComparisonResult CheckGuess(DifficultyLevel difficulty, int answer, int guess)
    {
        // Hints... https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
        throw new NotImplementedException();
    }
}
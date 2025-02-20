/// <summary>
/// The result of comparing a guess against the answer.
/// </summary>
public enum ComparisonResult
{
    /// <summary>
    /// The guess is too low compared to the answer.
    /// </summary>
    TooLow,

    /// <summary>
    /// The guess is equal to the answer.
    /// </summary>
    Equal,

    /// <summary>
    /// The guess is too high compared to the answer.
    /// </summary>
    TooHigh
}
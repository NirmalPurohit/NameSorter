namespace NameSorter.ExceptionHandling;

/// <summary>
/// Contains the custom Exception for the scenario of invalid <see cref="PersonName"/> .
/// </summary>
/// <param name="message"></param>
public sealed class InvalidNameException(string message) : Exception(message);

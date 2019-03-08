using System;
using System.Text.RegularExpressions;

/// <summary>
/// Word class.
/// Used to check if a word is a palidrome by passing in a string/word to a class instance.
/// </summary>
public class Word
{
	String originalWord;
	public Word(String inputString)
	{
		this.originalWord = inputString;
	}

	/// <summary>
	/// Checks if the supplied string is a palidrome
	/// </summary>
	/// <remarks>
	/// Support for checking if the string is an actual word should be added.
	/// Support for checking if the string is null or empty should be added. 
	/// </remarks>
	public bool IsPalindrome()
	{
		char[] charArray = originalWord.ToCharArray();
		Array.Reverse(charArray);
		String newWord = new String(charArray);

		return originalWord == newWord;
	}
}

/// <summary>
/// Sentence class.
/// Used to check if a sentence is a palidrome by passing in a string/word to a class instance.
/// </summary>
public class Sentence
{
	String originalSentence;
	public Sentence(String inputString)
	{
		this.originalSentence = inputString;
	}

	/// <summary>
	/// Removes spaces from a string by using the replace method.
	/// </summary>
	public String removeSpaces(String inputString)
	{
		String result = (inputString.Contains(" ")) ? inputString.Replace(" ", string.Empty) : inputString;

		return result;
	}

	/// <summary>
	/// Removes special characers from a string by using the replace method.
	/// </summary>
	public String removeSpecialCharacters(String inputString)
	{
		bool hasSpecialCharacter = Regex.IsMatch(inputString.ToLower(), @"[^0-9a-zA-Z']+");
		String result = (hasSpecialCharacter) ? Regex.Replace(inputString.ToLower(), @"[^0-9a-zA-Z']*", "") : inputString;
		
        return result;
	}

	/// <summary>
	/// Sanitizes a string by removing all of the special characters and spaces from it via custom methods. 
	/// </summary>
	public String sanitizeString(String inputString)
	{
		return this.removeSpecialCharacters(this.removeSpaces(inputString));
	}

	/// <summary>
	/// Sanitizes a string by removing all of the special characters and spaces from it via custom methods. 
	/// </summary>
	public String sentenceModified(String inputString)
	{
		return this.sanitizeString(inputString);
	}

	/// <summary>
	/// Reverses a string.  
	/// </summary>
	public String sentenceReversed(String inputString)
	{
		char[] sentenceArray = this.sanitizeString(inputString).ToCharArray();
		Array.Reverse(sentenceArray);
		string result = new String(sentenceArray);
        
		return result;
	}

	/// <summary>
	/// Checks if the supplied string is a palidrome
	/// </summary>
	/// <remarks>
	/// Support for checking if the string is an actual word should be added.
	/// Support for checking if the string is null or empty should be added. 
	/// </remarks>
	public bool IsPalidrome()
	{
		return this.sentenceModified(originalSentence) == this.sentenceReversed(originalSentence);
	}
}

public class Program
{
	public static void Main()
	{
		Word word = new Word("deleveled");
		Console.WriteLine(word.IsPalindrome());
		Sentence sentence = new Sentence("Was It A Rat I Saw?");
		Console.WriteLine(sentence.IsPalidrome());
	}
}
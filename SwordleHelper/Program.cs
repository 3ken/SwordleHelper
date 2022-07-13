using SwordleHelper;

var wordsList = Words.Get;
Console.WriteLine("What letters is not in the word?");
var lettersNotInWordInput = Console.ReadLine();
Console.WriteLine("What letters is in the word?");
var lettersInWordInput = Console.ReadLine();

var lettersNotInWord = !string.IsNullOrEmpty(lettersNotInWordInput) ? lettersNotInWordInput.ToCharArray() : Array.Empty<char>();
var lettersInWord = !string.IsNullOrEmpty(lettersInWordInput) ? lettersInWordInput.ToCharArray() : Array.Empty<char>();

wordsList = lettersInWord.Aggregate(wordsList, (current, letterInWord) => current.Where(w => w.Contains(letterInWord)).ToArray());
wordsList = lettersNotInWord.Aggregate(wordsList, (current, letterNotInWord) => current.Where(w => !w.Contains(letterNotInWord)).ToArray());

Console.WriteLine("Suggestions: ");
foreach (var word in wordsList)
    Console.WriteLine(word);

Console.ReadLine();

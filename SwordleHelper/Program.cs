using SwordleHelper;

var wordsList = Words.Get;
Console.WriteLine("What letters is not in the word?");
var lettersNotInWordInput = Console.ReadLine();
Console.WriteLine("What letters is in the word?");
var lettersInWordInput = Console.ReadLine();
Console.WriteLine("What letters do you know position of?");
var exactPositionInput = Console.ReadLine();

var lettersNotInWord = !string.IsNullOrEmpty(lettersNotInWordInput) ? lettersNotInWordInput.ToCharArray() : Array.Empty<char>();
var lettersInWord = !string.IsNullOrEmpty(lettersInWordInput) ? lettersInWordInput.ToCharArray() : Array.Empty<char>();
var exactPosition = !string.IsNullOrEmpty(exactPositionInput) ? exactPositionInput.ToCharArray() : Array.Empty<char>();


wordsList = lettersInWord.Aggregate(wordsList, (current, letterInWord) => current.Where(w => w.Contains(letterInWord)).ToArray());
wordsList = lettersNotInWord.Aggregate(wordsList, (current, letterNotInWord) => current.Where(w => !w.Contains(letterNotInWord)).ToArray());

var index = 0;
foreach (var exactPositionChar in exactPosition)
{ 
    if (!char.IsLetter(exactPositionChar))
    {
        index++;
        continue;
    }

    wordsList = wordsList.Where(w => w.IndexOf(exactPositionChar) == index).ToArray();
    index++;
}
Console.WriteLine("Suggestions: ");
foreach (var word in wordsList)
    Console.WriteLine(word);

Console.ReadLine();

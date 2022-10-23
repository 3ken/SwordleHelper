using SwordleHelper;

var wordsList = Words.Get;
wordsList = wordsList.Where(x => !(x.Contains("-") || x.Contains(" "))).ToArray();
var done = false;
while(!done){
    Console.WriteLine("What letters is not in the word?");
    var lettersNotInWordInput = Console.ReadLine();
    Console.WriteLine("What letters is in the word?");
    var lettersInWordInput = Console.ReadLine();
    Console.WriteLine("What letters do you know position of?");
    var exactPositionInput = Console.ReadLine();
    Console.WriteLine("What letters do you know is not its position?");
    var exactNotPositionInput = Console.ReadLine();

    var lettersNotInWord = !string.IsNullOrEmpty(lettersNotInWordInput) ? lettersNotInWordInput.ToCharArray() : Array.Empty<char>();
    var lettersInWord = !string.IsNullOrEmpty(lettersInWordInput) ? lettersInWordInput.ToCharArray() : Array.Empty<char>();
    var exactPosition = !string.IsNullOrEmpty(exactPositionInput) ? exactPositionInput.ToCharArray() : Array.Empty<char>();
    var exactNotPosition = !string.IsNullOrEmpty(exactNotPositionInput) ? exactNotPositionInput.ToCharArray() : Array.Empty<char>();

    wordsList = lettersInWord.Aggregate(wordsList, (current, letterInWord) => current.Where(w => w.Contains(letterInWord)).ToArray());
    wordsList = lettersNotInWord.Aggregate(wordsList, (current, letterNotInWord) => current.Where(w => !w.Contains(letterNotInWord)).ToArray());

    var index = 0;
    foreach (var exactPositionChar in exactPosition)
    { 
        if (char.IsLetter(exactPositionChar))
            wordsList = wordsList.Where(w => exactPositionChar == w[index]).ToArray();
        index++;
    }
    var index2 = 0;
    foreach (var exactNotPositionChar in exactNotPosition)
    { 
        if (char.IsLetter(exactNotPositionChar))
            wordsList = wordsList.Where(w => exactNotPositionChar != w[index2]).ToArray();
        index2++;
    }
    Console.WriteLine("Suggestions: ");
    foreach (var word in wordsList)
        Console.WriteLine(word);

    Console.WriteLine("Did you solve it? y/n ");   
    var answer = Console.ReadLine(); 
    if(answer!.Equals("y", StringComparison.InvariantCultureIgnoreCase))
        done = true;
}

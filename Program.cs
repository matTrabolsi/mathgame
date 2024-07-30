using System.Runtime.InteropServices;
using math_game;

MathGameLogic mathGame = new();
Random random = new();

int firstNumber, secondNumber, userMenuSelection, score = 0;
bool gameOver = false;







static DiffcultyLevel ChangeDifficulty()
{
    int userSelection = 0;

    Console.WriteLine("please enter a difficulty level");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Hard");

    while(!int.TryParse(Console.ReadLine(), out userSelection) || (userSelection < 1 || userSelection > 3) )
    {
        Console.WriteLine("please enter a valid option 1-3");
    }

    return userSelection switch
    {
        1 => DiffcultyLevel.Easy,
        2 => DiffcultyLevel.Medium,
        3 => DiffcultyLevel.Hard,
        _ => DiffcultyLevel.Easy,
    };
}

static void DisplayMathGameQuestion(int firstNumber, int secondNumber, char operation)
{
    Console.WriteLine($"{firstNumber} {operation} {secondNumber} = ??");        
}

static int GetUserMenuSelection(MathGameLogic mathGame)
{
    int selection = -1;
    mathGame.ShowMenu();

    return selection;
}


public enum DiffcultyLevel
{
    Easy = 45,
    Medium = 30,
    Hard = 15
}
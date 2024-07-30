using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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

    while(selection < 1 || selection > 8)
    {
        while(!int.TryParse(Console.ReadLine(), out selection))
        {
            Console.WriteLine("Please enter a valid option 1-8");
        }
        if(!(selection >= 1 && selection <= 8))
        {
            Console.WriteLine("Please enter a valid option 1-8");
        }
    }

    return selection;
}

static async Task<int?> GetUserResponse(DiffcultyLevel  difficulty)
{
    int response = 0;
    int timeout = (int)difficulty;
    
    Stopwatch stopwatch = new();
    stopwatch.Start();
    Task<string> getUserInputTask = Task.Run(() => Console.ReadLine());

    try
    {
        string? result = await Task.WhenAny(getUserInputTask, Task.Delay(timeout * 1000)) == getUserInputTask ? getUserInputTask.Result : null;

        stopwatch.Stop();

        if(result != null && int.TryParse(result, out response))
        {
            Console.WriteLine($"Time taken to answer: {stopwatch.Elapsed.ToString(@"m\::ss|/fff")}");
            return response;
        }

        else
        {
            throw new OperationCanceledException();
        }
    }

    catch(OperationCanceledException)
    {
        Console.WriteLine("Time is up");
        return null;
    }
}

static int ValidateResult(int result, int? userRepose, int score)
{
    if (result == userRepose)
    {
        Console.WriteLine("you answered correctly;\n you earned 5 points");
        score += 5;
    }
    else 
    {
        Console.WriteLine("Try again!");
        Console.WriteLine($"Correct answer is: {result}");
    }
    return score;
}

static async Task<int> PerformOperation(MathGameLogic mathGame, int firstNumber, int secondNumber, char operation, int score, DiffcultyLevel diffculty)
{
    int result;
    int? userResponse;
    DisplayMathGameQuestion(firstNumber, secondNumber, operation);
    result = mathGame.MathOperation(firstNumber, secondNumber, operation);
    userResponse = await GetUserResponse(diffculty);
    score += ValidateResult(result, userResponse, score);
    return score;
}










public enum DiffcultyLevel
{
    Easy = 45,
    Medium = 30,
    Hard = 15
}
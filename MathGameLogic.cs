namespace math_game
{
    public class MathGameLogic
    {
        public List<string> GameHistory { get; set; } = new List<string>();

        public void ShowMenu()
        {
            Console.WriteLine("please enter an option");
            Console.WriteLine("1. summation");
            Console.WriteLine("2. subtraction");
            Console.WriteLine("3. multiplication");
            Console.WriteLine("4. division");
            Console.WriteLine("5. random mode");
            Console.WriteLine("6. show History");
            Console.WriteLine("7. change diffculty");
            Console.WriteLine("8. exit");
        }


        public int MathOperation(int firstNumber, int secondNumber, char operation )
        {
            switch(operation)
            {
                case '+':
                    GameHistory.Add($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                    return firstNumber + secondNumber;
                case '-':
                    GameHistory.Add($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                    return firstNumber - secondNumber;
                case '*':
                    GameHistory.Add($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                    return firstNumber * secondNumber;
                case '/':
                    while(firstNumber < 0 || firstNumber > 100)
                    {
                        try
                        {
                            Console.WriteLine("enter a number between 0 and 100");
                            firstNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch(System.Exception)
                        {
                            
                        }
                    }
                    GameHistory.Add($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                    return firstNumber /  secondNumber;
            }
            return 0;
        }
    }
}







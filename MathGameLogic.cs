namespace math_game
{
    public class MathGameLogic
    {
        public List<string> GameHistory { get; set; } = new List<string>();

        public void ShowMenu()
        {
            Console.WriteLine("Please enter an option.");
            Console.WriteLine("1. summation\n2, subtaction\n3. multiplication\n 4.division");
            
        }
    }
}
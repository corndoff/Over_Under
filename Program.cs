uusing System;

namespace Over_Under
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}. Let's play Over Under");
            int old = RandNum();
            Console.WriteLine(old);
            int count = 0;
            while (true)
            {
                Console.WriteLine("Do you think the next number is over or under this number? [O or U]");
                char answer = Char.ToUpper(Console.ReadLine()[0]);
                int next = RandNum();
                if (next == old)
                {
                    next = RandNum();
                }
                if ((old > next && answer == 'U') || (old < next && answer == 'O'))
                {
                    Correct(next);
                    old = next;
                    next = RandNum();
                    count++;
                }
                else
                {
                    Incorrect(next, count);
                    char again = Char.ToUpper(Console.ReadLine()[0]);
                    if (again == 'Y')
                    {
                        Console.Clear();
                        old = RandNum();
                        Console.WriteLine($"Your new number is {old}.\n");
                        count = 0;
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        static int RandNum()
        {
            Random num = new Random();
            return num.Next(10);
        }
        static void Correct(int next)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Correct. The next number was {next}.");
            Console.ResetColor();
        }
        static void Incorrect(int next, int count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Wrong. The next number was {next}. Your score was {count}.");
            Console.ResetColor();
            Console.WriteLine("\n\n Would you like to play again? [Y or N]");
        }
    }
}

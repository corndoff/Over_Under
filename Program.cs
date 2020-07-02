using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Permissions;

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
            checkingScore(count);
            Console.ResetColor();
            Console.WriteLine("\n\n Would you like to play again? [Y or N]");
        }

        /*static void HighScoreFile()                                   Commenting this out because I need to figure out how to gain permission to create a file
        {                                                               As of now you must create the text file and input a 0 (zero) for the first three lines
            string highScoreFile = @"C:\Users\corey\HighScore.txt";
            
            if(File.Exists(highScoreFile) == false)
            {
                using (FileStream fs = File.Create(highScoreFile))
                {

                    File.WriteAllText(highScoreFile, "0\n0\n0");
                }
            }
        }*/

        static void checkingScore(int count)
        {
            string highScoreFile = @"C:\Users\corey\HighScore.txt";

            int first = int.Parse(File.ReadLines(highScoreFile).First());
            int second = int.Parse(File.ReadLines(highScoreFile).Skip(1).First());
            int third = int.Parse(File.ReadLines(highScoreFile).Skip(2).First());

            if (count > first)
            {
                third = second;
                second = first;
                first = count;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congrats you made the high score list!!! \nHigh Scores:\n{first}\n{second}\n{third}");
                Console.ResetColor();
            }
            else if (count > second)
            {
                third = second;
                second = count;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congrats you made the high score list!!! \nHigh Scores:\n{first}\n{second}\n{third}");
                Console.ResetColor();
            }
            else if (count > third)
            {
                third = count;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Congrats you made the high score list!!! \nHigh Scores:\n{first}\n{second}\n{third}");
                Console.ResetColor();
            }
            File.WriteAllText(highScoreFile, String.Empty);
            TextWriter tw = new StreamWriter(highScoreFile, true);
            tw.WriteLine($"{first}\n{second}\n{third}");
            tw.Close();
        }
    }
}
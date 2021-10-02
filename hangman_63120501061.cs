using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_63120501061_chinnapath
{
    class HangManGame
    ////////////////ตรวจสอบว่า input เป็น
    { 
        static bool IsWord(string secretword, List<string> letterGuessed)
        {

            bool word = false;
            for (int i = 0; i < secretword.Length; i++)
            {
                string c = Convert.ToString(secretword[i]);
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                else
                {
                    return word = false;

                }

            }
            return word;
        }
        ///////////
        static string Isletter(string secretword, List<string> letterGuessed)
        {
            string correctletters = "";
            for (int i = 0; i < secretword.Length; i++)
            {
                string c = Convert.ToString(secretword[i]);

                if (letterGuessed.Contains(c))
                {
                    correctletters += c;
                }
                else
                {
                    correctletters += "_ ";
                }

            }
            return correctletters;

        }

        static void GetAlphabet(string letters)
        {
            List<string> alphabet = new List<string>();

            for (int i = 1; i <= 26; i++)
            {
                char alpha = Convert.ToChar(i + 96);
                alphabet.Add(Convert.ToString(alpha));
            }

            int num = 49;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Letters Left are :");

            for (int i = 0; i < num; i++)
            {
                if (letters.Contains(letters))
                {
                    alphabet.Remove(letters);
                    num -= 1;
                }
                Console.Write("[" + alphabet[i] + "] ");
            }

            Console.WriteLine();

        }

        static void Main()
        {////////หน้าเมนูและrandom คำศัพ////////เก็บคำศัพไว้ในarrayแล้วทำการสุ่ม
            Random rnd = new Random();
            Console.Title = ("HangMan");
            string[] randomWord = new string[] { "Tennis", "Football", "Badminton","KMUTTMDT" };
            int resultrandom = rnd.Next(randomWord.Length);
            string  secretword = randomWord[resultrandom];
            List<string> letterGuessed = new List<string>();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Hangman Game\n0.Start\n1.Exit");
            int Menu = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter To Confirm");
            int live = 0;
            
            
            while (Menu == 0)
            {
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine("Guess for a {0} letter Word ", secretword.Length);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Incorrect Score : {0}", live);
                Isletter(secretword, letterGuessed);
                if (Menu == 1)
                {
                    Environment.ExitCode = -1;
                }



                if (letterGuessed.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You Entered letter [{0}] already", input);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Try a different word");
                    string letters = Isletter(secretword, letterGuessed);
                    Console.Write(letters);
                    GetAlphabet(input);
                    continue;
                }

                letterGuessed.Add(input);
                if (IsWord(secretword, letterGuessed))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(secretword);
                    Console.WriteLine("Congratulations");
                    break;
                }
                else if (secretword.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string letters = Isletter(secretword, letterGuessed);
                    Console.Write(letters);

                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops, letter not in my word");
                    live += 1;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Incorrect Score : {0}", live);
                    string letters = Isletter(secretword, letterGuessed);
                    Console.Write(letters);
                }
                Console.WriteLine();
                if (live == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Game over \nMy secret Word is [ {0} ]", secretword);
                    break;
                }

            }
            Console.ReadKey();




        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Assessment3Project
{
    class Program
    {
        static void PrintDivisibleBy7()
        {
            // Create a program that will take 10 numbers from user.And print the numbers that are divisible by 7
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter 10 numbers to check whether is Divisible by 7 or not");
            for (int i = 0; i < 10; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                numbers.Add(num);
            }
            Console.WriteLine("The numbers divisible by 7 are");
            foreach (int item in numbers)
            {
                if (item % 7 == 0)
                {
                    Console.WriteLine(item);
                }
            }
        }
        static void PrintPrimeNumbers()
        {
            //Create a program that will take a min and a max value from user and print all the prime numbers between it.
            int min_number, max_number;
            Console.WriteLine("Please enter min number");
            min_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter max number");
            max_number = Convert.ToInt32(Console.ReadLine());
            if (min_number < max_number)
            {
                Console.WriteLine("The Prime numbers between min and max are");
                for (int i = min_number; i <= max_number; i++)
                {
                    int flag = 0;
                    for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            flag++;
                        }
                    }
                    if (flag == 2)
                        Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }
        }
        static void PrintRepeatingNumbers()
        {
            //Create a program that will take numbers from user until the users enters a negative number and print the numbers that are repeating
            List<int> numbers = new List<int>();
            int number = 0;
            Console.WriteLine("Please enter a number.Enter negative number to Quit(example -1)");
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number >= 0)
                {
                    numbers.Add(number);
                }
                else
                {
                    var query = numbers.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(y => y.Key)
                                        .ToList();
                    Console.WriteLine("Elements that are repeated are");
                    foreach (var item in query)
                    {
                        Console.WriteLine(item);
                    }
                }
                
            } while (number >= 0);


        }


        static void SortingNumbers()
        {
            //Create a program that will take positive numbers from user until the user enters 0 and print back the numbers in ascending order
            List<int> numbers = new List<int>();
            int number = 0;
            Console.WriteLine("Please enter a number.Enter 0 to print sorted order of numbers");
            do
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number > 0)
                    numbers.Add(number);
                else if (number == 0)
                {
                    Console.WriteLine("The sorted numbers");
                    numbers.Sort();
                    foreach (var item in numbers)
                    {
                        Console.WriteLine(item);
                    }
                }
            } while (number > 0);
        }
        static void CheckNameAndPassword()
        {
            //Create a program that will take login details from user and print welcome if username is “Admin”
            //And password is “admin”(case sensitive). The user can try only 3 times max. If the user login fails the third time the application should state that and end
            int chance = 0;

            while (chance < 3)
            {
                Console.WriteLine("Please enter username");
                string user_name = Console.ReadLine();
                Console.WriteLine("Please enter password");
                string password = Console.ReadLine();

                if (user_name == "Admin" && password == "admin")
                {
                    Console.WriteLine("Welcome...");
                    break;
                }
                else
                {
                    chance++;
                    if (chance == 3)
                        Console.WriteLine("Sorry You Already tried 3 times");
                    else
                        Console.WriteLine("Invalid username or password...Try again");
                }
            }
        }

        public static void CardValidation()
        {
            Console.WriteLine("Enter the card number");
            long cardNumber = Convert.ToInt64(Console.ReadLine());
            int digits = countDigit(cardNumber);
            if (digits == 15 || digits == 16)
            {
                int result;
                Console.WriteLine("Card Number : " + cardNumber);
                long reverseNumber = 0;
                while (cardNumber > 0)
                {
                    long rem = cardNumber % 10;
                    reverseNumber = (reverseNumber * 10) + rem;
                    cardNumber = cardNumber / 10;
                }
                string cardNum = Convert.ToString(reverseNumber);
                Console.WriteLine("Reversed Card Number : " + reverseNumber);
                for (int i = 0; i < cardNum.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        int Number = Convert.ToInt32(Convert.ToString(cardNum[i])) * 2;
                        if (Number >= 10)
                        {
                            int sum = 0;
                            while (Number > 0)
                            {
                                int m = Number % 10;
                                sum = sum + m;
                                Number = Number / 10;
                            }
                            result = sum;

                        }
                        else
                        {
                            result = Number;
                        }
                    }
                    else
                    {
                        int Number = Convert.ToInt32(Convert.ToString(cardNum[i]));
                        result = Number;
                    }
                    int finalResult = result;
                    Console.Write(finalResult);
                    
                }
               
            }
            else
            {
                Console.WriteLine("OOPS...Please Enter card number of 15 or 16 digits");
            }
        }
        public static int countDigit(long cardNumber)
        {
            int count = 0;
            while (cardNumber != 0)
            {
                cardNumber = cardNumber / 10;
                count++;
            }
            return count;
        }
        static void PlayCowBullGame()
        {
            
            string[] wordsArr = new string[5];
            wordsArr[0] = "kite";
            wordsArr[1] = "four";
            wordsArr[2] = "neat";
            wordsArr[3] = "play";
            wordsArr[4] = "goal";
            for (int i = 0; i < wordsArr.Length; i++)
            {
                Console.WriteLine("Enter the guess");
                string guess = Console.ReadLine();
                string arr = wordsArr[i];
                int cow = 0, bulls = 0;
                if (arr.Length == guess.Length)
                {

                    for (i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == guess[i])
                        {
                            cow ++;
                        }
                        else
                        {
                            for (int j = 0; j < arr.Length; j++)
                            {
                                if (arr[i] == guess[j] && i != j)
                                {
                                    bulls ++;
                                }
                            }
                        }
                    }

                    if (cow == arr.Length)
                    {
                        Console.WriteLine("Congratulations You Won the Game");
                        Console.WriteLine("Do You want to play again. If yes press any number else press 0");
                        int option = Convert.ToInt32(Console.ReadLine());
                        while(option>0)
                        {
                            PlayCowBullGame();
                        }
                    }
                    Console.WriteLine("Cows-" + cow + " Bulls-" + bulls);
                    PlayCowBullGame();
                }
                else
                {
                    Console.WriteLine("Enter 4 letter a Word");
                }
            }
        }
        static void PrintMenu()
        {

            int choice = 0;
            do
            {
                Console.WriteLine("1. Print Numbers Divisible By 7");
                Console.WriteLine("2. Print Prime Numbers between min and max numbers");
                Console.WriteLine("3. Print Numbers that are repeated");
                Console.WriteLine("4. Print Numbers in sorted order");
                Console.WriteLine("5. Check name and password");
                Console.WriteLine("6. Card Validation");
                Console.WriteLine("7. Cow Bull game");
                Console.WriteLine("8. Exit");

                Console.WriteLine("Enter which you want to Perform");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PrintDivisibleBy7();
                        break;
                    case 2:
                        PrintPrimeNumbers();
                        break;
                    case 3:
                        PrintRepeatingNumbers();
                        break;
                    case 4:
                        SortingNumbers();
                        break;
                    case 5:
                        CheckNameAndPassword();
                        break;
                    case 6:
                        CardValidation();
                        break;
                    case 7:
                        PlayCowBullGame();
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 8);
        }
        static void Main(string[] args)
        {
            PrintMenu();
        }
    }
}

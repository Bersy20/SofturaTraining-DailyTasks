using System;

namespace FirstConsoleApplication
{
    class Program
    {
        static int n1, n2;//class level scope
        static void TakeTwoNumbersFromUser()
        {
            Console.WriteLine("please enter n1 : ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter n2 : ");
            n2 = Convert.ToInt32(Console.ReadLine());
        }
        static void FirstMethod()
        {
            //Console.WriteLine("Hello from my method");
            Console.WriteLine("User please enter something");
            string data = Console.ReadLine();
            Console.WriteLine("User u entered "+data);
        }
        static void DealingNumbers()
        {
            Console.WriteLine("please enter a integer ");
            string number = Console.ReadLine();
            int num1 = Convert.ToInt32(number);//explicit conversion
            num1 = num1 * 100;
            Console.WriteLine("The number multiplied by 100 is "+num1); 
        }
        static void Calculate()
        {
            int n1, n2, sum, sub, mul;
            Console.WriteLine("please enter n1 : ");
            n1=Int32.Parse(Console.ReadLine());//Unboxing - converting reference type to value type
            //n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter n2 : ");
            n2 = Convert.ToInt32(Console.ReadLine());
            sum = n1 + n2;
            mul = n1 * n2;
            sub = n1 - n2;
            float fNum1, fNum2;
            fNum1 = n1;
            fNum2 = n2;
            float div = (float)( fNum1 / fNum2);
            Console.WriteLine("The sum of {0} and {1} is " ,n1,n2,sum);
            Console.WriteLine("The Multiplication is " + mul);
            Console.WriteLine("The Subtraction is " + sub);
            Console.WriteLine("The division is " + div);
        }
        static void PrintBiggestOfTwo()
        {
            TakeTwoNumbersFromUser();
            if(n1==n2)
                Console.WriteLine("n1 {0} and n2 {1} are equal",n1,n2);
            else if(n1>n2)
                Console.WriteLine("n1 {0} is greater ",n1);
            else
                Console.WriteLine("n2 {0} is greater ",n2);
        }
        static void PrintDayOfWeek()
        {
            Console.WriteLine("Please enter a day");
            string day = Console.ReadLine();
            switch (day)
            {
                case "Monday":                   
                case "Tuesday":                  
                case "Wednesday":
                case "Thursday":
                    Console.WriteLine("Weekday");
                    break;
                case "Friday":
                    Console.WriteLine("Weekday but will weekend soon");
                    break;
                case "Saturday":                   
                case "Sunday":
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Enter valid day...");
                    break;
            }
        }
        static void UnderstandingItertion()
        {
            //for- finite iteration
            //for(init;cond;updation)
            //first time init and cond
            //then on updation and condition
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("For Loop end");
            //while - check for every iteration
            //int flag = 0, sum = 0;
            //while(flag>=0)
            //{
            //    //sum=sum+flag;
            //    sum += flag;
            //    console.writeline("please enter a number");
            //    flag = convert.toint32(console.readline());
            //}
            //console.writeline("here we go...the sum is "+sum);
            //do while loop check condition atlast -loop executes atleast once
            int flag = -1, sum = 0;
            do
            {
                //sum=sum+flag;
                sum += flag;
                Console.WriteLine("Please enter a number");
                flag = Convert.ToInt32(Console.ReadLine());
            } while (flag >= 0) ;
             Console.WriteLine("Here we go...The sum is " + sum);
        }
        static void UnderstandingErrorHandling()
        {
            int num = 0;
            Console.WriteLine("Please enter the number :");
            //num = Int32.Parse(Console.ReadLine());
            //bool check=Int32.TryParse(Console.ReadLine(),out num);
            while(Int32.TryParse(Console.ReadLine(),out num)==false)
                Console.WriteLine("Invalid input. Please enter an integer");
            Console.WriteLine("The number is "+num);
        }
        static void CheckEvenOrOdd()
        {
            int num1;
            Console.WriteLine("please enter n1 : ");
            num1 = Convert.ToInt32(Console.ReadLine());
            if(num1%2==0)
                Console.WriteLine("{0} is even number",num1);
            else
                Console.WriteLine("{0} is odd number",num1);
        }
        static void SumOfNumDivisibleBy7()
        {
            int flag = 0, sum = 0;
            while (flag>=0)
            {
                Console.WriteLine("Please enter a number");
                flag = Convert.ToInt32(Console.ReadLine());
                if (flag % 7 == 0)
                    sum = sum + flag;
                    Console.WriteLine("Result : "+sum);
            }
        }
        static void PrimeNumberInTheRange()
        {
            int min_number; int max_number; 
            Console.WriteLine("Please enter min number");
            min_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter max number");
            max_number = Convert.ToInt32(Console.ReadLine());
            for (int i = min_number; i <= max_number; i++)
            {
                int flag = 0;
                for (int j=1; j<=i; j++)
                {
                    if (i % j == 0)
                    {
                        flag++ ;                      
                    }                   
                }                
                if (flag == 2)
                    Console.WriteLine(i);
            }
        }
        static void CheckNameAndPassword()
        {
            int chance = 0;
            
            while(chance<=3)
            {
                Console.WriteLine("Please enter username");
                string user_name = Console.ReadLine();
                Console.WriteLine("Please enter password");
                string password = Console.ReadLine();

                if (user_name == "Ramu" && password == "1234")
                {
                    Console.WriteLine("Welcome..");
                    break;
                }
                else
                {
                    Console.WriteLine("Try again");
                    chance++;
                }
            }
        }
        static void ToPerformOperation()
        {
            Console.WriteLine("please enter num1 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter num2 : ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter operation to be performed ");
            char operators = Console.ReadLine()[0];

            switch (operators)
            {
                case '+':
                    int sum = num1 + num2;
                    Console.WriteLine("The sum of {0} and {1} is {2}", num1, num2, sum);
                    break;
                case '-':
                    int diff = num1 - num2;
                    Console.WriteLine("The sum of {0} and {1} is {2}", num1, num2, diff);
                    break;
                case '*':
                   int  mul = num1 * num2;
                    Console.WriteLine("The sum of {0} and {1} is {2}", num1, num2, mul);
                    break;
                case '/':
                   int div = num1 / num2;
                    Console.WriteLine("The sum of {0} and {1} is {2}", num1, num2, div);
                    break;
                default:
                    Console.WriteLine("Enter valid operators...");
                    break;
            }
        }
        static void Main(string[] args)
        {
            //FirstMethod();
            //DealingNumbers();
            //Calculate();
            //Console.WriteLine("Hello World!");
            //PrintBiggestOfTwo();
            //PrintDayOfWeek();
            //UnderstandingItertion();
            //UnderstandingErrorHandling();
            //CheckEvenOrOdd();
            //SumOfNumDivisibleBy7();
            //PrimeNumberInTheRange();
            //CheckNameAndPassword();
            ToPerformOperation();
        }
    }
}

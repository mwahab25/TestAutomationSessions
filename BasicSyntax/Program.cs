using System;
using System.Linq;

namespace BasicSyntax
{
    [Help("https://docs.google.com")]
    class Program
    {      
        static void Main(string[] args)
        {
            Console.WriteLine("-----Types and variables-----");

            // boolean variable
            bool result = true;

            //string variables
            string actionKeyword = " Navigate";
            string sRunMode = "Yes";

            //decimal variable
            decimal excuteTimeSecond = 34.5M;

            //integar variable
            int testCaseid = 534;

            //char variable
            char firstChar = 'a';

            Console.WriteLine("-----if condition-----");
            if (sRunMode.Equals("Yes"))
            {
                if (excuteTimeSecond > 22.5M)
                {
                    Console.WriteLine("action keyword:" + actionKeyword + ",testCaseid:" + testCaseid + ",firstChar:" + firstChar);                    
                }
            }
            else
            {
                Console.WriteLine("sRunMode False");
            }

            Console.WriteLine("-----for loop-----");
            for (int i = 0; i < 10; i = i + 1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("-----while loop-----");
            int j = 10;
            while (j < 20)
            {
                Console.WriteLine(j);
                j++;
            }

            Console.WriteLine("-----try..catch-----");
            try
            {
                Console.WriteLine("-----Arrays-----");

                int[] marks = new int[5] { 99, 98, 92, 97, 95 };
                double[] balance = { 2340.0, 4523.69, 3421.0 };

                Console.WriteLine(marks[3]);

                Console.WriteLine(marks[7]); //This cause exception index out of range

            }
            catch (Exception e1)
            {
                Console.WriteLine("Console.WriteLine(marks[7]) cause exception:" + e1.Message);
            }
            finally
            {
                Console.WriteLine("-----End Arrays-----");
            }

            Console.WriteLine("-----Enums-----");

            Console.WriteLine(Browsers.Chrome + "," + Browsers.IE);

            Console.WriteLine("-----Attribute-----");

            Program p = new Program();

            p.Display("basic c# syntax");

            Console.WriteLine("-----Lambda Expressions-----");
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Console.WriteLine(string.Join(" ", squaredNumbers));
            // Output:
            // 4 9 16 25

            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");
            // Output:
            // Hello World!
        }

        [Help("https://docs.google.com", Topic = "BasicsCsharp")]
        public void Display(string text)
        {
            Console.WriteLine("Display function");            
        }
    }
}

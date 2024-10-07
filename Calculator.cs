using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            int num2;
            string answer;
            int result = 0;
            
            Console.WriteLine("Hello! Welcome to the Calculator Programme");
           
            
            Console.WriteLine("Enter 1st number");
            num1=int.Parse(Console.ReadLine());
            Console.WriteLine(num1);

            Console.WriteLine("Enter 2nd number");
            num2 =int.Parse(Console.ReadLine());
            Console.WriteLine(num2);

            Console.WriteLine("Enter + for addition, - for substraction, * for multiplication, / for division");
            answer = Console.ReadLine();

            try
            {
                if (answer == "+")
                {
                    result = num1 + num2;
                }
                else if (answer == "-")
                {
                    result = num1 - num2;
                }
                else if (answer == "*")
                {
                    result = num1 * num2;
                }
                else if (answer == "/")
                {
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        return;  // Exit the program if division by zero
                    }
                }
                else
                {
                    Console.WriteLine("Invalid operation. Please enter +, -, *, or /.");
                    return;  // Exit if an invalid operation is provided
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            
            
            finally { Console.WriteLine("Thank You for using Calculator."); }
            Console.ReadKey();
        }


    }
    
}
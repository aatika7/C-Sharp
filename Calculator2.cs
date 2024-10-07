using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, result = 0;
           
            char operation;
            


            Console.WriteLine("Welcome to calcultor programme!");

           
            Console.Write("Enter the first number: ");
            if (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                return;
            }

            Console.Write("Enter operation: +,-,*,/,%,^:  ");
            operation = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Enter the 2nd number:  ");
            if(!double.TryParse(Console.ReadLine(),out num2))
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
                return;

            }

            switch (operation)
            {

                case '+':
                    result = num1 + num2; 
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2; 
                    break;
                
                case '/':
                   if(num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Number cannot divided by zero");
                        return;
                    }
                    break;

                case '%':
                    result = num1 % num2;
                    break;

                case '^':
                    result = Math.Pow(num1 , num2); 
                    break;

                default:
                    Console.WriteLine("Invalid Operation. Please Enter +, -, *, /, %, ^");
                    return;
                   }

            Console.WriteLine($"Result: {result}");


            Console.ReadKey();





        }
    }
}
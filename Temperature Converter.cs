using System;

namespace MyApp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nTemperature Converter");
                Console.WriteLine("1. Celsius to Fahrenheit");
                Console.WriteLine("2. Fahrenheit to Celsius");
                Console.WriteLine("3. Celsius to Kelvin");
                Console.WriteLine("4. Kelvin to Celsius");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ConvertCelsiusToFahrenheit();
                        break;
                    case "2":
                        ConvertFahrenheitToCelsius();
                        break;
                    case "3":
                        ConvertCelsiusToKelvin();
                        break;
                    case "4":
                        ConvertKelvinToCelsius();
                        break;
                    case "5":
                        return;  // Exit the application
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ConvertCelsiusToFahrenheit()
        {
            Console.Write("Enter temperature in Celsius: ");
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine($"{celsius}°C is {fahrenheit}°F");
        }

        static void ConvertFahrenheitToCelsius()
        {
            Console.Write("Enter temperature in Fahrenheit: ");
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsius = (fahrenheit - 32) * 5 / 9;
            Console.WriteLine($"{fahrenheit}°F is {celsius}°C");
        }

        static void ConvertCelsiusToKelvin()
        {
            Console.Write("Enter temperature in Celsius: ");
            double celsius = double.Parse(Console.ReadLine());
            double kelvin = celsius + 273.15;
            Console.WriteLine($"{celsius}°C is {kelvin}K");
        }

        static void ConvertKelvinToCelsius()
        {
            Console.Write("Enter temperature in Kelvin: ");
            double kelvin = double.Parse(Console.ReadLine());
            double celsius = kelvin - 273.15;
            Console.WriteLine($"{kelvin}K is {celsius}°C");
        }
    }

}
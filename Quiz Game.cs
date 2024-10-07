using System;

class Program
{
    static void Main(string[] args)
    {
        string[] questions = {
            "What is the capital of France?",
            "Who wrote 'Hamlet'?",
            "What is 5 + 7?",
            "What is the color of the sky?"
        };

        string[] answers = {
            "Paris",
            "Shakespeare",
            "12",
            "Blue"
        };

        int score = 0;

        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);
            Console.Write("Your answer: ");
            string userAnswer = Console.ReadLine();

            if (userAnswer.Equals(answers[i], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect! The correct answer is {answers[i]}.\n");
            }
        }

        Console.WriteLine($"Your total score is {score}/{questions.Length}");
    }
}

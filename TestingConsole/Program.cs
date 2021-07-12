using System;
using WRLibrary;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Card card = new Card("Dog", "Собака");
            card.OnCorrectAnswer();
            for (int i = 0; i < 20; i++)
            {
                card.OnMistake();
            }
            int c = card.Rating;

            Console.WriteLine(card);
        }
    }
}

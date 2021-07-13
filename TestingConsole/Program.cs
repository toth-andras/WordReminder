using System;
using WRLibrary;

namespace TestingConsole
{
    class Program
    {
        static CardStorage cardStorage = new CardStorage();
        static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                WriteOptions();
                Console.Write("Введите номер варианта: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int res = Convert.ToInt32(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                if (res == 1)
                {
                    AddCard();
                }
                if (res == 4)
                {
                    ShowCards();
                }
                if (res == 5)
                {
                    stop = true;
                }
            }
            
        }
        static void AddCard()
        {
            Console.Write("Введите термин: ");
            string term = Console.ReadLine();
            Console.Write("Введите значение: ");
            string value = Console.ReadLine();
            Card card;
            try
            {
                card = new Card(term, value);
            }
            catch (NullOrEmptyStringException)
            {
                WriteError("Неверные данные.");
                return;
            }

            try
            {
                cardStorage.AddCard(card);
            }
            catch (CardAlreadyExistsException)
            {
                WriteError("Такая карточка уже существует");
            }
        }
        static void ShowCards()
        {
            Card[] cards = cardStorage.GetAllCards();

            foreach (Card item in cards)
            {
                WriteCard(item);
            }
        }
        static void WriteOption(int num, string description)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("     " + num);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" - {description}");
        }
        static void WriteOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Возможные действия:");
            WriteOption(1, "добавить карточку");
            WriteOption(2, "редактировать карточку");
            WriteOption(3, "пройти опрос");
            WriteOption(4, "просмотреть все карточки");
            WriteOption(5, "выйти");
            Console.WriteLine();
        }
        static void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WriteCard(Card card)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            string cardStr = card.ToString();
            string res = "";
            for (int i = 0; i < cardStr.Length; i++)
            {
                res += "-";
            }
            Console.WriteLine(res);
            Console.WriteLine(cardStr);
            Console.WriteLine(res);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

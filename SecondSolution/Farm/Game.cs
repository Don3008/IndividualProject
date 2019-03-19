using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    enum Action
    {
        Feed = 1,
        TakeEgg,
        DoNothing
    }
    class Game
    {
        static Chicken chicken = new Chicken();
        static int sumOfEggs;

        static void Main(string[] args)
        {
            bool isAlive = true;
            Console.WriteLine("Игра Ферма");
            while (isAlive)
            {
                Welcome();
                int input = Input();
                ChooseAction(input);
                isAlive = chicken.Death();
                Console.WriteLine($"У вас {sumOfEggs} яиц");
            }
        }

        static void Welcome()
        {
            Console.WriteLine("Выберете действие: \n {0} - Покормить \n {1} - Забрать яйцо" +
            "\n {2} - Ничего не делать", (int)Action.Feed, (int)Action.TakeEgg,
            (int)Action.DoNothing);
        }

        static int Input()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        static void ChooseAction(int input)
        {
            Action action;
            action = (Action)input;
            switch (action)
            {
                case Action.Feed:
                    Feed();
                    break;
                case Action.TakeEgg:
                    TakeEgg();
                    break;
                case Action.DoNothing:
                    DoNothing();
                    break;
                default:
                    Console.WriteLine("Такого действия не существует!");
                    break;
            }
        }

        static void Feed()
        {
            Console.WriteLine("Текущее здоровье курицы: {0} из {1}", chicken.Health, chicken.MaxHealth);
            int maxForage = chicken.MaxHealth - chicken.Health;
            Console.WriteLine("Вы можете покормить курицу на: ");
            for (int i = maxForage; i > 0; i--)
            {
                Console.WriteLine("- {0} ед.", i);
            }
            while (true)
            {
                int forage = Input();
                if (forage > maxForage)
                {
                    Console.WriteLine("Не нужно перекармливать курицу!");
                }
                else
                {
                    chicken.Eat(forage);
                    break;
                }
            }
        }

        static void TakeEgg()
        {
            if (chicken.Eggs > 0)
            {
                Console.WriteLine("Вы забрали одно яйцо");
                sumOfEggs++;
                chicken.GiveEgg();
                Console.WriteLine("Оставшихся яиц у курицы: {0}", chicken.Eggs);
            }
            else
            {
                Console.WriteLine("Курица еще не снесла ни одного яйца");
            }
            Console.WriteLine("Здоровье курицы: {0} ед.", chicken.Health);
        }

        static void DoNothing()
        {
            Console.WriteLine("Курим в сторонке...");
            Console.WriteLine("Здоровье курицы: {0} ед.", chicken.Health);
        }
    }
}

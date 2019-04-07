using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    enum ActionForCow
    {
        Feed = 1,
        TakeMilk,
        DoNothing
    }

    class PlayForCow : IGame
    {
        Cow cow = new Cow();

        int sumOfMilk;

        public void Game()
        {
            bool isAlive;
            //while(isAlive)
            //{
                Welcome();
                int input = Input();
                ChooseAction(input);
                isAlive = cow.IsAliveMethod();
                if (!isAlive)
                {
                throw new Exception("Корова мертва");
                }
                Console.WriteLine($"У вас {sumOfMilk} молока");
            //}
        }

        public void Welcome()
        {
            Console.WriteLine("Выберете действие: \n {0} - Покормить \n {1} - Забрать молоко" +
            "\n {2} - Ничего не делать", (int)ActionForCow.Feed, (int)ActionForCow.TakeMilk,
            (int)ActionForCow.DoNothing);
        }

        public int Input()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        public void ChooseAction(int input)
        {
            Console.WriteLine("Текущее здоровье коровы: {0} из {1}", cow.CurrentHealth, cow.MaxHealth);
            Action action;
            action = (Action)input;
            switch (action)
            {
                case Action.Feed:
                    Feed();
                    break;
                case Action.TakeEgg:
                    TakeMilk();
                    break;
                case Action.DoNothing:
                    DoNothing();
                    break;
                default:
                    Console.WriteLine("Такого действия не существует!");
                    break;
            }
        }

        public void Feed()
        {
            int maxForage = cow.MaxHealth - cow.CurrentHealth;
            Console.WriteLine("Вы можете покормить корову на: ");
            for (int i = maxForage; i > 0; i--)
            {
                Console.WriteLine("- {0} ед.", i);
            }
            while (true)
            {
                int forage = Input();
                if (forage > maxForage)
                {
                    Console.WriteLine("Не нужно перекармливать корову!");
                }
                else
                {
                    cow.Eat(forage);
                    break;
                }
            }
        }

        void TakeMilk()
        {
            if (cow.Milk > 0)
            {
                Console.WriteLine("Вы забрали молоко");
                sumOfMilk++;
                cow.GiveMilk();
                Console.WriteLine("Оставшегося молока у коровы: {0}", cow.Milk);
            }
            else
            {
                Console.WriteLine("У коровы еще нет молока");
            }
        }

        public void DoNothing()
        {
            Console.WriteLine("Курим в сторонке...");
        }
    }
}

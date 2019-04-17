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
        int sumOfMilk;
        public List<Cow> cows = new List<Cow>();
        string[] names = new string[] { "Му-му", "Милка", "Буренка" };

        public PlayForCow()
        {
            CreateCow();
        }

        public void Game()
        {
            Cow cow = ChooseCow();
            Console.WriteLine(cow.State());
            bool isAlive = true;
            Welcome();
            int input = Input();
            ChooseAction(input, cow);
            isAlive = cow.IsAliveMethod();
            if (!isAlive)
            {
                cows.Remove(cow);
            }
        }

        public void CreateCow()
        {
            for (int i = 0; i < 3; i++)
            {
                cows.Add(new Cow(names[i]));
            }
        }

        public Cow ChooseCow()
        {
            Console.WriteLine("Выберете курицу");
            int count = 1;
            foreach (Cow cow1 in cows)
            {
                Console.WriteLine($"{count}. {cow1.Name}.");
                count++;
            }
            int index = int.Parse(Console.ReadLine());
            Cow cow = cows[index - 1];
            return cow;
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

        public void ChooseAction(int input, Animal cow)
        {
            ActionForCow action;
            action = (ActionForCow)input;
            switch (action)
            {
                case ActionForCow.Feed:
                    Feed(cow);
                    break;
                case ActionForCow.TakeMilk:
                    TakeMilk((Cow)cow);
                    break;
                case ActionForCow.DoNothing:
                    DoNothing();
                    break;
                default:
                    Console.WriteLine("Такого действия не существует!");
                    break;
            }
        }

        public void Feed(Animal cow)
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

        void TakeMilk(Cow cow)
        {
            if (cow.Milk > 0)
            {
                Console.WriteLine("Вы забрали молоко");
                sumOfMilk++;
                cow.GiveMilk();
                Console.WriteLine("Оставшихся молока у коровы: {0}", cow.Milk);
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

        public void ShowState()
        {
            foreach (var cow in cows)
            {
                cow.State();
            }
        }
    }
}

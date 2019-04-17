using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    enum ActionsForChicken
    {
        Feed = 1,
        TakeEgg,
        DoNothing
    }
    class PlayForChicken : IGame
    {
        int sumOfEggs;
        public List<Chicken> chickens = new List<Chicken>();
        string[] names = new string[] { "Ряба", "Цыпа", "Манька" };
        public PlayForChicken()
        {
            CreateChicken();
        }

        public void Game()
        {
            Chicken chicken = ChooseChicken();
            Console.WriteLine(chicken.State());
            bool isAlive = true;
            Welcome();
            int input = Input();
            ChooseAction(input, chicken);
            isAlive = chicken.IsAliveMethod();
            if (!isAlive)
            {
                chickens.Remove(chicken);
            }
        }

        public void CreateChicken()
        {
            for (int i = 0; i < 3; i++)
            {
                chickens.Add(new Chicken(names[i]));
            }
        }

        public Chicken ChooseChicken()
        {
            Console.WriteLine("Выберете курицу");
            int count = 1;
            foreach (Chicken chik in chickens)
            {
                Console.WriteLine($"{count}. {chik.Name}.");
                count++;
            }
            int index = int.Parse(Console.ReadLine());
            Chicken chicken = chickens[index - 1];
            return chicken;
        }

        public void Welcome()
        {
            Console.WriteLine("Выберете действие: \n {0} - Покормить \n {1} - Забрать яйцо" +
            "\n {2} - Ничего не делать", (int)ActionsForChicken.Feed, (int)ActionsForChicken.TakeEgg,
            (int)ActionsForChicken.DoNothing);
        }

        public int Input()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        public void ChooseAction(int input, Animal chicken)
        {
            ActionsForChicken action;
            action = (ActionsForChicken)input;
            switch (action)
            {
                case ActionsForChicken.Feed:
                    Feed(chicken);
                    break;
                case ActionsForChicken.TakeEgg:
                    TakeEgg((Chicken)chicken);
                    break;
                case ActionsForChicken.DoNothing:
                    DoNothing();
                    break;
                default:
                    Console.WriteLine("Такого действия не существует!");
                    break;
            }
        }

        public void Feed(Animal chicken)
        {
            int maxForage = chicken.MaxHealth - chicken.CurrentHealth;
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

        void TakeEgg(Chicken chicken)
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
        }

        public void DoNothing()
        {
            Console.WriteLine("Курим в сторонке...");
        }

        public void ShowState()
        {
            foreach (var chick in chickens)
            {
                chick.State();
            }
        }
    }
}

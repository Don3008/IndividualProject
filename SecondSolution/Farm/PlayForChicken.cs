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
    class PlayForChicken : IGame
    {
        int sumOfEggs;
        List<Chicken> chicken = new List<Chicken>();
        public void Game()
        {
            bool isAlive = true;
            //while (isAlive)
            //{
            Welcome();
            int input = Input();
            
            chicken = CreateChickens();
            ChooseAction(input);
            isAlive = chicken.IsAliveMethod();
            if (!isAlive)
            {
                throw new Exception("Курица мертва");
            }
            Console.WriteLine($"У вас {sumOfEggs} яиц");
            //}
        }

        public Chicken CreateChicken()
        {
            for (int i = 0; i < 3; i++)
            {
                chicken.Add(new Chicken());
            }
            return chicken;
        }

        //static void ChooseChicken()
        //    {

        //    }

        public void Welcome()
        {
            Console.WriteLine("Выберете действие: \n {0} - Покормить \n {1} - Забрать яйцо" +
            "\n {2} - Ничего не делать", (int)Action.Feed, (int)Action.TakeEgg,
            (int)Action.DoNothing);
        }

        public int Input()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        public void ChooseAction(int input)
        {
            Console.WriteLine("Текущее здоровье курицы: {0} из {1}", chicken.CurrentHealth, chicken.MaxHealth);
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

        public void Feed()
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

        void TakeEgg()
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
    }
}

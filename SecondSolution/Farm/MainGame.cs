using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    abstract class MainGame
    {
        static void Main(string[] args)
        {
            PlayForChicken gameForChicken = new PlayForChicken();
            PlayForCow gameForCow = new PlayForCow();
            Console.WriteLine("Добро пожаловать в игру \"Ферма\"!");
            bool isExit = false;
            while (!isExit)
            {
                Console.WriteLine("У вас есть корова и курица, выберете животное \n 1. Курица \n 2. Корова");
                int chooseAnimal = int.Parse(Console.ReadLine());
                switch (chooseAnimal)
                {
                    case 1:
                        gameForChicken.Game();
                        break;
                    case 2:
                        gameForCow.Game();
                        break;
                    default:
                        throw new Exception("Неверный ввод");
                }
                Console.WriteLine("Выберете действие: \n 1. Продолжить игру. \n 2. Выйти из игры");
                int continueOfGameOrNot = int.Parse(Console.ReadLine());
                switch (continueOfGameOrNot)
                {
                    case 1:
                        isExit = false;
                        break;
                    case 2:
                        isExit = true;
                        break;
                    default:
                        throw new Exception("Неверный ввод");
                }
            }
        }
    }
}

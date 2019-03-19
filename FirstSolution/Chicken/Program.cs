using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken
{
    class Program
    {
        static void Main(string[] args)
        {
            int egg = 0;
            int healthOfChiken = 3;
            Console.WriteLine("Добро пожаловать в игру \"Ферма\"!");
            Console.WriteLine("У Вас на выбор есть 3 действия за один ход: \n 1. Покормить курицу зерном; \n 2. Забрать яйцо; " +
                "\n 3. Ничего не делать.");
        marker:
            Console.Write("Введите номер позиции, чтобы выполнить действие: ");
            int act = int.Parse(Console.ReadLine());
            while (healthOfChiken != 0)
            {
                healthOfChiken--;
                switch (act)
                {
                    case 1:
                        Console.WriteLine($"Курица сыта на {healthOfChiken} из 5. Вы можете покормить ее максимум {5 - healthOfChiken}" +
                            $" зерн(ом)-ми.");
                        int eat = int.Parse(Console.ReadLine());
                        if (eat < 0 && eat > 5)
                        {
                            Console.WriteLine("Введено недопустимое значение!");
                            goto marker;
                        }
                        if (healthOfChiken + eat > 5)
                        {
                            Console.WriteLine("Сытность курицы не может быть больше 5!");
                            goto marker;
                        }
                        else
                        {
                            healthOfChiken += eat;
                            Console.WriteLine($"Сытность курицы составляет {healthOfChiken} из 5.");
                            ++egg;
                            goto marker;
                        }
                        
                    case 2:
                        if (egg == 0)
                        {
                            Console.WriteLine("Курица еще не снесла ни одного яйца!");
                            goto marker;
                            
                        }
                        else
                        {
                            egg--;
                            Console.WriteLine($"Вы забрали яйцо. У курицы осталось {egg} яиц.");
                            goto marker;
                        }
                    case 3:
                        Console.WriteLine("Ничего не делаем...");
                        goto marker;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
            Console.WriteLine("Курица погибла!");
        }
    }
}

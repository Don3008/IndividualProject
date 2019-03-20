using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Chicken
    {
        private readonly int maxHealth = 5;
        private const int initialHealth = 3;
        private const int initialQuantityEggs = 0;
        private bool isAlive = true;

        public int Eggs { get; private set; }
        public bool IsAlive { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            private set
            {
                MaxHealth = maxHealth;
            }
        }

        public Chicken()
        {
            IsAlive = isAlive;
            Health = initialHealth;
            Eggs = initialQuantityEggs;
        }

        public void Eat(int forage)
        {
            Health += forage;
            Console.WriteLine("Здоровье курицы после еды {0}", Health);
            MakeEgg(forage);
            Console.WriteLine("Оставшихся яиц у курицы: {0}", Eggs);
        }

        public void MakeEgg(int forage)
        {
            Eggs += forage;
        }

        public void GiveEgg()
        {
            Eggs--;
        }

        public bool IsAliveChicken()
        {
            Health--;
            if (Health <= 0)
            {
                Console.WriteLine("Курица умерла:(");
                IsAlive = false;
            }
            else
            {
                IsAlive = true;
            }
            return IsAlive;
        }
    }
}

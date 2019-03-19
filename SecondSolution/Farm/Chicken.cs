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

        public int Eggs { get; private set; }
        public bool IsLive { get; private set; }
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
            Health = 3;
            Eggs = 0;
        }

        public void Eat(int forage)
        {
            Health += forage;
            Console.WriteLine("Здоровье курицы после еды {0}", Health);
            MakeEgg(forage);
        }

        public void MakeEgg(int forage)
        {
            Eggs += forage;
        }

        public void GiveEgg()
        {
            Eggs--;
        }

        public bool Death()
        {
            Health--;
            if (Health <= 0)
            {
                Console.WriteLine("Курица умерла:(");
                IsLive = false;
            }
            else
            {
                IsLive = true;
            }
            return IsLive;
        }
    }
}

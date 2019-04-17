using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm 
{
    class Cow : Animal
    {
        private readonly int maxHealth = 7;
        private const int initialHealth = 4;
        private const int initialQuantityMilk = 0;
        private const bool isAlive = true;

        public string Name { get; private set; }
        public int Milk { get; private set; }
        public override int CurrentHealth { get; set; }
        public override int MaxHealth { get; set; }
        public override int InitialHealth { get; set; }
        public override bool IsAlive { get; set; }

        public Cow(string name)
        {
            MaxHealth = maxHealth;
            InitialHealth = initialHealth;
            IsAlive = isAlive;
            CurrentHealth = initialHealth;
            Milk = initialQuantityMilk;
            Name = name;
        }

        public override void Eat(int forage)
        {
            CurrentHealth += forage;
            Console.WriteLine($"Здоровье коровы после еды {CurrentHealth}");
            MakeMilk(forage);
            Console.WriteLine($"Оставшегося молока у коровы {Milk}");

        }

        private void MakeMilk(int forage)
        {
            Milk += forage;
        }

        public void GiveMilk()
        {
            Milk--;
        }

        public override bool IsAliveMethod()
        {
            CurrentHealth--;
            if (CurrentHealth <= 0)
            {
                Console.WriteLine("Корова умерла:(");
                IsAlive = false;
            }
            return IsAlive;
        }

        public override string State()
        {
            return String.Format("Здоровье коровы: {0}\nМолока у коровы: {1}", CurrentHealth, Milk);
        }
    }
}

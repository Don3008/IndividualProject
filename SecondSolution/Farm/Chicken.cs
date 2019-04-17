using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    class Chicken : Animal
    {
        private readonly int maxHealth = 5;
        private const int initialHealth = 3;
        private const int initialQuantityEggs = 0;
        private const bool isAlive = true;

        public string Name { get; private set; }
        public int Eggs { get; private set; }
        public override bool IsAlive { get; set; }
        public override int CurrentHealth { get; set; }
        public override int InitialHealth { get; set; }
        public override int MaxHealth { get; set; }

        public Chicken(string name)
        {
            MaxHealth = maxHealth;
            InitialHealth = initialHealth;
            IsAlive = isAlive;
            CurrentHealth = initialHealth;
            Eggs = initialQuantityEggs;
            Name = name;
        }

        public override void Eat(int forage)
        {
            CurrentHealth += forage;
            MakeEgg(forage);
        }

        private void MakeEgg(int forage)
        {
            Eggs += forage;
        }

        public void GiveEgg()
        {
            Eggs--;
        }

        public override bool IsAliveMethod()
        {
            CurrentHealth--;
            if (CurrentHealth <= 0)
            {
                IsAlive = false;
            }
            return IsAlive;
        }

        public override string State()
        {
            return String.Format("Здоровье курицы: {0} из {1}\nЯиц у курицы: {2}", CurrentHealth, MaxHealth, Eggs);
        }
    }
}

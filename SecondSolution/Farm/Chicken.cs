﻿using System;
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

        public int Eggs { get; private set; }
        public override bool IsAlive { get; set; }
        public override int CurrentHealth { get; set; }
        public override int InitialHealth { get; set; }
        public override int MaxHealth { get; set; }

        public Chicken()
        {
            MaxHealth = maxHealth;
            InitialHealth = initialHealth;
            IsAlive = isAlive;
            CurrentHealth = initialHealth;
            Eggs = initialQuantityEggs;
        }

        public override void Eat(int forage)
        {
            CurrentHealth += forage;
            Console.WriteLine("Здоровье курицы после еды {0}", CurrentHealth);
            MakeEgg(forage);
            Console.WriteLine("Оставшихся яиц у курицы: {0}", Eggs);
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
                Console.WriteLine("Курица умерла:(");
                IsAlive = false;
            }
            return IsAlive;
        }
    }
}

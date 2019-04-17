using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    abstract class Animal
    {
        abstract public int MaxHealth { get; set; }
        abstract public int InitialHealth { get; set; }
        abstract public bool IsAlive { get; set; }
        abstract public int CurrentHealth { get; set; }

        abstract public void Eat(int forage);

        abstract public bool IsAliveMethod();

        abstract public string State();
    }
}

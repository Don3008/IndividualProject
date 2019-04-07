using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm
{
    interface IGame
    {
        void Game();

        void Welcome();

        int Input();

        void ChooseAction(int input);

        void Feed();

        void DoNothing();
    }
}

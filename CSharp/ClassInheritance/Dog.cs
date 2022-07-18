using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    internal class Dog : Creature, IFourLeggedWalker
    {
        public override void Breath()
        {
            Console.WriteLine($" 이(가) 숨을 쉰다.");
        }

        public void FourLeggedWalker()
        {
            Console.WriteLine($" 이(가) 걷는다!");
        }
    }
}

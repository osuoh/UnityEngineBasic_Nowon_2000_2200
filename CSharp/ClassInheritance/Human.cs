﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    internal class Human : Creature, ITwoLeggedWalker , IFourLeggedWalker
    {
        public string name;
        public float height;

        public override void Breath()
        {
            Console.WriteLine($"{name} 이(가) 숨을 쉰다.");
        }



        // virtual : 자식클래스가 재정의할 수 있도록 하는 키워드
        public virtual void Grow()
        {
            mass += 10.0f;
            height += 5.0f;
            Console.WriteLine($"{name} 이 자랐다 ! {mass}, {height}");
            
        }

        public void TwoLeggedWalk()
        {
            Console.WriteLine($"{name} 이(가) 이족보행 한다!");
        }

        public void FourLeggedWalker()
        {
            Console.WriteLine($"{name} 이(가) 사족보행 한다!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeGame
{
    internal class TileInfo
    {
        public int index;    // 몇번째 칸인지 에 대한 정보
        public string name; // 칸의 이름 
        public string discription; // 칸에대한 설명 
        virtual public void TileEvent() // 이 칸에 도착했을때 실행할 이벤트 함수
        {
            Console.WriteLine($"Tile number : {index}, The  Player is On {name} , {discription}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeGame
{
    internal class TileMap
    {
        public Dictionary<int, TileInfo> dic_tile = new Dictionary<int, TileInfo>(); // 칸 번호, 칸 정보 를 저장할 사전

        // maxTileNum 만큼 칸을 생성하는 함수
        public void MapSetup(int maxTileNum)
        {
            for (int i = 1; i < maxTileNum + 1; i++)
            {
                if (i % 5 == 0)
                {
                    // 샛별칸 생성
                    TileInfo tileInfo_Star = new TileInfo_Star();
                    tileInfo_Star.index = i;
                    tileInfo_Star.name = "샛별";
                    tileInfo_Star.discription = "샛별을 획들할 수 있는 칸입니다.";
                    dic_tile.Add(i, tileInfo_Star);
                }
                else
                {
                    // 일반칸 생성
                    TileInfo tileInfo_Dummy = new TileInfo();
                    tileInfo_Dummy.index = i;
                    tileInfo_Dummy.name = "일반";
                    tileInfo_Dummy.discription = "이 칸은 아무 이벤트가 없습니다.";
                    dic_tile.Add(i, tileInfo_Dummy);
                }
            }
            Console.WriteLine($"맵 생성이 완료되었습니다. 최대 타일 숫자는 {maxTileNum} 입니다.");
        }
    }
}

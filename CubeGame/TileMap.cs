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
            for (int i = 0; i < maxTileNum; i++)
            {
                if (i % 5 == 0)
                {
                    // 샛별칸 생성
                    TileInfo tileInfo_Star = new TileInfo_Star();
                    tileInfo_Star.index = i;
                    tileInfo_Star.name = "Star";
                    tileInfo_Star.discription = "This is star tile, You'll get star and star amout on this tile increase 1";
                    dic_tile.Add(i, tileInfo_Star);
                }
                else
                {
                    // 일반칸 생성
                    TileInfo tileInfo_Dummy = new TileInfo();
                    tileInfo_Dummy.index = i;
                    tileInfo_Dummy.name = "Dummy";
                    tileInfo_Dummy.discription = "This is Dummy Tile";
                    dic_tile.Add(i, tileInfo_Dummy);
                }
            }
            Console.WriteLine($"Map setup complete. Maximum tile number is {maxTileNum}");
        }
    }
}

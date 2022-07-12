using System;
using System.Collections.Generic;

namespace CubeGame
{
    
    
        internal class Program
        {
            static private int totalTile = 20; // 칸의 갯수
            static private int currentStarPoint = 0; // 샛별 갯수
            static private int totalDiceNumber = 20; // 주사위 갯수
            static private int previousTileIndex = 0; // 이전 칸의 번호 ( 플레이어가 샛별칸을 지나는지 비교하기위함 )
            static private int currentTileIndex = 0; // 현재 칸의 번호
            static private Random random; // 난수 생성용 변수
            static void Main(string[] args)
            {
                TileMap map = new TileMap(); // 맵 클래스 인스턴스화
                map.MapSetup(totalTile); // 맵 생성 (20칸)

                int currentDiceNumber = totalDiceNumber; // 현재 주사위 갯수 초기값은 최대 주사위 갯수
                while (currentDiceNumber > 0)
                {
                    int diceValue = RollADice(); // 주사위 굴려서 나온 눈금
                    currentDiceNumber--; // 주사위 굴렸으니까 남은 주사위갯수 차감
                    currentTileIndex += diceValue; // 주사위 눈금만큼 플레이어 전진

                    // 플레이어가 샛별칸을 지날때 (5의 배수칸을 지날때)
                    if (previousTileIndex / 5 < currentTileIndex / 5)
                    {
                        int passedStartTileIndex = CalcPassedStarTileIndex(currentTileIndex); // 지나온 샛별칸 번호 계산
                        TileInfo passedStarTileInfo = map.dic_tile.GetValueOrDefault(passedStartTileIndex); // 지나온 샛별칸의 TileInfo 가져오기
                        TileInfo_Star passedStarTileInfo_Star = passedStarTileInfo as TileInfo_Star; // TileInfo 타입을 TileInfo_Star 로 인식하겠다.
                        if (passedStarTileInfo_Star != null) // 샛별칸의 TileInfo 정보를 가져오는데 성공했으면
                        {
                            currentStarPoint += passedStarTileInfo_Star.starValue; // 샛별점수 누적
                        }
                    }

                    if (currentTileIndex > totalTile) // 현재칸이 최대칸을 넘어가 버렸을때
                    {
                        currentTileIndex -= totalTile; // 현재칸에다가 최대칸 을 뺀다.
                    }

                    TileInfo info = map.dic_tile.GetValueOrDefault(currentTileIndex); // map 에서 현재칸의 TileInfo 를 가져옴.
                    if (info == null) // 현재칸의 TileInfo 를 가져오지 못했을때는 프로그램을 강제종료한다.
                    {
                        Console.WriteLine($"failed to get TileInfo number {currentTileIndex}");
                        return;
                    }


                    // 각 칸에 도착했을때 이벤트를 발생하는 두가지 방법 : 
                    // =============== 1. Override 함수의 성질을 이용한 경우=====================
                    // TileInfo_Star 로 인식할 필요가 없는 이유: 
                    // 자식 클래스를 객체화 시킨후에 
                    // 부모 클래스타입으로 인스턴스화 시키고 
                    // 해당 인스턴스의 함수를 호출할 때
                    // 그 함수가 override 되어있으면, 
                    // 부모 클래스의 함수가 아닌, 자식클래스의 override 된 함수를 호출한다.
                    info.TileEvent();

                    // =============== 2. 그냥 무식하게 경우마다 나눠서 코딩한 경우 ==============
                    /*string tileMapName = info.name; // 현재 칸의 이름
                    switch (tileMapName) // 현재칸의 이름에 따른 분기문
                    {
                        case "Dummy":
                            info.TileEvent(); // 해당 칸의 이벤트 실행
                            break;
                        case "Star":

                            TileInfo_Star infoStar = info as TileInfo_Star; // star tile info 로 인식
                            if(infoStar != null) // 인식에 성공하면
                            {
                                infoStar.TileEvent(); // 해당 칸의 이벤트 실행
                            }
                            else // 실패하면
                            {
                                Console.WriteLine("Map has an error. Exit game");
                                return; // 강제종료
                            }
                            break;
                        default:
                            return;
                    }*/
                    // 위 두가지 경우를 비교했을때, 코드의 양이 확연이 차이가 난다. 
                    // 위 성질이 Override 를 사용하는 큰 이유중 하나임.							

                    previousTileIndex = currentTileIndex;
                    Console.WriteLine($"Current Star Point : {currentStarPoint}");
                    Console.WriteLine($"Remain Dice number : {currentDiceNumber}");
                }

                Console.WriteLine($"Finished! You Got total {currentStarPoint} stars ");

            }

        static private int RollADice()
        {
            string userInput = "Default";
            while (userInput != "")
            {
                Console.WriteLine("엔터키로 주사위를 굴리세요...!");
                userInput = Console.ReadLine();
            }
            random = new Random(); // 난수 생성용 인스턴스
            int diceValue = random.Next(1, 6 + 1); // 1~6 중 랜덤한 정수
            Console.WriteLine($"주사위를 굴렸다..! 눈금은 {diceValue} 다!");
            DisplayDice(diceValue);
            return diceValue;
        }
        static void DisplayDice(int diceValue)
        {
            switch (diceValue)
            {
                case 1:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("└───────────┘");
                    break;
                case 2:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 3:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 4:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 5:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 6:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                default:
                    throw new Exception("주사위 눈금이 잘못되었습니다.");
            }
        }
        // 현재 칸의 번호를 넣어주면 지나온 샛별칸의 번호를 반환해주는 함수
        static public int CalcPassedStarTileIndex(int currentTileIndex)
        {
            int index = currentTileIndex / 5 * 5;
            return index;
        }
    }
}

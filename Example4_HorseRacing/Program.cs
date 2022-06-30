using System;
using System.Threading;


namespace Example4_HorseRacing
{
    internal class Program
    {
        static Random random;
        static bool isGameFinished = false;
        static int maxSpeed = 20;
        static int minSpeed = 10;
        static int finishDistance = 200;

        static void Main(string[] args)
        {
            // 말 다섯마리 만들고
            // 각각의 말 이름들 정해주고
            Horse[] horse = new Horse[5];
            string[] VictoryHorse = new string[5];
            int currentgrade = 1;

            for (int i = 0; i < 5; i++)
            {
                horse[i] = new Horse();
                horse[i].name = $"{i+1}번마";
            }
            Console.WriteLine("++++!경주 시작!++++");
            int length = horse.Length;
            int count = 0;
            
            // 경주 중
            while (isGameFinished == false)
            {
                Console.WriteLine($"========================{count} 초============================");
                // 각각의 말들을 달리게 함
                for (int i = 0; i < length; i++)
                {
                    if (horse[i].dontMove == false)
                    {
                        random = new Random();
                        int tmpMoveDistance = random.Next(minSpeed, maxSpeed+1);
                        horse[i].Running(tmpMoveDistance);
                        Console.WriteLine($"{horse[i].name} 가 달린거리 : {horse[i].distance} ");
                        if (horse[i].distance >= finishDistance)
                        {
                            horse[i].dontMove = true;
                            VictoryHorse[currentgrade - 1] = horse[i].name;
                            currentgrade++;
                        }
                    }
                }
                Console.WriteLine("====================================================");
                if(currentgrade > 5)
                {
                    isGameFinished = true;
                    Console.WriteLine("경주 끝!!!!");
                    break;
                }
                Thread.Sleep(1000);
                count++;
            }

            Console.WriteLine("========결과 발표========");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{i + 1}등 : {VictoryHorse[i]}");
            }
        }
    }

    public class Horse
    {
        public string name;
        public int distance;
        public bool dontMove;

        public void Running(int movingDistance)
        {
            distance += movingDistance;
        }
    }
}

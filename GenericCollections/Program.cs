using System;
using System.Collections.Generic;


// Generic : 일반화
// 다양한 자료형에 대해서 유동적으로 갖다쓸 수 있도록 만드는 형태
namespace GenericCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List
            List<int> list_int = new List<int>();
            List<float> list_float = new List<float>();
            List<List<int>> list_list_int = new List<List<int>>();

            // 추가
            list_int.Add(0);
            list_float.Add(0);
            list_list_int.Add(list_int);
            list_list_int.Add(new List<int>());

            // 삭제
            list_int.Remove(0);
            list_list_int.RemoveAt(1);

            // 검색
            //list_int.Find(x => x == 0);
            list_int.Contains(0);


            // LinkedList
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddLast(0);
            linkedList.AddFirst(1);
            linkedList.AddBefore(linkedList.Find(0) , 3);
            Console.WriteLine(linkedList.First);
            linkedList.RemoveLast();

            // 중요!
            // *****문자열 키값으로 해시를 뽑아내는 해시함수 구현 방식*****
            // 1. 입력 문자열의 각 문자들을 정수형태로 전부 더한다. (부가적으로 충돌을 줄이기 위해서
            //    자릿수를 곱하거나 자릿수의 승수를 곱하는 등의 연산을 추가할 수 있다.)
            // 2. 1의 값에 해시테이블 크기로 모듈러(나머지) 연산을 한다.
            // 3. 2의 결과를 해시로 반환한다.

            // 해시가 충돌했을때 쓸 수 있는 방법
            // 1. 체이닝 : hash 충돌이 일어난 value 들을 linkedlist 형태로 관리하는 방법
            // 
            // 2. 오픈어드레싱

            // Dictionary

            // Queue

            // Stack
        }
    }
}

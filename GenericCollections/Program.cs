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
            // 박싱 : 자료형을 객체타입으로 변환하는 과정
            // 언박싱 : 객체타입을 원래 자료형을 변환하는 과정
            // System.Collections 를 더이상 사용하지 않는 이유는
            // 박싱은 기본형 단순 할당과정보다 20배 정도 느리고
            // 언박싱은 4배 정도 느리기때문에
            // Generic 을 사용할것을 권장하고있다.

            // ArrayList (박싱 / 언박싱 때문에 쓰지않음)
            //--------------------------------------------------------
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
            arrayList.Add(3);
            arrayList.Add("철수");
            arrayList.Add('A');

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

            for (int i = 0; i < list_int.Count; i++)
            {
                Console.WriteLine(list_int[i]);
            }


            // LinkedList
            LinkedList<int> linkedList = new LinkedList<int>();

            // 추가
            linkedList.AddLast(0);
            linkedList.AddFirst(1);
            linkedList.AddBefore(linkedList.Find(0) , 3);
            Console.WriteLine(linkedList.First);

            // 삭제
            linkedList.RemoveLast();

            // 검색
            linkedList.Find(0);

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

            // ArrayList (박싱 / 언박싱 때문에 쓰지않음)
            //--------------------------------------------------------
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("철수", 90);

            // Dictionary
            Dictionary<string, char> grades = new Dictionary<string, char>();

            // 추가
            grades.Add("철수", 'A');
            grades.Add("영희", 'B');
            if (grades.TryAdd("영희", 'C'))
            {
                Console.WriteLine("영희 점수 C 추가");
            }
            else
            {
                Console.WriteLine($"영희 점수 이미 있음 : {grades["영희"]}");
            }

            foreach (var sub in grades)
            {
                Console.WriteLine(sub.Key);
                Console.WriteLine(sub.Value);
            }

            foreach (var sub in grades.Keys)
            {
                Console.WriteLine(sub);
                Console.WriteLine(grades[sub]);
            }

            
            // 삭제
            grades.Remove("철수");
           
            // 검색
            if (grades.ContainsKey("영희"))
            {
                Console.WriteLine("영희 점수 있음");
            }

            if (grades.TryGetValue("영희", out char grade))
            {
                Console.WriteLine(grade);
            }

            // Queue
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1); // queue 제일 뒤에 아이템 추가
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue(); // queue 제일 앞에 있는 아이템 제거 및 반환
            Console.WriteLine(queue.Dequeue());
            queue.Peek(); // 제일 앞에있는 아이템 반환
            queue.TryPeek(out int peek);

            // Stack
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(1); // 가장 마지막에 아이템 추가
            stack.Pop(); // 가장 마지막에 추가된 아이템 제거 및 반환
            stack.Peek(); // 가장 마지막에 추가된 아이템 반환
            stack.TryPeek(out int result);

        }
    }
}

﻿using System.Numerics;

namespace _01._List
{
	internal class Program
	{
		/*******************************************************
		* 리스트 (List)
		* 
		* 런타임 중 크기를 확장할 수 있는 배열기반의 자료구조
		* 배열요소의 갯수를 특정할 수 없는 경우 사용이 용이
		* 
		* 개수가 정해져 있지 않은 데이터 집합을 쓸 떄.
		* 아주 큰 배열을 먼저 만들고, 내용이 채워지면 채워진 내용만 사용하면서,
		* 마치 그 내용크기만큼만 리스트가 있는 것처럼 취급한다.
		*******************************************************/

		// <리스트 구현>
		// 리스트는 배열기반의 자료구조이며, 배열은 크기를 변경할 수 없는 자료구조
		// 리스트는 동작 중 크기를 확장하기 위해 포함한 데이터보다 더욱 큰 배열을 사용


		// 크기 = 3, 용량 = 8       크기 = 4, 용량 = 8       크기 = 5, 용량 = 8
		// ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│3│ │ │ │ │ │        │1│2│3│4│ │ │ │ │        │1│2│3│4│5│ │ │ │
		// └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


		// <리스트 삽입>
		// 중간에 데이터를 추가하기 위해 이후 데이터들을 뒤로 밀어내고 삽입 진행
		//      ↓                        ↓                        ↓
		// ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│3│4│ │ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│A│3│4│ │ │ │
		// └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


		// <리스트 삭제>
		// 중간에 데이터를 삭제한 뒤 빈자리를 채우기 위해 이후 데이터들을 앞으로 당김
		//      ↓                        ↓
		// ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│A│3│4│ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│3│4│ │ │ │ │
		// └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


		// <리스트 용량> = Capacity
		// 용량을 가득 채운 상황에서 데이터를 추가하는 경우
		// 더 큰 용량의 배열을 새로 생성한 뒤 데이터를 복사하여 새로운 배열을 사용

		// 배열을 갖고있는 길이가 크기이지만, 리스트는 그렇지않다. 길이를 용량이라고 부른다
		// list.Capacity

		// 리스트가 가득찼을 떄 이미 지정된 메모리에서 더 늘리는거는 불가능하기 떄문에
		// 새로운 배열로 이사간다!
		// 용량은 두배씩 증가 4 -> 8 -> 16 -> 32 ...
		// list.Capacity = 100000; 이라고 미리 지정해놓으면 배열 버리고 이사가는 과정 없어짐.

		// 1. 리스트가 가득찬 상황에서 새로운 데이터 추가 시도
		// 크기 = 8, 용량 = 8
		// ┌─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│3│4│5│6│7│8│ ← A 추가
		// └─┴─┴─┴─┴─┴─┴─┴─┘
		//
		// 2. 새로운 더 큰 배열 생성
		// 크기 = 8, 용량 = 8          크기 = 0, 용량 = 16
		// ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│3│4│5│6│7│8│ ← A 추가  │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │
		// └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
		//
		// 3. 새로운 배열에 기존의 데이터 복사
		// 크기 = 8, 용량 = 8          크기 = 8, 용량 = 16
		// ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│3│4│5│6│7│8│ ← A 추가  │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │
		// └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
		//
		// 4. 기본 배열 대신 새로운 배열을 사용
		// 크기 = 8, 용량 = 16
		// ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │ ← A 추가
		// └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
		//
		// 5. 빈공간에 데이터 추가
		// 크기 = 9, 용량 = 16
		// ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
		// │1│2│3│4│5│6│7│8│A│ │ │ │ │ │ │ │
		// └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘


		// <리스트 시간복잡도>
		// 접근    탐색    삽입    삭제
		// O(1)    O(n)    O(n)    O(n)


		static void Main(string[] args)
		{
			// 1000 마리의 몬스터
			// 공격 범위 안에 있는 몬스터 1 or 5 or 100 or 500 ...

			int[] array1 = new int[1]; // ?
			int[] array2 = new int[5]; // ?
			int[] array3 = new int[100]; // ?
			int[] array4 = new int[500]; // ?

			// 크기를 작게하면 배열 용량보다 더 큰게 들어올 수 있고,
			// 크기를 크게하면 작게 들어왔을 때 공간이 낭비된다.
			// 이럴때 필요한게 리스트!

			List<string> list = new List<string>();
			List<int> list1 = new List<int>();
			List<double> list2 = new List<double>();
			// <> 안이 리스트의 자료형 정하는 것, 일반화 매개변수


			// 추가
			list.Add("0번째 데이터");
			list.Add("1번째 데이터");
			list.Add("2번째 데이터");
			list.Add("3번째 데이터");
			list.Add("4번째 데이터");                // O(1)

			list.Insert(1, "중간 데이터 1에 추가"); // O(n)
			list.Insert(3, "중간 데이터 3에 추가");

			// add를 insert보다 선호하는 이유?
			// insert를 하면 중간에 값을 넣고 뒤로 미뤄주는 과정이 더 추가되지만,
			// add는 끝에다가 추가만하기때문에 추가 과정 필요없기때문이다.



			// 삭제
			list.Remove("2번째 데이터"); // 내용이 "2번째 데이터"인 데이터를 지운다.
			list.Remove("3번째 데이터");
			list.RemoveAt(2); // 2번째 데이터를 지운다.
			list.Remove("6번째 데이터"); // 없는 요소를 지우고싶을때? 그냥 PASS한다~
			list.RemoveAt(list.Count - 1); // 매우 빠른 방법, 그냥 리스트 마지막 요소를 지우겠다.

			// 지웠는지 안지웠는지 결과?
			// remove의 반환값 bool true면 잘 지운것, false면 없어서 못지웠거나 기타 등등

			bool succes = list.Remove("1번째 데이터");
			bool fail = list.Remove("1번째 데이터");

			// 중간이 지워지면 뒤의 데이터들이 자동으로 앞으로 당겨진다.
			// 리스트는 빈공간을 허용하지 않기 때문.



			// 접근
			// 리스트도 배열 기반이라서 index로 접근 가능!
			list[0] = "수정된 0번 데이터";
			string text = list[2];

			for (int i = 0; i < list.Count; i++) // 리스트는 Length 아니고 Count(개수) 쓰기 이유는 다음에..
			{
				// list[i] = "수정하기"; // for문과 list는 잘 어울린다.
			}


			// 탐색
			int index = list.IndexOf("4번째 데이터"); // 안에서 @@ 찾아줘, 몇번째 index에 있는지 반환



			// list.Capacity
			List<int> list3 = new List<int>(10000); // 두 문장을 한 문장으로~!
			list3.Capacity = 10000; // 중요!
			for (int i = 0; i < 10000; i++)
			{
				list3.Add(i);
			}
		}
	}
}
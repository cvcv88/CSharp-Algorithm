using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure // 이름 바꾸는 이유?
{                       // 같은 네임스페이스안에서 List 이름으로 만들면 program의 list가 내가 지금 만든걸로 잡힐 수 있어서
	public class List<T> // 어떤 자료형이든지 대응하기 위해서 일반화 적용
	{
		// list에서는 배열, 크기, 용량이 가장 중요

		private const int DefaultCapacity = 4;
		private T[] items; // 일반화 배열, 리스트처럼 이용될 배열, 용량(배열의 크기)도 담고 있음
		private int count; // 몇 개 들고 있는지

		public List() // 리스트 처음 만들었을 때
		{
			items = new T[DefaultCapacity];
			count = 0;
		}

		public List(int capacity) // capacity 지정하면서 만들 때
		{
			items = new T[capacity];
			count = 0;
		}

		public int Capacity { get { return items.Length; } } // 용량 프로퍼티, 읽기 전용
		public int Count { get { return count; } } // 리스트 요소 프로퍼티, 읽기 전용
		public bool IsFull { get { return count == items.Length; } } // 가득 차 있을 때

		public T this[int index] // 인덱서
		{
			get
			{
				return items[index];
			}
			set
			{
				items[index] = value;
			}
		}

		public void Add(T item)
		{
			/* 방법 1.
			if (count == items.Length) // 가득 차 있을 때
			{
				Grow(); // 두배로 늘린다.
			}*/

			// 방법 2
			if (IsFull)
			{
				Grow();
			}
			items[count] = item; // 1개 가지고 있을때 1번 인덱스에 넣어야 함!
			count++;
			// items[count++] = item;
		}

		public void Insert(int index, T item)
		{
			// 예외 처리 필요 : 크기를 벗어나게 중간에 끼워넣는 것을 불가능하게
			// (갖고있는거보다 더 큰 곳에 넣는다)
			if (index < 0 || index > count)
				throw new ArgumentOutOfRangeException("index");

			if (IsFull)
				Grow();
			Array.Copy(items, index, items, index + 1, count - index);
			// count 4개 [0] ~ [3], index = 1일때, 4 - 1 = 3개 복사!

			items[index] = item;
			count++;
		}


		public bool Remove(T item)
		{
			// 찾는거 구현
			int index = IndexOf(item);
			// 지우는거 구현
			if (index >= 0) // 못 찾으면 -1
			{
				RemoveAt(index);
				return true;
			}
			else
			{
				return false; // 못 지웠으면 false
			}
		}

		public void RemoveAt(int index)
		{
			// 예외처리 필요 : 크기를 벗어나게 중간에 빼는 것 불가능
			if (index < 0 || index >= count)
				throw new IndexOutOfRangeException();
			count--;
			Array.Copy(items, index + 1, items, index, count - index);
		}

		public int IndexOf(T item)
		{
			// 찾는거 구현
			for (int i = 0; i < count; i++)
			{
				if (item.Equals(items[i]))
				{
					return i;
				}
			}
			return -1;
		}
		private void Grow()
		{
			// 2. 새로운 더 큰 배열 생성.
			T[] newItems = new T[items.Length * 2]; // 새로운 배열의 길이는 기존의 두배

			// 3. 새로운 배열에 기존의 데이터 복사
			Array.Copy(items, newItems, items.Length); // 기존 배열, 새로운 배열, 크기 만큼 복사하기
			/*for(int i = 0; i < items.Length; i++) // 위와 같지만 속도는 위가 더 빠름
			{
				newItems[i] = items[i];
			}*/

			// 4. 기본 배열 대신 새로운 배열을 사용
			items = newItems; // items이 newItems를 가리킨다. 얕은 복사 진행

			// 5. 빈공간에 데이터 추가
			// 이거는 Add에서 한다!
		}
	}
}
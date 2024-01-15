using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	public class Queue<T>
	{
		private const int DefaultCapacity = 4;

		private T[] array;
		private int head;
		private int tail;
		private int count;

		public Queue()
		{
			array = new T[DefaultCapacity];
			head = 0;
			tail = 0;
			count = 0;
		}

		public int Count
		{
			get
			{
				if (head <= tail)
					return tail - head;
				else
					return tail + (array.Length - head);
			}
		}

		public void Clear()
		{
			array = new T[DefaultCapacity];
			head = 0;
			tail = 0;
		}

		public void Enqueue(T item) // 1
		{
			if (IsFull())
			{
				Grow();
			}

			array[tail] = item;
			// MoveNext(ref tail);
			tail++; // 좀 더 쉬운 표현
			if(tail == array.Length)
			{
				tail = 0;
			}
			count++;
		}

		public T Dequeue()
		{
			if (count == 0)
				throw new InvalidOperationException();


			/*if (IsEmpty()) // 같은 표현
				throw new InvalidOperationException();*/

			T item = array[head];

			head++;
			if (head == array.Length)
			{
				head = 0;
			}
			count--;
			// MoveNext(ref head);

			return item;
		}

		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[head];
		}

		private void Grow() // 1 다시보기
		{
			int newCapacity = array.Length * 2;
			T[] newArray = new T[newCapacity];
			if (head < tail)
			{
				Array.Copy(array, head, newArray, 0, tail);
			}
			else
			{
				Array.Copy(array, head, newArray, 0, array.Length - head); // 길이 - head 몇개인지 나옴
				Array.Copy(array, 0, newArray, array.Length - head, tail); // 위에서 복사한 곳 이후에 넣어야 하니까
			}

			array = newArray;
			head = 0;
			tail = Count;
		}

		private bool IsFull() // 다시보기
		{
			if (head > tail)
			{
				return head == tail + 1;
			}
			else
			{
				return head == 0 && tail == array.Length - 1;
			}
		}

		private bool IsEmpty()
		{
			return head == tail;
		}

		private void MoveNext(ref int index) // tail이 맨 마지막일때는 앞으로 돌아와야 한다.
		{
			index = (index + 1) % array.Length;
		}
	}
}
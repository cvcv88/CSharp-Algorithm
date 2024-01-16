using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	/******************************************************************
     * 어댑터 패턴 (Adapter)
     * 
     * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
     * 
     * 따로 클래스 만들어서 자료구조를 사용하는 방식을 만든다.
     * 리스트의 사용방법, 용도를 변환해주는 것이 어댑터 패턴
     * 스택의 Push, Pop - 리스트 Add, RemoveAt
     ******************************************************************/
	public class Stack<T>
	{
		private List<T> container;

		public Stack()
		{
			container = new List<T>();
		}

		public int count { get { return container.Count; } } // 리스트의 count, 개수
		public void Push(T item)
		{
			container.Add(item);
		}

		public T Pop()
		{
			T item = container[container.Count - 1]; // 가장 마지막에 있는 요소가 꺼내진다.
			container.RemoveAt(container.Count - 1);
			return item;
		}

		public T Peek()
		{
			return container[container.Count - 1];
		}
	}

}

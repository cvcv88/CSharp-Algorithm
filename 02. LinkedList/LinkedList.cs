using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Datastructure
{
	public class LinkedList<T>
	{
		private LinkedListNode<T> head; // 0
		private LinkedListNode<T> tail;
		private int count;

		public LinkedList() // 0
		{
			head = null;
			tail = null;
			count = 0;
		}

		public LinkedListNode<T> First { get { return head; } } // 6
		public LinkedListNode<T> Last { get { return tail; } } // 6
		public int Count { get { return count; } } // 6

		public LinkedListNode<T> AddFirst(T value) //  1
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(value);
			AddBefore(head, value);
			return newNode;
		}

		public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value) // 1
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(value);
			InsertNodeBefore(node, newNode);
			return newNode;
		}

		public LinkedListNode<T> AddLast(T value) // 4
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(value);
			if (head == null)
			{
				InsertNodeToEmptyList(newNode);
			}
			else
			{
				InsertNodeBefore(tail, newNode);
			}

			return newNode;
		}

		public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value) // 4
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(value);
			InsertNodeAfter(node, newNode);
			return newNode;
		}

		public bool Remove(T value) // 5
		{
			LinkedListNode<T> findNode = Find(value);
			if (findNode != null)
			{
				RemoveNode(findNode);
				return true;
			}
			else
			{
				return false;
			}
		}
		public void Remove(LinkedListNode<T> node) // 5
		{
			RemoveNode(node);
		}
		public void RemoveFirst() // 5
		{
			RemoveNode(head);
		}
		public void RemoveLast() // 5
		{
			RemoveNode(tail);
		}

		public LinkedListNode<T> Find(T value) // 5 // 7
		{
			for (LinkedListNode<T> node = First; node != null; node = node.Next)
			{
				if (value.Equals(node.Value))
					return node;
			}
			return null;
		}
		private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode) // 2
		{
			/*newNode.next = node; // 이거는 node 앞에 아무것도 없었을 때만 해당
			node.prev = newNode;
			count++;*/

			LinkedListNode<T> prevNode = node.prev;

			// 1. newNode의 prev를 node의 prev로
			newNode.prev = prevNode;

			// 2. newNode의 next를 node로
			newNode.next = node;

			// 3. node의 prev의 next를 newNode로
			// 3. node 앞의 노드의 유무에 따라 // 3
			if (node == head) // 3 node 앞에 아무것도 없었을 때(or node가 head이면)
			{   // 3.1 head를 newNode로
				head = newNode;
			}
			else // 3.2 node 앞에 있었을 때, node의 prev의 next를 newNode로
			{
				node.prev.next = newNode; // 2
			}

			// 4. node의 prev를 newNode로
			node.prev = newNode;

			count++;
		}

		public void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
		{
			newNode.prev = node;
			newNode.next = node.next;
			if (node == tail)
			{
				tail = newNode;
			}
			else
			{
				node.next.prev = newNode;
			}
			node.next = newNode;

			count++;
		} // 4

		private void InsertNodeToEmptyList(LinkedListNode<T> newNode) // 4
		{
			head = newNode;
			tail = newNode;
			count++;
		}

		private void RemoveNode(LinkedListNode<T> node) // 5
		{
			if (node == null)
				throw new ArgumentNullException("node");
			if (head == node)
				head = node.next;
			if (tail == node)
				tail = node.prev;

			if (node.prev != null)
				node.prev.next = node.next;
			if (node.next != null)
				node.next.prev = node.prev;

			count--;

		}
	}

	public class LinkedListNode<T> // 0
	{
		private T value;

		public LinkedListNode<T> prev; // 어디에 연결되어 있는지 참조값들 갖고 있음
		public LinkedListNode<T> next;

		public LinkedListNode(T value)
		{
			this.value = value;
			this.prev = null;
			this.next = null;
		}
		public LinkedListNode(T value, LinkedListNode<T> prev, LinkedListNode<T> next)
		{
			this.value = value;
			this.prev = prev;
			this.next = next;
		}

		public LinkedListNode<T> Prev { get { return prev; } }
		public LinkedListNode<T> Next { get { return next; } }
		public T Value
		{
			get { return value; }
			set { this.value = value; }
		}
	}
}
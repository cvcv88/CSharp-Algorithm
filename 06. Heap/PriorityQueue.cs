using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSturcture
{
	// Element : 데이터, Priority : 우선순위
	public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
	{
		private struct Node // 구조체하는 이유 : 노드 기반X 배열에다가 넣을 계획이어서
		{
			public TElement element; // 구성요소
			public TPriority priority; // 우선순위

			public Node(TElement element, TPriority priority) // 구성요소, 우선순위
			{
				this.element = element;
				this.priority = priority;
			}
		}

		private List<Node> nodes;

		public PriorityQueue()
		{
			nodes = new List<Node>();
		}

		public int Count { get { return nodes.Count; } }

		public void Enqueue(TElement element, TPriority priority)
		{
			Node newNode = new Node(element, priority); // 새로운 노드 만들기
			nodes.Add(newNode);         // 리스트니까 add
			int index = nodes.Count - 1; // 마지막 나의 위치
			while (index > 0) // 최상단에 도착하기 전까지 반복
			{
				int parentIndex = (index - 1) / 2;
				Node parentNode = nodes[parentIndex];

				if (newNode.priority.CompareTo(parentNode.priority) < 0)
				{
					nodes[index] = parentNode;
					nodes[parentIndex] = newNode;
					index = parentIndex;
				}
				else
				{
					break;
				}
			}
			nodes[index] = newNode;
			// PushHeap(newNode);
		}

		public TElement Peek()
		{
			if (nodes.Count == 0)
				throw new InvalidOperationException();

			return nodes[0].element;
		}

		public TElement Dequeue()
		{
			if (nodes.Count == 0)
				throw new InvalidOperationException();

			Node rootNode = nodes[0];
			// 제거 작업
			// PopHeap();
			Node lastNode = nodes[nodes.Count - 1];
			nodes[0] = lastNode;
			nodes.RemoveAt(nodes.Count - 1);

			int index = 0;
			while(index < nodes.Count)
			{
				int leftIndex = 2 * index + 1;
				int rightIndex = 2 * index + 2;

				if(rightIndex < nodes.Count) // 자식이 둘다 있는 경우
				{
					int lessIndex;
					if (nodes[leftIndex].priority.CompareTo(nodes[rightIndex].priority) < 0)
					{
						lessIndex = leftIndex;
					}
					else
					{
						lessIndex = rightIndex;
					}

					Node lessNode = nodes[lessIndex];
					if (nodes[index].priority.CompareTo(nodes[lessIndex].priority) > 0)
					{
						nodes[lessIndex] = lastNode;
						nodes[index] = lessNode;
						index = lessIndex;
					}
					else
					{
						break;
					}
				}
				else if(leftIndex < nodes.Count) // 자식이 하나만 있는 경우
				{
					Node leftNode = nodes[leftIndex];
					if (nodes[index].priority.CompareTo(nodes[leftIndex].priority) > 0)
					{
						nodes[leftIndex] = lastNode;
						nodes[index] = leftNode;
						index = leftIndex;
					}
					else
					{
						break;
					}
				}
				else // 자식이 없는 경우
				{
					break;
				}
			}

			return rootNode.element;
		}

		private void PushHeap(Node node)
		{
			nodes.Add(node);
			int index = nodes.Count - 1;
			while (index > 0)
			{
				int parentIndex = GetParentIndex(index);
				Node parentNode = nodes[parentIndex];

				if (node.priority.CompareTo(parentNode.priority) < 0)
				{
					nodes[index] = parentNode;
					nodes[parentIndex] = node;
					index = parentIndex;
				}
				else
				{
					break;
				}
			}
			nodes[index] = node;
		}

		private void PopHeap()
		{
			Node node = nodes[nodes.Count - 1];
			nodes[0] = node;
			nodes.RemoveAt(nodes.Count - 1);

			int index = 0;
			while (index < nodes.Count)
			{
				int leftIndex = GetLeftChildIndex(index);
				int rightIndex = GetRightChildIndex(index);

				if (rightIndex < nodes.Count)
				{
					int compareIndex = nodes[leftIndex].priority.CompareTo(nodes[rightIndex].priority) < 0 ?
						leftIndex : rightIndex;

					if (nodes[index].priority.CompareTo(nodes[compareIndex].priority) > 0)
					{
						nodes[index] = nodes[compareIndex];
						index = compareIndex;
					}
					else
					{
						nodes[index] = node;
						break;
					}
				}
				else if (leftIndex < nodes.Count)
				{
					if (nodes[index].priority.CompareTo(nodes[leftIndex].priority) > 0)
					{
						nodes[index] = nodes[leftIndex];
						index = leftIndex;
					}
					else
					{
						nodes[index] = node;
						break;
					}
				}
				else
				{
					nodes[index] = node;
					break;
				}
			}
		}

		private int GetParentIndex(int index)
		{
			return (index - 1) / 2;
		}

		private int GetLeftChildIndex(int index)
		{
			return index * 2 + 1;
		}

		private int GetRightChildIndex(int index)
		{
			return index * 2 + 2;
		}
	}
}

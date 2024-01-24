using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Search
{
	public class Searching
	{
		// <순차탐색>
		// 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
		// 시간복잡도 - O(n)
		public static int SequentialSearch<T>(IList<T> list, T item) where T : notnull
		{ 
			for(int i = 0; i < list.Count; i++)
			{
				if (list[i].Equals(item)){ // 똑같은 찾을 때까지 순차적으로 확인
					return i;
				}
			}
			return -1; // 탐색에서 못찾으면 -1
		}


		// <이진탐색>
		// 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
		// 단, 이진탐색은 정렬이 되어 있는 자료에만 올바른 결과를 도출한다
		// 반드시 정렬이 되어 있어야 함!!
		// 정렬이 보장되어있는 sortedset, sorteddictionary 같은 경우에는 기본적으로 이진탐색을 진행한다.
		// low mid high - 반분할하면서 값 찾는다.
		// 시간복잡도 - O(logn)
		public static int BinarySearch<T>(IList<T> list, T item) where T : IComparable<T>
		{
			int low = 0;
			int high = list.Count - 1;
			while(low <= high)
			{
				int mid = (low + high) / 2; // mid는 low와 high의 중간 값
				int compare = list[mid].CompareTo(item);

				if (compare < 0)
				{
					low = mid + 1;
				}
				else if (compare > 0)
				{
					high = mid - 1;
				}
				else
				{
					return mid;
				}
			}
			return -1;
			}
		/*public static int BinarySearch<T>(IList<int> list, int item)
			{
				int low = 0;
				int high = list.Count - 1;
				while (low <= high)
				{
					int mid = (low + high) / 2; // mid는 low와 high의 중간 값
					if (list[mid] < item)
					{
						low = mid + 1;
					}
					else if (list[mid] > item)
					{
						high = mid - 1;
					}
					else
					{
						return mid;
					}
				}
				return -1;*/


		// <깊이 우선 탐색 (Depth-First Search)>
		// 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
		// 분기의 탐색을 마쳤을 때 다음 분기를 탐색
		// 스택을 통해 구현
		// 메모리 사용 측면에서 너비 우선 탐색보다 좋다.
		public static void DFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
		{
			visited = new bool[graph.GetLength(0)];
			parents = new int[graph.GetLength(0)];

			for (int i = 0; i < graph.GetLength(0); i++)
			{
				visited[i] = false;
				parents[i] = -1; // 나를 찾은 정점이 없다는 뜻
			}

			SearchNode(graph, start, visited, parents);
		}

		private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] parents)
		{
			visited[start] = true;
			for (int i = 0; i < graph.GetLength(0); i++)
			{
				if (graph[start, i] &&      // 연결되어 있는 정점이며,
					!visited[i])            // 방문한적 없는 정점
				{
					parents[i] = start;
					SearchNode(graph, i, visited, parents); // 재귀, 백트래킹
				}
			}
		}

		// <너비 우선 탐색 (Breadth-First Search)>
		// 그래프의 분기를 만났을 때 모든 분기들을 탐색한 뒤,
		// 다음 깊이의 분기들을 탐색
		// 큐를 통해 구현
		// 언제나 최단 경로가 나온다. -> 최단 거리 보장해준다.
		public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
		{
			visited = new bool[graph.GetLength(0)];
			parents = new int[graph.GetLength(0)];

			for (int i = 0; i < graph.GetLength(0); i++)
			{
				visited[i] = false;
				parents[i] = -1;
			}

			visited[start] = true;
			Queue<int> queue = new Queue<int>();
			queue.Enqueue(start);
			while (queue.Count > 0)
			{
				int next = queue.Dequeue();

				for (int i = 0; i < graph.GetLength(0); i++)
				{
					if (graph[next, i] &&       // 연결되어 있는 정점이며,
						!visited[i])            // 방문한적 없는 정점
					{
						visited[i] = true;
						parents[i] = next;
						queue.Enqueue(i);
					}
				}
			}
		}
	}
}

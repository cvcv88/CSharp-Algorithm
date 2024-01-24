using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._ShortesPath_Practice
{
	public class Dijkstra
	{
		const int INF = 99999;
		public static void ShortesPath(int[,] graph, int start, out bool[] visited, out int[] distance, out int[] parents)
		{
			int size = graph.GetLength(0);
			visited = new bool[size];
			distance = new int[size];
			parents = new int[size];

			for (int i = 0; i < size; i++)
			{
				visited[i] = false;
				distance[i] = INF;
				parents[i] = -1;
			}
			distance[start] = 0;


			for(int i = 0; i < size; i++)
			{
				// 1. 방문하지 않은 정점 중 가장 가까운 정점 선택


				// 2. 직접 연결된 거리보다 거쳐서 더 짧아지는 경우 갱신
			}

		}
	}
}

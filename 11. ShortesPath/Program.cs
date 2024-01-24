namespace _11._ShortesPath
{
	internal class Program
	{
		const int INF = 99999;
		static void Main(string[] args)
		{
			int[,] graph =
			{
				{INF, INF, INF, INF, INF, INF, INF, INF },
				{INF, INF, INF, INF, INF, INF, INF, INF },
				{INF, INF, INF, INF, INF, INF, INF, INF },
				{INF, INF, INF, INF, INF, INF, INF, INF },
				{INF, INF, INF, INF, INF, INF, INF, INF },
				{INF, INF, INF, INF, INF, INF, INF, INF },
				{INF, INF, INF, INF, INF, INF, INF, INF },
				{INF, INF, INF, INF, INF, INF, INF, INF },
			};

			Dijkstra.ShortesPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);

			PrintDijkstra(distance, parents);
		}
		private static void PrintDijkstra(int[] distance, int[] path)
		{
			Console.WriteLine($"{"Vertex",10}{"Visit",10}{"Path",10}");

			for (int i = 0; i < distance.Length; i++)
			{
				Console.Write($"{i,10}");

				if (distance[i] >= INF)
				{
					Console.Write($"{"INF",10}");
				}
				else
				{
					Console.Write($"{distance[i],10}");
				}

				Console.WriteLine($"{path[i],10}");
			}
		}
	}
}

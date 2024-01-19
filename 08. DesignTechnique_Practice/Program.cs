namespace _08._DesignTechnique_Practice
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int temp = int.Parse(Console.ReadLine());
			List<int> list = new List<int>();
			string[] tempArray = Console.ReadLine().Split(' ');
			int answer = 0;
			foreach (string str in tempArray)
			{
				list.Add(int.Parse(str));
			}

			list.Sort();

			for (int i = 0; i < temp; i++)
			{
				for (int j = temp; j > i; j--)
				{
					answer += list[i];
				}
			}
			Console.WriteLine(answer);
		}
	}
}

namespace _09._Sort_Practice
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();
			int count = 10;

			List<int> selectionList = new List<int>(count);
			List<int> bubbleList = new List<int>(count);
			List<int> insertionList = new List<int>(count);

			List<int> mergeList = new List<int>(count);

			Console.WriteLine("랜덤 데이터 : ");
			for(int i = 0; i < count; i++)
			{
				int rand = random.Next(1, 100);

				Console.Write($"{rand, 3}");
				selectionList.Add(rand);
				bubbleList.Add(rand);
				insertionList.Add(rand);
				mergeList.Add(rand);

			}
			Console.WriteLine();

			Console.WriteLine("선택 정렬 결과 : ");
			Sorting.SelectionSort(selectionList, 0, selectionList.Count - 1);
			foreach (int value in selectionList)
			{
				Console.Write($"{value,3}");
			}
			Console.WriteLine();


			Console.WriteLine("버블 정렬 결과 : ");
			  Sorting.BubbleSort(bubbleList, 0, bubbleList.Count - 1);
			foreach (int value in bubbleList)
			{
				Console.Write($"{value,3}");
			}
			Console.WriteLine();

			Console.WriteLine("삽입 정렬 결과 : ");
			Sorting.InsertionSort(insertionList, 0, insertionList.Count - 1);
			foreach (int value in insertionList)
			{
				Console.Write($"{value,3}");
			}
			Console.WriteLine();

			Console.WriteLine("합병(병합) 정렬 결과 : ");
			Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);
			foreach (int value in mergeList)
			{
				Console.Write($"{value,3}");
			}
			Console.WriteLine();
		}
	}
}

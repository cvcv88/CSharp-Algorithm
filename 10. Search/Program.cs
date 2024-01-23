namespace _10._Search
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 순차탐색
			int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };

			int indexOf = Array.IndexOf(array, 2);
			int result = Searching.SequentialSearch(array, 2);
			Console.WriteLine($"순차탐색 결과 위치 : {indexOf}");
			Console.WriteLine($"구현한 결과 위치 : {result}");


			// 이진탐색(정렬되어 있는 것을 가정하고 찾기때문에 정렬되어있지 않으면 값 제대로 나오지 않음)
			Console.WriteLine("정렬 전");
			int binarySearch;
			int result2;
			binarySearch = Array.BinarySearch(array, 2);
			result2 = Searching.BinarySearch(array, 2);
			Console.WriteLine($"정렬 전 이진탐색 결과 : {binarySearch}"); // 배열에 2는 있지만 결과 안나옴
			Console.WriteLine($"정렬 전 구현한 이진 탐색 결과 : {result2}");

			Array.Sort(array);

			Console.WriteLine("정렬 후");
			binarySearch = Array.BinarySearch(array, 2);
			result2 = Searching.BinarySearch(array, 2);
			Console.WriteLine($"정렬 후 이진탐색 결과 : {binarySearch}");
			Console.WriteLine($"정렬 전 구현한 이진 탐색 결과 : {result2}");
		}
	}
}

namespace _01._List_Practice
{
	internal class Program
	{
		/*
		 * 1. 사용자에게 숫자 입력받기
		 * 2. 0부터 숫자까지 가지는 리스트 만들기
		 * 3. 0 요소를 제거
		 * 4. 리스트가 가지는 모든 요소들을 출력해주는 반복문 작성
		 * 
		 * 5. 사용자의 입력을 받아서 없던 데이터면 추가, 있던 데이터면 삭제하는 리스트 작성
		 */
		static void Main1(string[] args)
		{
			MyList myList = new MyList();

			myList.DeleteZero();
			myList.PrintList();

			while (true)
			{
				myList.NumberInput();
				myList.PrintList();
			}
		}

		public class MyList
		{
			private List<int> myList;

			public MyList()
			{
				// 1, 2
				myList = new List<int>();
				Console.Write("숫자를 입력해주세요 : ");
				int num = int.Parse(Console.ReadLine());
				for (int i = 0; i < num; i++)
				{
					myList.Add(i);
				}
			}
			public void DeleteZero()
			{
				// 3
				Console.WriteLine("0을 제거합니다.");
				myList.Remove(0); // 0을 제거
			}
			public void PrintList()
			{
				// 4
				foreach (int value in myList)
				{
					Console.Write($"{value} ");
				}
				Console.WriteLine();
			}

			public void NumberInput()
			{
				Console.Write("추가할 숫자를 입력해주세요 : ");
				int num = 0;
				bool result = int.TryParse(Console.ReadLine(), out num);
				if (result)
				{
					if (myList.Contains(num))
						myList.Remove(num);
					else
						myList.Add(num);
				}
				else
				{
					Console.WriteLine("올바른 숫자를 입력해주세요.");
				}

			}

		}
	}
}
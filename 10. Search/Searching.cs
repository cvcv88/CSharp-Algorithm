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
	}
}

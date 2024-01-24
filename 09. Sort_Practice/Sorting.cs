using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort_Practice
{
	public class Sorting
	{
		// 선택 정렬
		public static void SelectionSort(IList<int> list, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				// 제일 작은거 골라서 맨 앞에
				int minIndex = i;
				for (int j = i; j <= end; j++)
				{
					if (list[j] < list[minIndex])
					{
						minIndex = j;
					}
				}
				int temp = list[i];
				list[i] = list[minIndex];
				list[minIndex] = temp;
			}
		}

		// 삽입 정렬
		public static void InsertionSort(IList<int> list, int start, int end)
		{
			for (int i = start + 1; i < end+1; i++)
			{
				for (int j = i; j > 0; j--)
				{
					if (list[j] < list[j - 1])
					{
						int temp = list[j];
						list[j] = list[j - 1];
						list[j - 1] = temp;
					}
					else
					{
						break;
					}
				}
			}
		}

		// 버블 정렬
		public static void BubbleSort(IList<int> list, int start, int end)
		{
			for (int i = start; i < end; i++)
			{
				for (int j = start; j < end; j++)
				{
					if (list[j] > list[j + 1])
					{
						int temp = list[j];
						list[j] = list[j + 1];
						list[j + 1] = temp;
					}
				}
			}
		}

		// 합병(병합) 정렬
		public static void MergeSort(IList<int> list, int start, int end)
		{
			if (start == end) return;

			int mid = (start + end) / 2;
			MergeSort(list, start, mid);
			MergeSort(list, mid + 1, end);
			Merge(list, start, mid, end);
		}
		private static void Merge(IList<int> list, int start, int mid, int end)
		{
			List<int> sortedList = new List<int>();
			int leftIndex = start;
			int rightIndex = mid + 1;

			while (leftIndex <= mid && rightIndex <= end)
			{
				if (list[leftIndex] < list[rightIndex])
				{
					sortedList.Add(list[leftIndex++]);
				}
				else
				{
					sortedList.Add(list[rightIndex++]);
				}
            }
			if(leftIndex > mid)
			{
				for(int i = rightIndex; i <= end; i++)
				{
					sortedList.Add(list[i]);
				}
			}
			else
			{
				for(int i = leftIndex; i <= mid; i++)
				{
					sortedList.Add(list[i]);
				}
			}

			for(int i = 0; i < sortedList.Count; i++)
			{
				list[start + i] = sortedList[i];
			}
        }
	}
}

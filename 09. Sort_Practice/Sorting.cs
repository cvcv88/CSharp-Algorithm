using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sort_Practice
{
	public class Sorting
	{
		public static void SelectionSort(IList<int> list, int start, int end)
		{
			for(int i = start; i < end; i++)
			{
				// 제일 작은거 골라서 맨 앞에
				int minIndex = i;
				for(int j = i; j <= end; j++)
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

		public static void InsertionSort(IList<int> list, int start, int end)
		{
			for(int i = start; i < end; i++)
			{
				for(int j = i; j <= 0; j--)
				{
					if (list[j] > list[j - 1])
					{
						
						break;
					}
				}
			}
		}

		public static void BubbleSort(IList<int> list, int start, int end)
		{
			for(int i = start; i < end; i++)
			{
				for(int j = start; j < end; j++)
				{
					if (list[j] > list[j+1])
					{
						int temp = list[j];
						list[j] = list[j+1];
						list[j+1] = temp;
					}
				}
			}
		}
	}
}

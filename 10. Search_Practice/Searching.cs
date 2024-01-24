using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Search_Practice
{
	public class Searching
	{
		// 순차탐색
		public static int SequentialSearch<T>(IList<T> list, T item) where T : notnull
		{
			for(int i = 0; i <list.Count; i++)
			{
				if (list[i].Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		// 이진탐색
		public static int BinarySearch<T>(IList<T> list, T item) where T : IComparable<T> 
		{ 

		}

	}
}

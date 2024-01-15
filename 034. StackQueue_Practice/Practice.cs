using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _034._StackQueue_Practice
{
	public class Practice
	{
		static void Main(string[] args)
		{
			int[] input = new int[] { 4, 4, 12, 10, 2, 10 };
			int[] result = ProcessJob(input);
		}

		static int[] ProcessJob(int[] jobList)
		{
			Queue<int> queue = new Queue<int>(jobList);
			int[] temp = new int[] { };
			int hour = 8;
			int day = 1;
			int count = 0;
			while(queue.Count > 0)
			{
				
			}
			return jobList;
		}
	}



}

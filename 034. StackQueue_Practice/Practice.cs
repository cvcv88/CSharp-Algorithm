using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace _034._StackQueue_Practice
{
	public class Practice
	{
		static void Main(string[] args)
		{
			int[] result = ProcessJob(new int[] { 4, 4, 12, 10, 2, 10 });
			foreach(int day in result)
			{
				Console.WriteLine(day);
			}
		}

		public const int WorkTime = 8;
		static int[] ProcessJob(int[] jobList)
		{
			Queue<int> queue = new Queue<int>(jobList);
			int remainTime = 8;
			int day = 1;
			List<int> days = new List<int>();
			/*for(int i = 0; i < jobList.Length; i++)
			{
				queue.Enqueue(jobList[i]);
			}*/ // () 괄호안에 배열 이름 넣어줘도 동일함

			while (queue.Count > 0)
			{
				int workTime = queue.Dequeue();
				while (true)
				{
					if (workTime <= remainTime)
					{
						remainTime -= workTime;
						// 작업 완료
						days.Add(day);
					}
					else
					{
						workTime -= remainTime;
						// 다음날로
						day++;
						remainTime = 8;
					}
				}
			}
			return days.ToArray(); // 리스트를 array로 만들기
		}
	}



}

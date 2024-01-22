using _09._Sorting;
using System;
using System.Collections.Generic;

namespace _09._Sort
{
	public class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();
			int count = 10;

			List<int> selectionList = new List<int>(count);
			List<int> insertionList = new List<int>(count);
			List<int> bulbbleList = new List<int>(count);
			List<int> mergeList = new List<int>(count);
			List<int> quickList = new List<int>(count);
			List<int> introList = new List<int>(count);

			Console.WriteLine("랜덤 데이터 : ");
			for (int i = 0; i < count; i++)
			{
				int rand = random.Next(0, 100);

				Console.Write($"{rand,3}");
				selectionList.Add(rand);
				insertionList.Add(rand);
				bulbbleList.Add(rand);
				mergeList.Add(rand);
				quickList.Add(rand);
				introList.Add(rand);
			}
			Console.WriteLine();
			Console.WriteLine("선택 정렬 결과 : ");
			Sorting.SelectionSort(selectionList, 0, selectionList.Count - 1);
			foreach (int value in selectionList)
			{
				Console.Write($"{value, 3}");
			}

			Console.WriteLine();
			Console.WriteLine("삽입 정렬 결과 : ");
			Sorting.InsertionSort(insertionList, 0, insertionList.Count - 1);
			foreach (int value in insertionList)
			{
				Console.Write($"{value, 3}");
			}
			Console.WriteLine();

			Console.WriteLine("버블 정렬 결과 : ");
			Sorting.BubbleSort(bulbbleList, 0, bulbbleList.Count - 1);
			foreach (int value in bulbbleList)
			{
				Console.Write($"{value,3}");
			}
			Console.WriteLine();

			Console.WriteLine("병합(합병) 정렬 결과 : ");
			Sorting.MergeSort(mergeList, 0, mergeList.Count - 1);
			foreach (int value in mergeList)
			{
				Console.Write($"{value,3}");
			}
			Console.WriteLine();

			Console.WriteLine("퀵 정렬 결과 : ");
			Sorting.QuickSort(quickList, 0, quickList.Count - 1);
			foreach (int value in quickList)
			{
				Console.Write($"{value,3}");
			}
			Console.WriteLine();

			Console.WriteLine("C# 인트로 정렬 결과 : "); // 퀵, 힙, 삽입 정렬을 섞은 것
			// 퀵 정렬을 하다가 최악의 경우로 갈떄 힙 정렬로 전환, 개수가 16개 이하일 땐 삽입 정렬 사용(더 빠르기 때문) 
			introList.Sort();
			foreach (int i in introList)
			{
				Console.Write($"{i,3}");
			}
			Console.WriteLine();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09._Sorting
{
	public class Sorting
	{
		// <선택정렬>
		// 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
		// 시간복잡도 -  O(n²)
		// 공간복잡도 -  O(1)
		// 안정정렬   -  O
		public static void SelectionSort(IList<int> list, int start, int end)
		{
			for (int i = start; i <= end; i++)
			{
				int minIndex = i;
				for (int j = i + 1; j <= end; j++)
				{
					if (list[j] < list[minIndex])
					{
						minIndex = j;
					}
				}
				Swap(list, i, minIndex);
			}
		}

		// <삽입정렬>
		// 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
		// 시간복잡도 -  O(n²)
		// 공간복잡도 -  O(1)
		// 안정정렬   -  O
		public static void InsertionSort(IList<int> list, int start, int end)
		{
			for (int i = start; i <= end; i++)
			{
				for (int j = i; j >= 1; j--)
				{
					if (list[j - 1] < list[j])
					{
						break;
					}

					Swap(list, j - 1, j);
				}
			}
		}

		// <버블정렬>
		// 서로 인접한 데이터를 비교하여 정렬
		// 시간복잡도 -  O(n²)
		// 공간복잡도 -  O(1)
		// 안정정렬   -  O
		public static void BubbleSort(IList<int> list, int start, int end)
		{
			for (int i = start; i < end - 1; i++)
			{
				for (int j = start; j < end - i; j++) // 어차피 end까지 할 필요 없음
				{
					if (list[j] > list[j + 1])
					{
						Swap(list, j, j + 1);
					}
				}
			}
		}

		// <합병(병합)정렬>
		// 데이터를 2분할하여 정렬 후 합병
		// 데이터 갯수만큼의 추가적인 메모리가 필요
		// 시간복잡도 -  O(nlogn)
		// 공간복잡도 -  O(n)
		// 안정정렬   -  O
		public static void MergeSort(IList<int> list, int start, int end)
		{
			if (start == end)
			{
				return;
			}

			int mid = (start + end) / 2; // 중간위치 구하기
			MergeSort(list, start, mid); // 반으로 분할(start ~ mid)
			MergeSort(list, mid + 1, end); // 반으로 분할(mid ~ end)
			Merge(list, start, mid, end); // Merge
		}

		private static void Merge(IList<int> list, int start, int mid, int end)
		{
			List<int> sortedList = new List<int>(); // 임시 보관소
			int leftIndex = start;
			int rightIndex = mid + 1;

			// 분할 정렬된 List를 병합
			while (leftIndex <= mid && rightIndex <= end) // left, right가 모두 소진되기 전까지
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

			if (leftIndex > mid) // 남아있는 애들 다 복사해주기
			{
				for (int i = rightIndex; i <= end; i++)
				{
					sortedList.Add(list[i]);
				}
			}
			else
			{
				for (int i = leftIndex; i <= mid; i++)
				{
					sortedList.Add(list[i]);
				}
			}

			for (int i = 0; i < sortedList.Count; i++)
			{
				list[start + i] = sortedList[i];
			}
		}

		// <퀵정렬>
		// 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
		// 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
		// 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
		// 공간복잡도 -  O(1)
		// 안정정렬   -  X
		// ex) 987654321 일때 pivot이 9로 했을 때,, 다음 8,, 7,, 6,, 5,, -> 반분할아닌 하나씩 떨어지는 경우 생길 수 있음
		// pivot 선정을 최대값이나 최소값으로 선정했을 경우 하나씩만 정렬되는 경우가 생긴다.
		public static void QuickSort(IList<int> list, int start, int end)
		{
			if (start >= end) return;

			int pivot = start;
			int left = pivot + 1;
			int right = end;

			while (left <= right)
			{
				while (list[left] <= list[pivot] && left < right) // left가 right 추월하면 안되기때문에 조건 걸어주기
				{
					left++;
				}
				while (list[right] > list[pivot] && left <= right)
				{
					right--;
				}

				if (left < right)
				{
					Swap(list, left, right);
				}
				else
				{
					Swap(list, pivot, right); // pivot 가운데로 가져오기
					break;
				}
			}

			QuickSort(list, start, right - 1);
			QuickSort(list, right + 1, end);
		}

		// <힙정렬>
		// 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
		// 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
		// 시간복잡도 -  O(nlogn)
		// 공간복잡도 -  O(1)
		// 안정정렬   -  X
		// 힙 정렬보다 퀵 정렬이 더 빠름, 왜냐면 힙정렬은 컴퓨터 구조상에 레지스트 친화도가 낮다. 
		// 퀵 정렬은 캐시적중률이 좋아서 더 빠르지만, 힙정렬은 캐시적중률이 낮아서 오히려 더 느려진다.
		// 이론 상으로만 힙정렬이 더 좋음!
		public static void HeapSort(IList<int> list)
		{
			for (int i = list.Count / 2 - 1; i >= 0; i--)
			{
				Heapify(list, i, list.Count);
			}

			for (int i = list.Count - 1; i > 0; i--)
			{
				Swap(list, 0, i);
				Heapify(list, 0, i);
			}
		}

		private static void Heapify(IList<int> list, int index, int size)
		{
			int left = index * 2 + 1;
			int right = index * 2 + 2;
			int max = index;
			if (left < size && list[left] > list[max])
			{
				max = left;
			}
			if (right < size && list[right] > list[max])
			{
				max = right;
			}

			if (max != index)
			{
				Swap(list, index, max);
				Heapify(list, max, size);
			}
		}


		public static void Swap(IList<int> list, int leftIndex, int rightIndex)
		{
			int temp = list[leftIndex];
			list[leftIndex] = list[rightIndex];
			list[rightIndex] = temp;
		}
	}
}

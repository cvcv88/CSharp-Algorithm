using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
	internal class DivideAndConquer
	{
		/*************************************************************************
         * 분할정복 (Divide and Conquer) 작은 문제를 위해서 더 작은 문제의 해법을 구하는 것
         *								-> 큰문제의 답이 나온다!
         * 
         * 큰 문제를 작은 문제로 나눠서 푸는 하향식 접근 방식
         * 분할을 통해서 해결하기 쉬운 작은 문제로 나눈 후 정복한 후 병합하는 과정
         **************************************************************************/

		// 예시 - 거듭 제곱, 2^16 - 4^8 - 16^4 - 256^2
		int Pow(int x, int n) // O(logN)
		{
			if (n == 1)
			{
				return x;
			}

			// 방법 1
			/*if (n % 2 == 0)
			{
				return Pow(x * x, n / 2);
			}
			else
			{
				return Pow(x * x, n / 2) * x;
			}*/

			// 방법 2(홀수고려X)
			/*int reuslt = Pow(x, n / 2); 
			return result * result;*/
			
			// 방법 3
			return Pow(x, n / 2) * Pow(x, n / 2);
		}
		int Pow2(int x, int n) // O(n)
		{
			int result = 1;
			for (int i = 0; i < n; i++)
			{
				result = x * x;
			}
			return result;
		}

		int Pow3(int x, int n) // 동적계획법 예시
		{
			int[] result = new int[n];
				result[0] = x;
			for(int i = 1; i < n ; i++)
			{
				result[i] = result[i - 1] * x;
			}
			return result[n - 1];
		}
	}
}
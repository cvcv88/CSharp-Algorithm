using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
	public class DynamicProgramming
	{
		/**********************************************************************************
         * 동적계획법 (Dynamic Programming) (작은 단위의 해법을 통해서 큰 단위의 해법을 바로 구하는 방법)
         *									 작은단위의 해법 기록해둬서 큰문제에 써먹을 수 있다.
         * 
         * 작은문제의 해답을 큰문제의 해답의 부분으로 이용하는 상향식 접근 방식
         * 주어진 문제를 해결하기 위해 부분 문제에 대한 답을 계속적으로 활용해 나가는 기법
         ***********************************************************************************/

		// 예시 - 피보나치 수열
		int Fibonachi(int x)
		{
			int[] fibonachi = new int[x + 1]; // 동적계획법은 기억해두어야 함
			fibonachi[1] = 1;
			fibonachi[2] = 1;

			for (int i = 3; i <= x; i++)
			{
				fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
			}

			return fibonachi[x];
		}

		int Fibonachi2(int x) // O(2^n) 피보나치는 분할정복으로 풀기에 부적합하다
		{
			if (x == 1)
				return 1;
			else if (x == 2)
				return 1;
			return Fibonachi2(x - 1) + Fibonachi2(x - 2);
		}
	}
}
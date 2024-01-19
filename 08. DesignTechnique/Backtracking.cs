using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._DesignTechnique
{
	public class Backtracking
	{
		/*********************************************************************
         * 백트래킹 (Backtracking)
         * 
         * 모든 경우의 수를 전부 고려하는 알고리즘
         * 후보해를 검증 도중 해가 아닌경우 되돌아가서 다시 해를 찾아가는 기법
         * 
         * <-> greedy algorithm , 모든 상황 다 해보기
         * ex) 미로찾기(모든 길 다 가보기)
         * 
         * 오래 걸리지만 모든 경우의 수를 다 고려하면서 정답을 찾는 방법
         **********************************************************************/

		// 예시 - 폴더삭제
		void RemoveDir(Directory directory)
		{
			foreach (Directory dir in directory.childDir)
			{
				RemoveDir(dir);
			}

			Console.WriteLine("폴더 내 파일 모두 삭제");
		}

		struct Directory
		{
			public List<Directory> childDir;
		}
	}
}
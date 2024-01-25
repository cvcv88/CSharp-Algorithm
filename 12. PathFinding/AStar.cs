using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._PathFinding
{
	public class AStar
	{
		/************************************************************
		* A* 알고리즘 / 엘러, 플러드필 
		* 
		* 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		* 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		* 
		* 다익스트라 알고리즘의 아쉬운점
		* 전 방향(상하좌우)으로 탐색을 진행한다. 중요도가 높지 않은 곳도 탐색한다.
		* -> 목적지 멀수록 더더 시간이 오래 걸림
		* 
		* 다익스트라에서 한가지 바뀜
		* 목적지까지의 유망한 정점부터 우선적으로 탐색한다..
		* 
		* 방문하지 않은 정점 중 ^예상 가중치^가 가장 가까운 정점 선택
		* (다익스트라 : 가장 가까운 정점 선택)
		************************************************************/

		// best 상황일 때 예상되는 소요거리
		// 장애물이 있을 때는 가중치가 더 늘어난다.

		// 가중치 판단기준 : f g h
		// 각각의 칸마다 f, g, h 점수 계산해서 f가 가장 ^낮은^ 칸 부터 간다. f가 총점(f = g + h)
		// g : 실제 이동거리, h : 예상 남은 거리(장애물 고려 안하고 거리 계산하기...)

		// 대각선은 14, 직선은 10, 왜? 계산상의 편의 위해서

		// 휴리스틱(h)에 따라서 성능 차이가 난다.
		// 휴리스틱에 의해서 탐색 순서 정해진다. 경로 정해주는 것

		// 다익스트라에서는 휴리스틱이 1위
		// 휴리스틱에는 맨허튼 거리(가로세로), 유클리드 거리(대각선, 직선) 방법이 있다.

		// 맨허튼 거리 : 도착지까지 직선으로 그은 것, 예상거리를 빠르게 구할 수 있다.
		// 유클리드 거리 : 도착지까지 직접적인 직선(대각선)으로 그은 것, 가로세로 따지는 것x, 계산이 어려움
		// 유클리드 거리 판정은 대각선 한칸에 직선 두칸 이런식으로 경로 구한다.
		// 잘 가고 있으면 예상 점수(f)가 계속 유지가 된다. 점수가 늘어나면 잘못가고 있거나 방해물이 있다는 것.

		// 점수 똑같을때는 g 점수가 높은 것을 조금 더 선호한다.

		const int CostStraight = 10; // 직선
		const int CostDiagonal = 14; // 대각선(곡선)

		static Point[] Direction =
		{
			new Point(  0, +1 ),            // 상
            new Point(  0, -1 ),            // 하
            new Point( -1,  0 ),            // 좌
            new Point( +1,  0 ),            // 우
            new Point( -1, +1 ),            // 좌상
            new Point( -1, -1 ),            // 좌하
            new Point( +1, +1 ),            // 우상
            new Point( +1, -1 )             // 우하
        };


		public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, out List<Point> path)
		{
			int ySize = tileMap.GetLength(0);
			int xSize = tileMap.GetLength(1);

			ASNode[,] nodes = new ASNode[ySize, xSize];
			bool[,] visited = new bool[ySize, xSize];
			PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();
			// int가 작은 순서대로 꺼내 준다.

			// 0. 시작 정점을 생성하여 추가
			ASNode startNode = new ASNode(start, new Point(), 0, Heuristic(start, end)); // 첫 시작 g = 0
			nodes[startNode.pos.y, startNode.pos.x] = startNode;
			nextPointPQ.Enqueue(startNode, startNode.f);

			while (nextPointPQ.Count > 0)
			{
				// 1. 다음으로 탐색할 정점 꺼내기
				ASNode nextNode = nextPointPQ.Dequeue();

				// 2. 방문한 정점은 방문표시
				visited[nextNode.pos.y, nextNode.pos.x] = true;

				// 3. 다음으로 탐색할 정점이 도착지인 경우
				// 도착했다고 판단해서 경로 반환
				if (nextNode.pos.x == end.x && nextNode.pos.y == end.y)
				{
					path = new List<Point>();
					Point point = end;

					while ((point.x == start.x && point.y == start.y) == false)
					{
						path.Add(point);
						point = nodes[point.y, point.x].parent;
					}
					path.Add(start);

					path.Reverse();
					return true;
				}

				// 4. AStar 탐색을 진행, 탐색한 정점 주변의 정점의 점수(개수) 계산)
				// 방향 탐색
				for (int i = 0; i < Direction.Length; i++)
				{
					int x = nextNode.pos.x + Direction[i].x;
					int y = nextNode.pos.y + Direction[i].y;

					// 4-1. 탐색하면 안되는 경우(점수 계산을 하면 안되는 경우) 제외
					// 맵을 벗어났을 경우
					if (x < 0 || x >= xSize || y < 0 || y >= ySize)
						continue;
					// 탐색할 수 없는 정점일 경우
					else if (tileMap[y, x] == false)
						continue;
					// 이미 방문한 정점일 경우
					else if (visited[y, x])
						continue;
					// 대각선으로 이동이 불가능 지역인 경우
					else if (i >= 4 && tileMap[y, nextNode.pos.x] == false && tileMap[nextNode.pos.y, x] == false)
						continue;

					// 4-2. 탐색한 정점 만들기
					int g = nextNode.g + i < 4 ? CostStraight : CostDiagonal;
					// int g = nextNode.g + ((nextNode.pos.x == x || nextNode.pos.y == y) ? CostStraight : CostDiagonal);
					int h = Heuristic(new Point(x, y), end);
					ASNode newNode = new ASNode(new Point(x, y), nextNode.pos, g, h);

					// 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
					if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나(점수계산을 하지 않은 정점이거나)
						nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우(새로운 정점의 f 가중치가 더 낮은경우)
					{
						nodes[y, x] = newNode;
						nextPointPQ.Enqueue(newNode, newNode.f);
					}
				}
			}

			path = null;
			return false;
		}

		// 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
		private static int Heuristic(Point start, Point end)
		{
			int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
			// start.x > end.x ? start.x - end.x : end.x - start.x 이 방법이 더 좋음.
			int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

			// 맨해튼 거리 : 직선을 통해 이동하는 거리
			// return CostStraight * (xSize + ySize);

			// 유클리드 거리 : 대각선을 통해 이동하는 거리
			// return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);

			// 타일맵 거리 : 직선과 대각선을 통해 이동하는 거리
			int straightCount = Math.Abs(xSize - ySize);
			int diagonalCount = Math.Max(xSize, ySize) - straightCount;
			return CostStraight * straightCount + CostDiagonal * diagonalCount;
		}

		private class ASNode
		{
			public Point pos;		// 현재 정점
			public Point parent;    // 이 정점을 탐색한 정점의 위치

			public int g;           // 현재까지의 값(지금까지 이동한 거리), 즉 지금까지 경로 가중치
			public int h;           // 휴리스틱(앞으로 예상되는 값), 목표까지 추정 경로 가중치(장애물 고려X)
			public int f;           // f(x) = g(x) + h(x);

			public ASNode(Point pos, Point parent, int g, int h)
			{
				this.pos = pos;
				this.parent = parent;
				this.g = g;
				this.h = h;
				this.f = g + h;
			}
		}
	}

	public struct Point
	{
		public int x;
		public int y;

		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}


using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJSolutions.Solutions
{
    public class P1753 : IProblem
    {
        Dictionary<int, List<int[]>> lines = new Dictionary<int, List<int[]>>();
        //출력 값 저장
        int[] answer;
        List<int> todoList;

        public void Solve()
        {
            #region 입력
            //v : 정점의 갯수
            //e : 간선의 갯수
            var ve = Console.ReadLine().Split();
            var v = int.Parse(ve[0]);
            var e = int.Parse(ve[1]);

            //k : 시작 정점의 번호
            var k = int.Parse(Console.ReadLine());

            //u, v, w  u에서 v로 가는 가중치 w 인 간선정보
            for (int i = 0; i < e; i++)
            {
                var uvw = Console.ReadLine().Split();
                var u = int.Parse(uvw[0]);
                var vv = int.Parse(uvw[1]);
                var w = int.Parse(uvw[2]);
                if (!lines.ContainsKey(u))
                {
                    lines.Add(int.Parse(uvw[0]), new List<int[]>());
                }
                lines[u].Add(new int[] { vv, w });
            }
            #endregion

            answer = Enumerable.Repeat(int.MaxValue, v).ToArray();
            todoList = Enumerable.Range(1, v).ToList();
            answer[k - 1] = 0;
            GetShortests(k);


            #region 출력
            //출력 : 각 정점까지의 거리. 자기 자신은 0이고, 도달할 수 없을경우 INF 출력
            foreach (var item in answer)
            {
                if (item == int.MaxValue) Console.WriteLine("INF");
                else Console.WriteLine(item);
            }
            #endregion
        }

        public void GetShortests(int start)
        {

            foreach (var item in lines[start])
            {
                var dist = answer[start - 1] + item[1];

                if (answer[item[0] - 1] > dist)
                {
                    answer[item[0] - 1] = dist;
                }
            }

            lines.Remove(start);

            int min = int.MaxValue;
            var nextStart = 0;
            foreach (var item in lines.Keys)
            {
                if (min > answer[item - 1])
                {
                    min = answer[item - 1];
                    nextStart = item;
                }
            }

            if (nextStart != 0) GetShortests(nextStart);
            else return;
        }
    }
}

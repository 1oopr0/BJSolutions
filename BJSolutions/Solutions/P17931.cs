using System;
using System.Linq;
using System.Text;

namespace BJSolutions.Solutions
{
    class P17931 : IProblem
    {
        public void Solve()
        {
            var n = Console.ReadLine();
            var seq = Console.ReadLine();

            var length = int.Parse(n);
            var seqs = seq.Split();

            StringBuilder answer = new StringBuilder();
            int count = 1;
            int prev = int.Parse(seqs[0]);
            answer.Append(seqs[0] + " ");
            for (int i = 1; i < length; i++)
            {
                var num = int.Parse(seqs[i]);
                if (prev < num)
                {
                    answer.Append(seqs[i]);
                    answer.Append(" ");
                    count++;
                    prev = num;
                }
            }

            Console.WriteLine(count);
            Console.WriteLine(answer.ToString());
        }
    }
}

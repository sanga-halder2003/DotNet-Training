using System;
using System.Collections.Generic;
using System.Text;

namespace Mahril_and_Math
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int target = int.Parse(Console.ReadLine());

            Queue<(int num, int step)> q = new Queue<(int, int)>();
            HashSet<int> visited = new HashSet<int>();

            q.Enqueue((10, 0));
            visited.Add(10);

            while (q.Count > 0)
            {
                var (num, step) = q.Dequeue();

                if (num == target)
                {
                    Console.WriteLine(step);
                    return;
                }

                int[] next = { num + 2, num - 1, num * 3 };

                foreach (int x in next)
                {
                    if (x >= 0 && !visited.Contains(x))
                    {
                        visited.Add(x);
                        q.Enqueue((x, step + 1));
                    }
                }
            }
        }
    }
}

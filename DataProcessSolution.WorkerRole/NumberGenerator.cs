using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessSolution.WorkerRole
{
    public class NumberGenerator
    {
        public int NumberGenerated { get; set; }

        public IEnumerable<int> GenerateNumbers()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.Out.WriteLine("Number generated");
                NumberGenerated ++;
                yield return i;
            }
        }
    }
}

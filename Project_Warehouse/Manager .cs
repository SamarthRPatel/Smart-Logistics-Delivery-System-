using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    public class Manager : Worker
    {
        public int teamsize;

        public override void Performtask()
        {
            Console.WriteLine("Manager is asking for Work");

        }

        Worker FindBestWorker(List<Worker> workers)
        {
            Worker best = null;
            foreach (Worker worker in workers)
            {
                if(worker.isAvailable)
                {
                    if (best == null || worker.CalculatePerformance > best.CalculatePerformance())
                    {
                        best = worker;
                    }

                }
            }

            return best;
        }
    }
}

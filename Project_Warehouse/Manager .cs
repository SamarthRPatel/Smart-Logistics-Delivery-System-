using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    public class Manager : Worker
    {
        public int TeamSize;

        public override void PerformTask()
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
                    if (best == null || worker.CalculatePerformance() > best.CalculatePerformance())
                    {
                        best = worker;
                    }

                }
            }

            return best;
        }
        public override void Display()
        {
            Console.WriteLine("Manager Details:");
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Team Size: " + TeamSize);
        }
    }
}

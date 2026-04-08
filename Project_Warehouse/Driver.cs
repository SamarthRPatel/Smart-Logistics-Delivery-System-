using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    public class Driver : Worker
    {
        public string licenseType;

        public override void PerformTask()
        {
            Console.WriteLine("Driver is delivering!");
            AddTask();
        }
    }
}

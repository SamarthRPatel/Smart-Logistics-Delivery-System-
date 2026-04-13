using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    public class Loader : Worker
     {
        public double maxLiftWeight;

        public override void PerformTask()
        {
            Console.WriteLine("Loader is loading packages!");
            addTask();
        }

        public override void Display()
        {
            Console.WriteLine("Loader Details:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Max Lift Weight: " + maxLiftWeight);
        }

    }
    

    
}

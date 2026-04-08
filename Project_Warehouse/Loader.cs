using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    public class Loader : Worker
     {
        public double maxLififtWeight;

        public override void Performtask()
        {
            Console.WriteLine("Loader is loading packages!");
            AddTask();
        }

     }
    

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    public class Package
    {
        public int id;
        public double Weight;
        public int priorityLevel;
        public string destination;
        public string status;


        public double CalculatePriorityScore()
        {
            return priorityLevel * 10 - Weight;
        }
        
        public void UpdateStatus(string newStatus)
        {
            status = newStatus;
        }

        public bool IsHeavy()
        {
            return Weight > 10;
        }





    }
}

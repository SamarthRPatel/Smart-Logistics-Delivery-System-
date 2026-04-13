using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    public abstract class Worker : Entity
    {
        public int experienceYears;
        public int tasksCompleted;
        public bool isAvailable;


        public void addTask()
        {
            tasksCompleted++;
        }

        public virtual double CalculatePerformance()
        {
            return experienceYears + tasksCompleted; 
        }

        public abstract void PerformTask();



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
     class Warehouse
    {
        public string name;
        public List<Package> packages = new List<Package>();
        public List<Vehicle> vehicles = new List<Vehicle>();
        public List<Worker> workers = new List<Worker>();

        public void AddPackage(Package p)
        {
            packages.Add(p);
        }

        public void RemovePackage(int id)
        {
            for (int i = 0; i < packages.Count; i++)
            {
                if (packages[i].id == id) 
                {
                    packages.RemoveAt(i);
                    break;
                }

            }
        }

        public Vehicle FindBestVehicle(Package p)
        {
            Vehicles best = null;

            foreach (Vehicle v in vehicles) 
            {
                if (v.isAvailable && v.GetRemainingCapacity() >= p.weight)
                {
                    if (best == null || v.CalculateEfficiency() > best.CalculateEfficienciy())
                        best = v;
                }

            }
            return best;    
        }

        public Worker AssignWorker()
        {
            foreach (Worker worker in workers)
            {
                if(worker.isAvailable)
                    return worker;
            }

            return null;
        }

        public List<Package> GetPendingPacakages()
        {
            List<Package> list = new List<Package>();
            foreach (Package p in packages)
            {
                if (p.status == "Pending")
                    list.Add(p);
            }
            return list;


        }

    }
}


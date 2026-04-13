using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
     public class Warehouse
    {
        public string name;
        public List<Package> packages = new List<Package>();
        public List<Vehicule> vehicles = new List<Vehicule>();
        public List<Worker> workers = new List<Worker>();

        public void AddPackage(Package p)
        {
            foreach (Vehicule v in vehicles)
            {
                if (v.GetRemainingCapacity() >= p.Weight)
                {
                    packages.Add(p);
                    return;
                }
            }

            Console.WriteLine("Package too heavy for all vehicles!");
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

        public Vehicule FindBestVehicle(Package p)
        {
            Vehicule best = null;

            foreach (Vehicule v in vehicles) 
            {
                if (v.IsAvailable() && v.GetRemainingCapacity() >= p.Weight)
                {
                    if (best == null || v.CalculateEfficiency() > best.CalculateEfficiency())
                    {
                        best = v;
                    }

                   
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

        public List<Package> GetPendingPackages()
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


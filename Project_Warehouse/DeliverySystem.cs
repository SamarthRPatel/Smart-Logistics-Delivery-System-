using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
     class DeliverySystem
     {
        public List<Warehouse> warehouse = new List<Warehouse>();
        public List<Package> allPackages = new List<Package>();

        public void AddWarehouse(Warehouse w)
        {
            warehouse.Add(w);
        }

        public void AddPackage(Package p)
        {
            allPackages.Add(p);
        }

        public Package SearchPackageById(int id)
        {
            foreach (Package p in allPackages)
            {
                if (p.id == id)
                    return p;
            }
            return null;
        }

        public void SortPackages()
        {
            for (int i = 0; i < allPackages.Count - 1; i++)
            {
                for (int j = 0; j < allPackages.Count - 1 - i; j++)
                {
                    if (allPackages[j].CalculatePriorityScore() < allPackages[j + 1].CalculatePriorityScore())
                    {
                        Package temp = allPackages[i];
                        allPackages[j] = allPackages[j + 1];
                        allPackages[j + 1] = temp;
                    }
                }
            }
        }

        public void ProcessDeliveries()
        {
            foreach (Warehouse w in warehouse)
            {
                List<Package> list = w.GetPendingPacakages();

                foreach (Package p in list)
                {
                    Vehicle v = w.FindBestVehicle(p);
                    Worker worker = w.AssignWorker();

                    if (v != null && worker != null)
                    {
                        p.UpdateStatus("Package is Delivered");
                        worker.Performtask();
                        v.currentLoad += p.Weight;

                        Console.WriteLine($"Delivered Pac0kage {p.id}");
                    }
                }
            }
        }

        public void SimulateDay()
        {
            Console.WriteLine("Simulation Started");

            SortPackages();
            ProcessDeliveries();

            Console.WriteLine("Simulation finished.");
        }

        public void Save(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (Package p in allPackages)
            {
                sw.WriteLine($"PAckage | {p.id} | {p.Weight} | {p.priorityLevel} " +
                    $"| {p.destination} | {p.status}");
            }
            sw.Close();
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File not Found");
                return;
            }
        }







     }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
     public class DeliverySystem : IFileHandler
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

            if (warehouse.Count > 0)
                warehouse[0].AddPackage(p);
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
            foreach (Warehouse w in warehouse)
            {
                for (int i = 0; i < w.packages.Count - 1; i++)
                {
                    for (int j = 0; j < w.packages.Count - 1 - i; j++)
                    {
                        if (w.packages[j].CalculatePriorityScore() > w.packages[j + 1].CalculatePriorityScore())
                        {
                            Package temp = w.packages[j];
                            w.packages[j] = w.packages[j + 1];
                            w.packages[j + 1] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("Packages sorted successfully.");
        }

        public void ProcessDeliveries()
        {
            foreach (Warehouse w in warehouse)
            {
                List<Package> list = w.GetPendingPackages();

                foreach (Package p in list)
                {
                    Vehicule v = w.FindBestVehicle(p);
                    Worker worker = w.AssignWorker();

                    if (v != null && worker != null)
                    {
                        p.UpdateStatus("Delivered");
                        worker.PerformTask();
                        v.currentLoad += p.Weight;

                        Console.WriteLine($"Delivered Package {p.id}");
                    }
                    else
                    {
                        Console.WriteLine($"Package {p.id} is not delivered");
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
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Warehouse w in warehouse)
                {
                    // save details ofpackages
                    foreach (Package p in w.packages)
                    {
                        sw.WriteLine($"Package :{p.id} | Weight:{p.Weight} Priority {p.priorityLevel} Status: {p.status}  ");
                    }

                    // save details of vehicles
                    foreach (Vehicule v in w.vehicles)
                    {
                        string type = v.GetType().Name;

                        sw.WriteLine($"Vehicle: {v.GetName()} Type: {type} Capacity: {v.maxCapacity}");
                    }

                    // save details of workers
                    foreach (Worker worker in w.workers)
                    {
                        string type = worker.GetType().Name;

                        sw.WriteLine($"Worker name : {worker.GetName()} Type: {type} Exp-Years:  {worker.experienceYears}");
                    }
                }
            }
            Console.WriteLine("Data saved successfully.");
        }

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            Warehouse w = new Warehouse();
            w.name = "Loaded Warehouse";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] p = line.Split('|');

                // ++++++++Package++++
                if (p[0] == "PACKAGE")
                {
                    Package pkg = new Package();
                    pkg.id = int.Parse(p[1]);
                    pkg.Weight = double.Parse(p[2]);
                    pkg.priorityLevel = int.Parse(p[3]);
                    pkg.destination = p[4];
                    pkg.status = p[5];

                    w.packages.Add(pkg);
                }

                // ++++++++Vehicule++++
                else if (p[0] == "VEHICLE")
                {
                    Vehicule v = null;

                    if (p[2] == "Truck") v = new Truck();
                    else if (p[2] == "Van") v = new Van();
                    else if (p[2] == "Drone") v = new Drone();

                    if (v != null)
                    {
                        v.SetName(p[1]);
                        v.SetCapacity(double.Parse(p[3]));
                        w.vehicles.Add(v);
                    }
                }

               // ++++++++Worker++++
                else if (p[0] == "WORKER")
                {
                    Worker worker = null;

                    if (p[2] == "Driver") worker = new Driver();
                    else if (p[2] == "Loader") worker = new Loader();
                    else if (p[2] == "Manager") worker = new Manager();

                    if (worker != null)
                    {
                        worker.SetName(p[1]);
                        worker.experienceYears = int.Parse(p[3]);
                        w.workers.Add(worker);
                    }
                }
            }

            warehouse.Add(w);

            Console.WriteLine("Data loaded successfully.");
        }

    }
}

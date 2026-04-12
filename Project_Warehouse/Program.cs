using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
     class Program
    {
        static void Main(string[] args)
        {
            DeliverySystem ds = new DeliverySystem();
            CustomStack<string> undoStack = new CustomStack<string>();

            int choice = -1;

            while (choice > 0) 
            {
                Console.WriteLine("\n +++++ Welcome to Delivery System ++++++++");
                Console.WriteLine("1 - Add Package");
                Console.WriteLine("2 - Search Package");
                Console.WriteLine("3 - Sort Package");
                Console.WriteLine("4 - Run Simulation");
                Console.WriteLine("5 - Undo");
                Console.WriteLine("6 - Save");
                Console.WriteLine("7 - Load");
                Console.WriteLine("8 - Exit");
                Console.WriteLine("\n");

                Console.WriteLine("Please enter your Choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Package p = new Package();

                        Console.Write("ID of Package: ");
                        p.id = int.Parse(Console.ReadLine());

                        Console.Write("Weight of Package: ");
                        p.Weight = double.Parse(Console.ReadLine());

                        Console.Write("Priority: ");
                        p.priorityLevel = int.Parse(Console.ReadLine());

                        Console.Write("Destination of Package: ");
                        p.destination = Console.ReadLine();

                        p.status = "Package is Pending";

                        ds.AddPackage(p);
                        undoStack.Push("Package is Added");

                        break;

                     case 2:
                        Console.WriteLine("Search Package ID");
                        int id = int.Parse(Console.ReadLine());

                        var result = ds.SearchPackageById(id);

                        if (result != null)
                            Console.WriteLine("We found the Package");
                        else
                            Console.WriteLine("Package not found");

                            break;

                        case 3:
                        ds.SortPackages();
                        Console.WriteLine("Sorted");

                        break;

                        case 4:
                        ds.SimulateDay();
                        break ;

                        case 5:
                        if (!undoStack.IsEmpty())
                        {
                            undoStack.Pop();
                            Console.WriteLine("Undo done");
                        }
                        break;

                        case 6:
                        ds.Save("data.txt");
                        Console.WriteLine("Saved");
                        break;

                        case 7:
                        ds.Load("data.txt");
                        Console.WriteLine("Loaded");
                        break;


                }

            }
        }
    }
}

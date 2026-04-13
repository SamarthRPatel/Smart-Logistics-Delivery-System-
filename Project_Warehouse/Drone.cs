using Project_Warehouse;
using System;
using System.Collections.Generic;

public class Drone : Vehicule
{
    private double maxDistance;

    public override void Deliver(List<Package> packages)
    {
        foreach (Package p in packages)
        {
            if (p.IsHeavy())   
            {
                Console.WriteLine($"Drone cannot carry heavy package {p.id}");
            }
            else
            {
                if (GetRemainingCapacity() >= p.Weight)
                {
                    currentLoad += p.Weight;
                    Console.WriteLine($"Drone delivered package {p.id}");
                }
            }
        }
    }

    public override void Display()
    {
        Console.WriteLine("+++++++++++Drone Details+++++++++++");
        Console.WriteLine("Drone Name: " + name);
        Console.WriteLine("Drone ID: " + id);
        Console.WriteLine("Drone Capacity: " + maxCapacity);
    }
}
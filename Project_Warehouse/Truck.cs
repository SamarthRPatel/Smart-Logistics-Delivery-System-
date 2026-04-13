using Project_Warehouse;
using System;
using System.Collections.Generic;

public class Truck : Vehicule
{
    private double fuelConsumption;

    public override void Deliver(List<Package> packages)
    {
        foreach (Package p in packages)
        {
            if (p.Weight > 20)
            {
                if (GetRemainingCapacity() >= p.Weight)
                {
                    currentLoad += p.Weight;
                    Console.WriteLine("Truck delivered package " + p.id);
                }
                else
                {
                    Console.WriteLine("Capacity Of Truck is full");
                }
            }
            else
            {
                Console.WriteLine("Truck cannot carry this package " + p.id);
            }
        }
    }

    public override double CalculateEfficiency()
    {
        return maxCapacity - currentLoad - fuelConsumption;
    }

    public override void Display()
    {
        Console.WriteLine("+++++++++++Truck Details+++++++++++");
        Console.WriteLine("Truck Name: " + name);
        Console.WriteLine("Truck ID: " + id);
        Console.WriteLine("Truck Capacity: " + maxCapacity);
    }
}
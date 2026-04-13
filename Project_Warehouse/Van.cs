using Project_Warehouse;
using System;
using System.Collections.Generic;

public class Van : Vehicule
{
    public bool isElectric;

    public override void Deliver(List<Package> packages)
    {
        foreach (Package p in packages)
        {
            if (p.Weight >= 5 && p.Weight <= 20)
            {
                if (GetRemainingCapacity() >= p.Weight)
                {
                    currentLoad += p.Weight;
                    Console.WriteLine("Van delivered package " + p.id);
                }
                else
                {
                    Console.WriteLine("Van capacity full");
                }
            }
            else
            {
                Console.WriteLine("Van can't delivered this package " + p.id);
            }
        }
    }

    public override void Display()
    {
        Console.WriteLine("+++++++Van Details++++++++");
        Console.WriteLine("Van Name: " + name);
        Console.WriteLine("Van ID: " + id);
        Console.WriteLine("Van Capacity: " + maxCapacity);
    }
}
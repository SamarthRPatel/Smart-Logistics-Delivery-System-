using Project_Warehouse;
using System;
using System.Collections.Generic;

public abstract class Vehicule : Entity
{

    public abstract void Deliver(List<Package> packages);

    public double speed;
    public double maxCapacity;
    public double currentLoad;
    public bool isAvailable;

    // set capacity with validation
    public void SetCapacity(double capacity)
    {
        if (capacity <= 0)
        {
            Console.WriteLine("Capacity must be greater than 0");
        }
        else
        {
            maxCapacity = capacity; 
        }
    }

    public void AddLoad(double weight)
    {
        if (currentLoad + weight > maxCapacity)
        {
            throw new OverCapacityException("Vehicle capacity exceeded!");
        }

        currentLoad += weight;
    }

    // remaining space in vehicle
    public double GetRemainingCapacity()
    {
        return maxCapacity - currentLoad;
    }

    public virtual double CalculateEfficiency()
    {
        return maxCapacity - currentLoad;
    }


    public bool IsAvailable()
    {
        return isAvailable;
    }
}

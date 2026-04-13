public abstract class Vehicule : Entity
{
    protected double speed;
    protected double maxCapacity;
    protected double currentLoad;
    protected bool isAvailable;

    public void SetCpacity(double capacity)
    {
        capacity > 0;
        if (capacity <= 0)
        {
            Console.WriteLine("Capacity has to be bigger than 0");
        }
    }


    public double GetRemainingCapacity()
    {
        return maxCapacity - currentLoad;
    }


    public abstract void Deliver(List<Package> packages);

}
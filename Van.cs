public class Van : Vehicule
{
    private bool isElectric;

    public override void Deliver (List <Package> packages)
    {
        foreach (Package p in packages)
        {
            if(p.isHeavy())
            {
                if (GetRemainingCapacity() < p.weight)
                Console.WriteLine("Its too heavy");
            }
        }
    }
}
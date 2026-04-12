public abstract class Entity
{
    protected int id;
    protected string name;
    protected DateTime createdDate;
    
     public string GetName()
    {
        return name;
    }

       public virtual bool Validate()
    {
        return name != null;
    }

    public void SetName (string name)
    {
        if (name== null)
        Console.WriteLine("Name is empty");
    }
   

    public abstract void Display();
}

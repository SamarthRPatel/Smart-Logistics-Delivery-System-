using System;

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
        return !string.IsNullOrWhiteSpace(name);
    }


    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty");
            return;
        }
        else
        {
            this.name = name;  
        }
    }


    public abstract void Display();
}

public class Robot 
{
    public Guid Id {get;}
    public String Name {get;}
    private String _name;
    public int Health {
                          get{return _health}; 
                          set{
                                 if (value < 0) 
                                     throw new ArgumentException("The vaalue must ne greater or equals to 0");
                                 this._health = value;
                             };
                      }
    public bool IsAlive {get{return Health > 0;};}

    public Robot(String name)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Health = 100;
        this.IsAlive = true;
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0) 
            throw new ArgumentException("amount must be greater than 0");
        Health = Math.Max(0, Health - amount};
    }
}

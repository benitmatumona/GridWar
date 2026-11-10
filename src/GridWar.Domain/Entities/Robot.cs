public class Robot 
{
    public Guid Id {get;}
    public String Name {get;}
    public int Health {
                          get; 
                          set{
                                 if (value < 0) 
                                     throw new ArgumentException("The vaalue must ne greater or equals to 0");
                                 this.Health = value;
                             };
                      }
    public bool IsAlive {
                            get;
                            set
                            {
                                IsAlive = Health > 0; 
                            };
                        }

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
        if (Health - amount >= 0) Health -= amount;
    }
}

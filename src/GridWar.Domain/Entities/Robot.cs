namespace GridWar.Domain.Entities;

public class Robot
{
    public Guid Id { get; }

    public string Name { get; }

    private int _health;

    public int Health
    {
        get { return _health; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("Health cannot be negative.");

            _health = value;
        }
    }

    public bool IsAlive => Health > 0;

    public Robot(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Robot name cannot be empty.");

        Id = Guid.NewGuid();
        Name = name.Trim();
        Health = 100;
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Damage must be greater than zero.");

        Health = Math.Max(0, Health - amount);
    }
}

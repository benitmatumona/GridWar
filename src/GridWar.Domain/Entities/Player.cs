namespace GridWar.Domain.Entities;

public class Player
{
    public Guid Id {get;}
    public string Username {get;}
    private List<Robot> _robots;
    public IReadOnlyList<Robot> Robots 
    {
        get 
        {
            return _robots.AsReadOnly();
        }
    }

    public Player(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty.");

        Id = Guid.NewGuid();
        Username = username.Trim();
        _robots = new List<Robot>();
    }
    
    public bool IsEliminated 
    {
        get
        {
            if (_robots.Count > 0)
            {
                return _robots.All(robot => !robot.IsAlive);
            }
         return false;
        }
    }

    public void AddRobot(Robot robot)
    {
        ArgumentNullException.ThrowIfNull(robot);
        _robots.Add(robot);
    }

}

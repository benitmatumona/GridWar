using GridWar.Domain.Entities;


public class RobotTests
{ 
    [Fact]
    public void NewRobot_StartsWith100Health()
    { 
        var robot = new Robot("test");
        Assert.Equal(100, robot.Health);
    }
}



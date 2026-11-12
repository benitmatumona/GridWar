using GridWar.Domain.Entities;

public class PlayerTests
{
    [Fact]
    public void AddingRobotIncreasesCountBy1()
    {
        Player player = new Player("player test");
        Robot robot = new Robot("robot test");
        player.AddRobot(robot);
        Assert.Single(player.Robots);
        Assert.Same(robot, player.Robots[0]);
    }

    [Fact]
    public void AddingNullRobotThrowsException()
    {
        Player player = new Player("player test");
        Assert.Throws<ArgumentNullException>(
            () => player.AddRobot(null!)
        );
    }

}

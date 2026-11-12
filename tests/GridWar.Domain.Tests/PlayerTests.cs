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

    [Fact]
    public void PlayerHasNoRobotsIsNotEliminated()
    {
        Player player = new Player("player test");
        Assert.False(player.IsEliminated);
    }

    [Fact]
    public void PlayerHasOneLivingRobotIsFalse()
    {
        Player player = new Player("player test");
        Robot robot = new Robot("robot test");
        player.AddRobot(robot);
        Assert.False(player.IsEliminated);
    }

    [Fact]
    public void PlayerHasOneDestroyedRobotIsTrue()
    {
        Player player = new Player("player test");
        Robot robot = new Robot("robot test");
        player.AddRobot(robot);
        robot.TakeDamage(100);
        Assert.True(player.IsEliminated);
    }

    [Fact]
    public void PlayerIsEliminatedOnlyWhenAllRobotsAreDestroyed()
    {
        Player player = new Player("player test");
        Robot robot1 = new Robot("robot test");
        Robot robot2 = new Robot("robot test2");
        player.AddRobot(robot1);
        player.AddRobot(robot2);
        
        robot1.TakeDamage(100);
        robot2.TakeDamage(20);
        Assert.False(player.IsEliminated);
        
        robot2.TakeDamage(80);
        Assert.True(player.IsEliminated);
    }
}

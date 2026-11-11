using GridWar.Domain.Entities;


public class RobotTests
{ 
    [Fact]
    public void NewRobot_StartsWith100Health()
    { 
        var robot = new Robot("test");
        Assert.Equal(100, robot.Health);
    }

    [Fact]
    public void ThirtyDamageDecreaseHealthBy70()
    {
        var robot = new Robot("test");
        robot.TakeDamage(30);
        Assert.Equal(70, robot.Health);
    }

    [Fact]
    public void TakeDamage_WhenDamageExceedsHealth_SetsHealthToZero()
    {
        var robot = new Robot("test");
        robot.TakeDamage(80);
        robot.TakeDamage(50);
        Assert.Equal(0, robot.Health);
        Assert.False(robot.IsAlive);
    }

    [Fact]
    public void TakeDamage_WhenAmountIsZero_ThrowsArgumentException()
    {
        var robot = new Robot("test");
        Assert.Throws<ArgumentException>(() => robot.TakeDamage(0));
    }

    [Fact]
    public void TakeDamage_WhenAmountIsNegative_ThrowsArgumentException()
    {
        var robot = new Robot("test");
        Assert.Throws<ArgumentException>(() => robot.TakeDamage(-10));
    }

    [Fact]
    public void Constructor_WhenNameIsEmpty_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Robot(""));
    }

    [Fact]
    public void Constructor_WhenNameContainsOnlyWhitespace_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Robot("   "));
    }

    [Fact]
    public void Constructor_WhenNameIsNull_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Robot((string)null!));
    }


}



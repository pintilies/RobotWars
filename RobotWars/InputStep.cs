namespace RobotWars
{
    /// <summary>
    /// A workflow step definition, used to identify the type of command expected on user input.
    /// At the beginning we have Initialize, were we define the dimension of arena.
    /// After than there can be as many Robot position followed by Robot commands, as necessary.
    /// </summary>
    public enum InputStep
    {
        Initialize = 1,
        SetRobotPosition,
        MoveRobot
    }
}

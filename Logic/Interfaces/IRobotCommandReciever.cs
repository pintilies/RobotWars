namespace RobotWars.Logic.Interfaces
{
    /// <summary>
    /// The interface for the command sent to move the Robot. Has to be implemented by the class which actually is changing the coordinates and position of the robot.
    /// </summary>
    public interface IRobotCommandReciever
    {
        void Move(int id, RobotCommandType commandType);
    }
}

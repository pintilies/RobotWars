using RobotWars.Logic.Interfaces;

namespace RobotWars.Logic
{
    /// <summary>
    /// Command class used to call the reciever to perform a "spin right" movement on the Robot
    /// </summary>
    public class RobotCommandSpinRight
    {
        private IRobotCommandReciever _commandReciever;

        public RobotCommandSpinRight(IRobotCommandReciever commandReciever)
        {
            _commandReciever = commandReciever;
        }

        public void Execute(int robotId)
        {
            _commandReciever.Move(robotId, RobotCommandType.R);
        }
    }
}

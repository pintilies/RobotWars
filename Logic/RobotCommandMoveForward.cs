using RobotWars.Logic.Interfaces;

namespace RobotWars.Logic
{
    /// <summary>
    /// Command class used to call the reciever to perform a forward movement on the Robot
    /// </summary>
    public class RobotCommandMoveForward
    {
        private IRobotCommandReciever _commandReciever;

        public RobotCommandMoveForward(IRobotCommandReciever commandReciever)
        {
            _commandReciever = commandReciever;
        }

        public void Execute(int robotId)
        {
            _commandReciever.Move(robotId, RobotCommandType.M);
        }
    }
}

using RobotWars.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Logic
{
    /// <summary>
    /// Command class used to call the reciever to perform a "spin left" movement on the Robot
    /// </summary>
    public class RobotCommandSpinLeft
    {
        private IRobotCommandReciever _commandReciever;

        public RobotCommandSpinLeft(IRobotCommandReciever commandReciever)
        {
            _commandReciever = commandReciever;
        }

        public void Execute(int robotId)
        {
            _commandReciever.Move(robotId, RobotCommandType.L);
        }
    }
}

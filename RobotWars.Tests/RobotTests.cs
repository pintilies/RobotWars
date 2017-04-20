using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Tests
{
    [TestClass]
    public class RobotTests
    {
        /// <summary>
        /// Testing if the robot has been created correctly and added to the arena
        /// </summary>
        [TestMethod]
        public void TestCorrectCreation()
        {
            Arena.Instance.Init(10, 10);

            int robotId = RobotFactory.CreateRobot(2, 4, RobotOrientation.E);

            Assert.AreNotEqual(robotId, 0);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).X, 2);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Y, 4);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.E);
        }

        /// <summary>
        /// Testing if the robot has not been created correctly because of placement out of arena
        /// </summary>
        [TestMethod]
        public void TestNotCorrectCreationOutOfBounderies()
        {
            Arena.Instance.Init(10, 10);

            Assert.ThrowsException<Exception>(() => RobotFactory.CreateRobot(2, 14, RobotOrientation.E), "Robot Y position cannot be greater than 10");
            Assert.ThrowsException<Exception>(() => RobotFactory.CreateRobot(10, 1, RobotOrientation.E), "Robot X position cannot be greater than 10");
            Assert.ThrowsException<Exception>(() => RobotFactory.CreateRobot(-1, 1, RobotOrientation.E), "Robot X position cannot be lower than 0");
            Assert.ThrowsException<Exception>(() => RobotFactory.CreateRobot(5, -2, RobotOrientation.E), "Robot Y position cannot be lower than 0");
        }
    }
}

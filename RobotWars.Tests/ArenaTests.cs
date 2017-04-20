using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotWars.Logic;

namespace RobotWars.Tests
{
    [TestClass]
    public class ArenaTests
    {
        /// <summary>
        /// Testing of validation of the maximum width arena
        /// </summary>
        [TestMethod]
        public void TestCorrectInitializationValidationWidthMax()
        {
            Assert.ThrowsException<ArgumentException>(() => Arena.Instance.Init(40, 2));
        }

        /// <summary>
        /// Testing of validation of the maximum height arena
        /// </summary>
        [TestMethod]
        public void TestCorrectInitializationValidationHeightMax()
        {
            Assert.ThrowsException<ArgumentException>(() => Arena.Instance.Init(4, 50));
        }

        /// <summary>
        /// Testing of validation of the maximum width arena
        /// </summary>
        [TestMethod]
        public void TestCorrectInitializationValidationWidthMin()
        {
            Assert.ThrowsException<ArgumentException>(() => Arena.Instance.Init(-1, 2));
        }

        /// <summary>
        /// Testing of validation of the maximum height arena
        /// </summary>
        [TestMethod]
        public void TestCorrectInitializationValidationHeightMin()
        {
            Assert.ThrowsException<ArgumentException>(() => Arena.Instance.Init(4, -1));
        }

        /// <summary>
        /// Testing if the Robot spinnes correctly
        /// </summary>
        [TestMethod]
        public void TestCorrectSpinningOfRobot()
        {
            Arena.Instance.Init(5, 5); ;
            int robotId = RobotFactory.CreateRobot(2, 2, RobotOrientation.N);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.W);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.S);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.E);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.N);

            Arena.Instance.Move(robotId, RobotCommandType.R);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.E);

            Arena.Instance.Move(robotId, RobotCommandType.R);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.S);

            Arena.Instance.Move(robotId, RobotCommandType.R);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.W);

            Arena.Instance.Move(robotId, RobotCommandType.R);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Orientation, RobotOrientation.N);
        }

        /// <summary>
        /// Testing if the Robot moves correctly
        /// </summary>
        [TestMethod]
        public void TestCorrectMovingOfRobot()
        {
            Arena.Instance.Init(5, 5); ;
            int robotId = RobotFactory.CreateRobot(2, 2, RobotOrientation.N);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Arena.Instance.Move(robotId, RobotCommandType.M);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).X, 1);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Arena.Instance.Move(robotId, RobotCommandType.M);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Y, 1);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Arena.Instance.Move(robotId, RobotCommandType.M);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).X, 2);

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Arena.Instance.Move(robotId, RobotCommandType.M);
            Assert.AreEqual(Arena.Instance.GetRobot(robotId).Y, 2);
        }

        /// <summary>
        /// Testing if the exception is raised when robot tries to move outside of bouderies
        /// </summary>
        [TestMethod]
        public void TestOutOfLeftBottomBounderiesException()
        {
            Arena.Instance.Init(5, 5); ;
            int robotId = RobotFactory.CreateRobot(0, 0, RobotOrientation.W);
            Assert.ThrowsException<Exception>(() => Arena.Instance.Move(robotId, RobotCommandType.M), "Robot cannot move to West, it is already at the limit");

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Assert.ThrowsException<Exception>(() => Arena.Instance.Move(robotId, RobotCommandType.M), "Robot cannot move to South, it is already at the limit");
        }
        /// <summary>
        /// Testing if the exception is raised when robot tries to move outside of bouderies
        /// </summary>
        [TestMethod]
        public void TestOutOfTopRightBounderiesException()
        {
            Arena.Instance.Init(5, 5); ;
            int robotId = RobotFactory.CreateRobot(4, 4, RobotOrientation.E);
            Assert.ThrowsException<Exception>(() => Arena.Instance.Move(robotId, RobotCommandType.M), "Robot cannot move to East, it is already at the limit");

            Arena.Instance.Move(robotId, RobotCommandType.L);
            Assert.ThrowsException<Exception>(() => Arena.Instance.Move(robotId, RobotCommandType.M), "Robot cannot move to North, it is already at the limit");
        }
    }
}
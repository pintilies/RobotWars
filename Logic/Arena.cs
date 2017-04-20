using RobotWars.Logic.Interfaces;
using System;
using System.Collections.Generic;

namespace RobotWars.Logic
{
    /// <summary>
    /// This class represents an arena, where all robots are kept, together with positions
    /// The class also handles the movement of the robots.
    /// </summary>
    public class Arena : IRobotCommandReciever
    {
        #region Private Fields
        private static Arena _instance;
        private static object _lockObject = new object();

        private const int MaxSize = 20;
        private Dictionary<int, Robot> _robots = new Dictionary<int, Robot>();
        private int _width = 0;
        private int _height = 0;
        private int _robotCurrentIndex = 1;
        #endregion

        #region Public Fields
        public int Width => _width;
        public int Height => _height;
        #endregion

        private Arena() { }

        /// <summary>
        /// Using one Arena in our application
        /// </summary>
        public static Arena Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lockObject)
                        if (_instance == null)
                            _instance = new Arena();

                return _instance;
            }
        }

        /// <summary>
        /// Initializing/Re-initializing the Arena, with specific dimensions
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Init(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException($"Parameter \"{width.GetType().Name}\" needs to be greater than 0");

            if (width > MaxSize)
                throw new ArgumentException($"Parameter \"{width.GetType().Name}\" needs to be lower than {MaxSize}");

            if (height <= 0)
                throw new ArgumentException($"Parameter \"{height.GetType().Name}\" needs to be greater than 0");

            if (height > MaxSize)
                throw new ArgumentException($"Parameter \"{height.GetType().Name}\" needs to be lower than {MaxSize}");

            _width = width;
            _height = height;
            _robots.Clear();
            _robotCurrentIndex = 1;
        }

        /// <summary>
        /// Adds a robot into Arena and returns the ID of the robot.
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        public int AddRobot(Robot robot)
        {
            if (_width == 0 || _height == 0)
                throw new Exception("Arena is not initialized");

            if (robot.X < 0)
                throw new Exception("Robot X position cannot be lower than 0");

            if (robot.Y < 0)
                throw new Exception("Robot Y position cannot be lower than 0");

            if (robot.X >= _width)
                throw new Exception($"Robot X position has to be greater than {_width}");

            if (robot.Y >= _height)
                throw new Exception($"Robot Y position cannot be greater than {_height}");

            _robots[_robotCurrentIndex++] = robot;

            return _robotCurrentIndex - 1;
        }

        /// <summary>
        /// Gets a robot information based on ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Robot GetRobot(int id) => _robots[id];

        /// <summary>
        /// This method is doing the actual logic of moving a Robot inside of Arena. It takes the ID of the robot and the movement type.
        /// </summary>
        /// <param name="id">Id of the robot</param>
        /// <param name="commandType">Command type that specify the movement</param>
        /// <returns></returns>
        public void Move(int id, RobotCommandType commandType)
        {
            if (_width == 0 || _height == 0)
                throw new Exception("Arena is not initialized");

            if (!_robots.ContainsKey(id))
                throw new Exception($"Robot with id {id} doesn't exists");

            Robot robot = _robots[id];

            switch (commandType)
            {
                case RobotCommandType.L:
                    switch (robot.Orientation)
                    {
                        case RobotOrientation.N:
                            robot.Orientation = RobotOrientation.W;
                            break;
                        case RobotOrientation.W:
                            robot.Orientation = RobotOrientation.S;
                            break;
                        case RobotOrientation.E:
                            robot.Orientation = RobotOrientation.N;
                            break;
                        case RobotOrientation.S:
                            robot.Orientation = RobotOrientation.E;
                            break;
                        default:
                            break;
                    }
                    break;
                case RobotCommandType.R:
                    switch (robot.Orientation)
                    {
                        case RobotOrientation.N:
                            robot.Orientation = RobotOrientation.E;
                            break;
                        case RobotOrientation.W:
                            robot.Orientation = RobotOrientation.N;
                            break;
                        case RobotOrientation.E:
                            robot.Orientation = RobotOrientation.S;
                            break;
                        case RobotOrientation.S:
                            robot.Orientation = RobotOrientation.W;
                            break;
                        default:
                            break;
                    }
                    break;
                case RobotCommandType.M:
                    switch (robot.Orientation)
                    {
                        case RobotOrientation.N:
                            if (robot.Y + 1 >= _height)
                                throw new Exception("Robot cannot move to North, it is already at the limit");

                            robot.Y++;
                            break;
                        case RobotOrientation.W:
                            if (robot.X == 0)
                                throw new Exception("Robot cannot move to West, it is already at the limit");

                            robot.X--;
                            break;
                        case RobotOrientation.E:
                            if (robot.X + 1 >= _width)
                                throw new Exception("Robot cannot move to East, it is already at the limit");

                            robot.X++;
                            break;
                        case RobotOrientation.S:
                            if (robot.Y == 0)
                                throw new Exception("Robot cannot move to South, it is already at the limit");

                            robot.Y--;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            _robots[id] = robot; //setting here value since robot is struct
        }
    }
}

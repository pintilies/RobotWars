namespace RobotWars.Logic
{
    /// <summary>
    /// Factory used to create a robot and add it to the Arena.
    /// </summary>
    public static class RobotFactory
    {
        public static int CreateRobot(int x, int y, RobotOrientation orientation)
        {
            Robot robot;
            robot.X = x;
            robot.Y = y;
            robot.Orientation = orientation;


            return Arena.Instance.AddRobot(robot);
        }
    }
}

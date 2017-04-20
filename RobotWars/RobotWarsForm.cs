using RobotWars.Logic;
using RobotWars.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RobotWars
{
    public partial class RobotWarsForm : Form
    {
        private RobotCommandSpinLeft _robotCommandLeft;
        private RobotCommandSpinRight _robotCommandRight;
        private RobotCommandMoveForward _robotCommandForward;
        private int _robotId;
        private InputStep _step = InputStep.Initialize;

        public RobotWarsForm()
        {
            InitializeComponent();
            _robotCommandLeft = new RobotCommandSpinLeft(Arena.Instance);
            _robotCommandRight = new RobotCommandSpinRight(Arena.Instance);
            _robotCommandForward = new RobotCommandMoveForward(Arena.Instance);
        }

        /// <summary>
        /// The method is validating / processing the commands entered by user.
        /// It is using the Arena class and Command classes to triger the movement of the Robots;
        /// </summary>
        private void ProcessCommand()
        {
            string[] commands = commandTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string lastCommand = commands[commands.Length - 1];

            switch (_step)
            {
                case InputStep.Initialize:
                    string[] commandParts = lastCommand.Split(' ');
                    int maxY = 0;
                    int maxX = 0;

                    if (commandParts.Length != 2 || !int.TryParse(commandParts[0], out maxY) || !int.TryParse(commandParts[1], out maxX))
                    {
                        MessageBox.Show("The command that you entered is invalid. Expected uppper-right arena coordinates. Try again.");
                        return;
                    }

                    try
                    {
                        Arena.Instance.Init(maxX + 1, maxY + 1);
                        DisplayArena();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("There was an error while initializing Arena: " + ex.Message);
                        return;
                    }

                    _step = InputStep.SetRobotPosition;
                    break;
                case InputStep.SetRobotPosition:
                    commandParts = lastCommand.Split(' ');
                    int y = 0;
                    int x = 0;
                    RobotOrientation orientation;

                    if (commandParts.Length != 3 || !int.TryParse(commandParts[0], out x) || !int.TryParse(commandParts[1], out y) || !Enum.TryParse(commandParts[2], out orientation))
                    {
                        MessageBox.Show("The command that you entered is invalid. Expected position of the robot. Try again.");
                        return;
                    }

                    try
                    {
                        finalPositionLabel.Text = "";
                        _robotId = RobotFactory.CreateRobot(x, y, orientation);
                        DisplayArena();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error while creating a robot: " + ex.Message);
                        return;
                    }

                    _step = InputStep.MoveRobot;

                    break;
                case InputStep.MoveRobot:

                    for (int i = 0; i < lastCommand.Length; i++)
                        if (lastCommand[i] != 'L' && lastCommand[i] != 'M' && lastCommand[i] != 'R')
                        {
                            MessageBox.Show("The command that you entered is invalid. Expected commands for the robot [L|M|R]");
                            return;
                        }
                    for (int i = 0; i < lastCommand.Length; i++)
                    {
                        try
                        {
                            switch (lastCommand[i])
                            {
                                case 'L':
                                    _robotCommandLeft.Execute(_robotId);
                                    break;
                                case 'R':
                                    _robotCommandRight.Execute(_robotId);
                                    break;
                                case 'M':
                                    _robotCommandForward.Execute(_robotId);
                                    break;

                                default:
                                    break;
                            }
                            DisplayArena();
                            Application.DoEvents();
                            Thread.Sleep(500);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"There was an error while moving the robot with command at positon ${i+1} / ${lastCommand[i]}: " + ex.Message);
                            return;
                        }
                    }

                    Robot robot = Arena.Instance.GetRobot(_robotId);

                    finalPositionLabel.Text = $"Final position: [{robot.X}, {robot.Y}, {robot.Orientation}]";

                    _step = InputStep.SetRobotPosition;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// The method is display the arena using the current status of Arena object and the last Robot added.
        /// </summary>
        private void DisplayArena()
        {
            SuspendDrawing(arenaPanel);
            arenaPanel.Controls.Clear();

            int width = Resources.tile.Width;
            int height = Resources.tile.Height;
            PictureBox robotPicture = null;
            int robotX = 0, robotY = 0;

            if (_robotId != 0)
            {
                Robot robot = Arena.Instance.GetRobot(_robotId);
                robotX = robot.X;
                robotY = robot.Y;

                robotPicture = new PictureBox();
                robotPicture.Left = 7;
                robotPicture.Top = 7;
                robotPicture.BackColor = Color.Transparent;

                switch (robot.Orientation)
                {
                    case RobotOrientation.N:
                        robotPicture.Image = Resources.packman_N;
                        break;
                    case RobotOrientation.W:
                        robotPicture.Image = Resources.packman_W;
                        break;
                    case RobotOrientation.E:
                        robotPicture.Image = Resources.packman_E;
                        break;
                    case RobotOrientation.S:
                        robotPicture.Image = Resources.packman_S;
                        break;
                    default:
                        break;
                }

                robotPicture.SizeMode = PictureBoxSizeMode.AutoSize;
            }

            for (int i = 0; i < Arena.Instance.Width; i++)
                for (int j = 0; j < Arena.Instance.Height; j++)
                {
                    PictureBox picture = new PictureBox();
                    picture.Image = Resources.tile;
                    picture.Left = i * width;
                    picture.Top = (Arena.Instance.Height - j - 1) *height;
                    picture.SizeMode = PictureBoxSizeMode.AutoSize;
                    picture.BackColor = Color.Transparent;

                    if (robotPicture != null && i == robotX && j == robotY)
                        robotPicture.Parent = picture;

                    arenaPanel.Controls.Add(picture);
                }

            ResumeDrawing(arenaPanel);
        }

        #region Events

        /// <summary>
        /// Checkin for new line char, that means new command was inserted;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commandTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                ProcessCommand();
        }

        /// <summary>
        /// Reseting the state of the arena when click on Restart button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartButton_Click(object sender, EventArgs e)
        {
            commandTextBox.Text = "";
            _step = InputStep.Initialize;
            _robotId = 0;
            finalPositionLabel.Text = "";
            arenaPanel.Controls.Clear();
        }

        #endregion

        #region External Dll Call

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;
        /// <summary>
        /// Used to suspend drawing, usefull when many controls are drawn so we need to wait to finish
        /// </summary>
        /// <param name="parent"></param>
        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
        
        #endregion
    }
}

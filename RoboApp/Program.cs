using static RoboApp.Orientation;
using static System.Console;

namespace RoboApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string SAMPLETEXTFOLDER = @"../../../SampleTexts/";
            string[] files = Directory.GetFiles(SAMPLETEXTFOLDER).Select(file => Path.GetFileName(file)).ToArray();
            int choice = 0;

            if (args.Length == 0)
            {
                Menu mainMenu = new("Choose from options below, use arrow keys to navigate", files);
                choice = mainMenu.Run();
            }
            else if (!files.Contains(args[0]))
            {
                Menu mainMenu = new("The file entered does not exist\r\nChoose from options below, use arrow keys to navigate", files);
                choice = mainMenu.Run();
            }

            FileParser parsedFile = new(SAMPLETEXTFOLDER + files[choice]);
            Grid grid = new(parsedFile.GetGridXSize(), parsedFile.GetGridYSize());
            Obstacle collisionObstacle = new();


            List<Obstacle> obstacles = new List<Obstacle>();
            for (int i = 0; i < parsedFile.GetObstacles().Count; i++)
            {
                Obstacle obstacle = new(parsedFile.GetObstacleXCoordinate(i), parsedFile.GetObstacleYCoordinate(i));
                obstacles.Add(obstacle);
            }


            for (int i = 0; i < 3; i++)
            {
                Robot C3P0 = new(parsedFile.RobotStartingXAxis(i), parsedFile.RobotStartingYAxis(i), Array.IndexOf(CardinalPoints, parsedFile.RobotStartingOrientation(i)));
                foreach (char item in Convert.ToString(parsedFile.GetRobotCommands().ElementAt(i)))
                {
                    if (!C3P0.Crashed) {
                        if (item == 'F')
                        {
                            C3P0.MoveForward();
                            foreach (var ob in obstacles)
                            {
                                if (C3P0.XCoordinate == ob.XCoordinate && C3P0.YCoordinate == ob.YCoordinate)
                                {
                                    C3P0.Crashed = true;
                                    collisionObstacle = new(ob.XCoordinate, ob.YCoordinate);
                                }
                            }
                        }
                        else
                        {
                            C3P0.Rotate(item);
                        }
                    }
                }

                var output = C3P0.Crashed ? $"CRASHED {collisionObstacle.XCoordinate} {collisionObstacle.YCoordinate}" 
                    : C3P0.OutOfBounds(grid) ? "OUT OF BOUNDS" 
                    : (C3P0.ReportPosition() == parsedFile.GetRobotEndingPositions().ElementAt(i)) 
                    ? $"SUCCESS {C3P0.ReportPosition()}" : $"FAILURE {C3P0.ReportPosition()}";
                
                WriteLine(output);
            }

        }
    }
}
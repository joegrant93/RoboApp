namespace RoboApp
{
    public class FileParser
    {
        private List<string> fileContents { get; }
        public FileParser(string filePath_)
        {
            fileContents = File.ReadAllLines(filePath_).ToList();
        }
        
        
        //Grid data
        public string GetGridLine() => fileContents.First();
        public int GetGridYSize() => Convert.ToInt32(GetGridLine().Split("x").Last());
        public int GetGridXSize() => Convert.ToInt32(GetGridLine().Split("x").First().Split(" ").Last());


        //Robot Coordinates
        public List<string> GetAllRobotStartingPosistions() => GetAllRobotInstructions().Where((x, i) => i % 3 == 0).ToList();
        public List<string> GetRobotEndingPositions() => GetAllRobotInstructions().Skip(2).Where((x, i) => i % 3 == 0).ToList();
        public List<string> GetStartingRobotPositions(int listIndex_) {
            List<string> startingPositions = new List<string>();
            foreach (var line in GetAllRobotStartingPosistions().ElementAt(listIndex_)) {
                startingPositions.Add(line.ToString());
            }
            return startingPositions.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }
        public int RobotStartingXAxis(int commandNumber_) => Convert.ToInt32(GetStartingRobotPositions(commandNumber_).ElementAt(0));
        public int RobotStartingYAxis(int commandNumber_) => Convert.ToInt32(GetStartingRobotPositions(commandNumber_).ElementAt(1));
        public char RobotStartingOrientation(int commandNumber_) => Convert.ToChar(GetStartingRobotPositions(commandNumber_).ElementAt(2));


        //Robot Commands
        public List<string> GetRobotCommands() => GetAllRobotInstructions().Skip(1).Where((x, i) => i % 3 == 0).ToList();
        public List<string> GetAllRobotInstructions() => fileContents.Where(x => !x.Contains("OBSTACLE") && !x.Contains("GRID") && !x.Contains("\r") && !string.IsNullOrWhiteSpace(x)).ToList();

        //Obstacles
        public List<string> GetObstacles() => fileContents.Where(x => x.Contains("OBSTACLE")).ToList();
        public int GetObstacleXCoordinate(int count) => (int)Char.GetNumericValue(GetObstacles().ElementAt(count).Split("OBSTACLE").Last().Replace(" ", "").FirstOrDefault());
        public int GetObstacleYCoordinate(int count) => (int)Char.GetNumericValue(GetObstacles().ElementAt(count).Split("OBSTACLE").Last().Replace(" ", "").LastOrDefault());

    }
}
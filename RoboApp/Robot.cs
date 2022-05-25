using static RoboApp.Orientation;
namespace RoboApp
{
    internal class Robot
    {
        public Robot(int xCoordinate_, int yCoordinate_, int cardinalPointIndex_)
        {
            XCoordinate = xCoordinate_;
            YCoordinate = yCoordinate_;
            CardinalPointIndex = cardinalPointIndex_;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int CardinalPointIndex = 0;
        public bool Crashed = false;

        public bool OutOfBounds(Grid grid_) => (XCoordinate > grid_.XAxisSize) ^ (XCoordinate < 0) ^ (YCoordinate > grid_.YAxisSize) ^ (YCoordinate < 0);
        public void Rotate(char direction_) => CardinalPointIndex = char.Equals(direction_, 'R') ? GetNext(CardinalPointIndex) : GetPrev(CardinalPointIndex);
        //move robot forwarding on grid, taking in orientation
        public void MoveForward()
        {
            switch (CardinalPointIndex)
            {
                case 0: //North
                    YCoordinate++;
                    break;
                case 1: //East
                    XCoordinate++;
                    break;
                case 2: //South
                    YCoordinate--;
                    break;
                case 3: //West
                    XCoordinate--;
                    break;
            }
        }


        public string ReportPosition()
        {
            return $"{XCoordinate} {YCoordinate} {CardinalPoints[CardinalPointIndex]}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboApp
{
    internal class Obstacle
    {
        public Obstacle(int xCoordinate_, int yCoordinate_) {
            XCoordinate = xCoordinate_;
            YCoordinate = yCoordinate_; 
        }
        public Obstacle() { }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string ReportPosition() => $"{XCoordinate} {YCoordinate}";
    }
}

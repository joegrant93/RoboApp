using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboApp
{
    public static class Orientation
    {
        public static char[] CardinalPoints = { 'N','E','S','W'};
        public static int GetNext(int currentIndex_) => currentIndex_ + 1 >= CardinalPoints.Length ? 0 : currentIndex_ + 1;
        public static int GetPrev(int currentIndex) => currentIndex - 1 < 0 ? CardinalPoints.Length - 1 : currentIndex - 1;
    }
}

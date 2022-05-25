namespace RoboApp
{
    internal class Grid
    {
        public Grid(int XAxisSize_, int YAxisSize_)
        {
            XAxisSize = XAxisSize_;
            YAxisSize = YAxisSize_;
        }
        public int XAxisSize { get; }
        public int YAxisSize { get; }
    }
}

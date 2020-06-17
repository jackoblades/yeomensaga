using SFML.Graphics;
using SFML.System;
using yeomensaga.Models.Logical;

namespace yeomensaga.Extensions
{
    public static class ViewExtensions
    {
        public static void MoveWithBounds(this View view, int x, int y, Map map)
        {
            view.MoveWithBounds(x, y, map.LeftCorner.X, map.TopCorner.Y, map.RightCorner.X, map.BottomCorner.Y);
        }

        public static void MoveWithBounds(this View view, int x, int y, float xLower, float yLower, float xUpper, float yUpper)
        {
            view.MoveWithBounds(x, y, (int)xLower, (int)yLower, (int)xUpper, (int)yUpper);
        }

        public static void MoveWithBounds(this View view, int x, int y, int xLower, int yLower, int xUpper, int yUpper)
        {
            int xTrue = (view.Center.X + x < xLower) || (view.Center.X + x > xUpper) ? 0 : x;
            int yTrue = (view.Center.Y + y < yLower) || (view.Center.Y + y > yUpper) ? 0 : y;
            view.Move(new Vector2f(xTrue, yTrue));
        }
    }
}

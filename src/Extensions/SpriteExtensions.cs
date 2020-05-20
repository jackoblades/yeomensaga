using System;
using SFML.Graphics;
using SFML.System;

namespace yeomensaga.Extensions
{
    public static class SpriteExtensions
    {
        /// <summary>
        /// True if the specified point lies within this <see cref="Sprite"/> bounds;
        /// False otherwise.
        /// </summary>
        public static bool Contains(this Sprite sprite, Vector2i position)
        {
            return sprite.GetGlobalBounds().Contains(position.X, position.Y);
        }

        /// <summary>
        /// True if the specified point lies within this <see cref="Sprite"/> bounds;
        /// False otherwise.
        /// </summary>
        public static bool Contains(this Sprite sprite, int x, int y)
        {
            return sprite.GetGlobalBounds().Contains(x, y);
        }
        
        /// <summary>
        /// True if the specified point lies within this <see cref="Sprite"/> bounds;
        /// False otherwise.
        /// </summary>
        public static bool IsoContains(this Sprite sprite, Vector2i position)
        {
            return sprite.IsoContains(position.X, position.Y);
        }

        /// <summary>
        /// True if the specified point lies within this isometric <see cref="Sprite"/> bounds;
        /// False otherwise.
        /// </summary>
        public static bool IsoContains(this Sprite sprite, int x, int y)
        {
            var bounds = sprite.GetGlobalBounds();
            var origin = new Vector2i((int)(bounds.Left + bounds.Width/2), (int)(bounds.Top + bounds.Height/2));
            bool result = true;

            if (x <= origin.X && y <= origin.Y)
            {
                result &= x >= origin.X - 2*(23 - Math.Abs(y - origin.Y));
                result &= y >= origin.Y - 2*(46 - Math.Abs(x - origin.X));
            }
            if (x <= origin.X && y > origin.Y)
            {
                result &= x >= origin.X - 2*(23 - Math.Abs(y - origin.Y));
                result &= y <= origin.Y + 2*(46 - Math.Abs(x - origin.X));
            }
            if (x > origin.X && y <= origin.Y)
            {
                result &= x <= origin.X + 2*(23 - Math.Abs(y - origin.Y));
                result &= y >= origin.Y - 2*(46 - Math.Abs(x - origin.X));
            }
            if (x > origin.X && y > origin.Y)
            {
                result &= x <= origin.X + 2*(23 - Math.Abs(y - origin.Y));
                result &= y <= origin.Y + 2*(46 - Math.Abs(x - origin.X));
            }

            return result;
        }
    }
}

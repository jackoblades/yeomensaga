using SFML.Graphics;
using SFML.System;

namespace yeomensaga.Models.Graphical
{
    public class DimetricSprite : Sprite
    {
        #region Properties

        public Vector2f WorldPosition { get; set; }

        public int Width => TextureRect.Width;
        public int HalfWidth => Width/2;
        public int Height => TextureRect.Height;
        public int HalfHeight => Height/2;

        #endregion

        #region Constructors

        public DimetricSprite(Texture texture) : base(texture) {}

        #endregion

        #region Methods

        public void Update()
        {
            var a = WorldPosition.X + WorldPosition.Y;
            var b = WorldPosition.X - WorldPosition.Y;
            var x = (Program.Window.Size.X/2) - HalfWidth + (b*(HalfWidth-2));
            var y = (HalfHeight-1)*a;
            Position = new Vector2f(x, y);
        }

        #endregion
    }
}

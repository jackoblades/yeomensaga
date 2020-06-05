using SFML.Graphics;

namespace yeomensaga.Models.Logical
{
    public class Game : Drawable
    {
        #region Properties

        public string Name { get; set; }

        public Map Map { get; set; }

        public int Money { get; set; }

        #endregion

        #region Constructors

        public Game()
        {
        }

        #endregion

        #region Drawable

        public void Draw(RenderTarget target, RenderStates states)
        {
            Map.Draw(target, states);
        }

        #endregion
    }
}

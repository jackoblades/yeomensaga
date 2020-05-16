using SFML.Graphics;
using SFML.Window;

namespace yeomensaga.Scenes
{
    public class GameScene : Scene
    {
        #region Private Members

        #region Entities

        #endregion

        #region Progression Fields

        #endregion

        #endregion

        public override Drawable[] Drawables => _drawables;
        private readonly Drawable[] _drawables;

        #region Constructors

        public GameScene(RenderWindow window) : base(window)
        {
            _drawables = new Drawable[]
            {
            };
        }

        #endregion

        #region Methods

        public override void Init()
        {
        }

        public override Scene Open()
        {
            return base.Open();
        }

        public override void Close()
        {
            base.Close();
        }

        public override void Progress()
        {
        }

        #endregion

        #region Event Handlers

        protected override void OnKeyPressed(object sender, KeyEventArgs e)
        {
            var window = sender as Window;
            switch (e.Code)
            {
                case Keyboard.Key.Escape: Program.Close();
                    break;
            }
        }

        protected override void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case Mouse.Button.Left:   OnMouseButtonPressed(e); break;
                case Mouse.Button.Right:  OnMouseButtonPressed(e); break;
                case Mouse.Button.Middle: OnMouseButtonPressed(e); break;
            }
        }

        private void OnMouseButtonPressed(MouseButtonEventArgs e)
        {
        }

        protected override void OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case Mouse.Button.Left:   OnMouseButtonReleased(e); break;
                case Mouse.Button.Right:  OnMouseButtonReleased(e); break;
                case Mouse.Button.Middle: OnMouseButtonReleased(e); break;
            }
        }

        private void OnMouseButtonReleased(MouseButtonEventArgs e)
        {
        }

        #endregion
    }
}

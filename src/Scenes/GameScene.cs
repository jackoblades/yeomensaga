using SFML.Graphics;
using SFML.System;
using SFML.Window;
using yeomensaga.Extensions;
using yeomensaga.Services;

namespace yeomensaga.Scenes
{
    public class GameScene : Scene
    {
        #region Private Members

        #region Entities

        Texture texture;
        Sprite sprite;

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
                sprite,
            };
        }

        #endregion

        #region Methods

        public override void Init()
        {
            texture = new Texture("res/gfx/grass.png");
            sprite = new Sprite(texture);
            var bounds = sprite.GetGlobalBounds();
            sprite.Position = new Vector2f(250f, 250f);
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
            var mousePosition = Mouse.GetPosition(_window);
            if (sprite.IsoContains(mousePosition.X, mousePosition.Y))
            {
                sprite.Color = new Color(255, 255, 255, 128);
            }
            else
            {
                sprite.Color = new Color(255, 255, 255, 255);
            }
        }

        #endregion

        #region Event Handlers

        protected override void OnKeyPressed(object sender, KeyEventArgs e)
        {
            var window = sender as Window;
            switch (e.Code)
            {
                case Keyboard.Key.Escape: Program.Navigate(SceneService.TitleScene);
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

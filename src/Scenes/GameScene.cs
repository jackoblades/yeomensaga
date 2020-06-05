using SFML.Graphics;
using SFML.System;
using SFML.Window;
using yeomensaga.Extensions;
using yeomensaga.Models.Logical;
using yeomensaga.Services;

namespace yeomensaga.Scenes
{
    public class GameScene : Scene
    {
        #region Private Members

        #region Entities

        Game Game;

        View GameView;

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
                Game,
            };
        }

        #endregion

        #region Methods

        public override void Init()
        {
            Game = new Game();
            Game.Map = new Map(100,100);
            Game.Map.Fill(new Texture("res/gfx/grass.png"));

            GameView = new View(Game.Map.CenterPosition, new Vector2f(Program.Window.Size.X, Program.Window.Size.Y));
            //GameView.Viewport = new FloatRect(0f, 0f, GameView.Size.X-200, GameView.Size.Y);
        }

        public override Scene Open()
        {
            base.Open();

            Program.Window.SetView(GameView);

            return this;
        }

        public override void Close()
        {
            base.Close();

            Program.Window.SetView();
        }

        public override void Progress()
        {
            var mousePosition = Mouse.GetPosition(_window);
            int x = (mousePosition.X <= 5) ? -20
                  : (mousePosition.X >= GameView.Size.X - 5) ? 20 : 0;
            int y = (mousePosition.Y <= 5) ? -20
                  : (mousePosition.Y >= GameView.Size.Y - 5) ? 20 : 0;
            GameView.Move(new Vector2f(x, y));

            Program.Window.SetView(GameView);
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

using yeomensaga.Scenes;
using SFML.Graphics;
using System;

namespace yeomensaga.Services
{
    public static class SceneService
    {
        #region Private Members

        private static RenderWindow Window => _window ?? throw new NullReferenceException($"[{nameof(SceneService)}] {nameof(Window)} get; error - Service is uninitialized.");
        private static RenderWindow _window;

        #endregion

        #region Properties

        public static Scene TitleScene => _titleScene ?? (_titleScene = new TitleScene(Window));
        private static Scene _titleScene;

        public static Scene SettingsScene => _settingsScene ?? (_settingsScene = new SettingsScene(Window));
        private static Scene _settingsScene;

        public static Scene GameScene => _gameScene ?? (_gameScene = new GameScene(Window));
        private static Scene _gameScene;

        #endregion

        #region Methods

        public static void Init(RenderWindow window)
        {
            _window = window;
        }

        #endregion
    }
}

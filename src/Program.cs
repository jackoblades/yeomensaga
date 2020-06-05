using yeomensaga.Extensions;
using yeomensaga.Models.Management;
using yeomensaga.Repository;
using yeomensaga.Scenes;
using yeomensaga.Services;
using yeomensaga.Textual;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using System;

namespace yeomensaga
{
    public class Program
    {
        #region Properties

        public static readonly string Version = "alpha";

        public static readonly string Footer = @"https://github.com/jackoblades 🄯 2019 - 2020 Anno Domini";

        public static Scene CurrentScene { get; set; }

        public static RenderWindow Window;

        private static object _lock = new object();

        #endregion

        static void Main(string[] args)
        {
            Orm.InitAsync().Wait();
            Settings.Init();
            MusicService.Init();

            var mode = new VideoMode(800, 600);
            Window = new RenderWindow(mode, "YeomenSaga");
            Window.Closed += (x, y) => Close();
            Window.SetVerticalSyncEnabled(Settings.Instance.Vsync);

            // Services.
            SceneService.Init(Window);

            Fonts.Init();
            Navigate(SceneService.TitleScene);

            while (Window.IsOpen)
            {
                lock (_lock)
                {
                    CurrentScene.Progress();
                    Window.DispatchEvents();
                    Window.Clear(Color.Black);
                    Window.Draw(CurrentScene);
                    Window.Display();
                }
            }
        }

        public static void Navigate(Scene scene)
        {
            lock (_lock)
            {
                CurrentScene?.Close();
                CurrentScene = scene.Open();
            }
        }

        public static void Close()
        {
            MusicService.Close();
            Window.Close();
        }
    }
}

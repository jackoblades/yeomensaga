using SFML.Graphics;
using yeomensaga.Scenes;

namespace yeomensaga.Extensions
{
    public static class WindowExtensions
    {
        public static void Draw(this RenderWindow window, Scene scene)
        {
            window.Draw(scene.Drawables);
        }

        public static void Draw(this RenderWindow window, Drawable[] drawables)
        {
            foreach (Drawable entity in drawables)
            {
                window.Draw(entity);
            }
        }

        public static void SetView(this RenderWindow window)
        {
            window.SetView(window.DefaultView);
        }
    }
}

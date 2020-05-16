using yeomensaga.Scenes;
using SFML.Graphics;
using SFML.Window;

namespace yeomensaga.Extensions
{
    public static class WindowExtensions
    {
        public static void Draw(this RenderWindow window, Scene scene)
        {
            foreach (Drawable entity in scene.Drawables)
            {
                window.Draw(entity);
            }
        }
    }
}
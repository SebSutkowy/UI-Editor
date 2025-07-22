using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UI_Editor
{
    enum Function
    {
        None,
        ChangeScene
    }

    abstract class Element
    {
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Function OnHover = Function.None;
        public Function OnClick = Function.None;

        public Element(Vector2 pos, Vector2 size, string text, Color backgroundColor)
        {
            Position = pos;
            Size = size;
            BackgroundColor = backgroundColor;
        }
    }

    class Box : Element
    {
        public Box(Vector2 pos, Vector2 size, string text, Color backgroundColor) : base(pos, size, text, backgroundColor) { }

    }
}

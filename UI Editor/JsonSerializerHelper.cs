using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;

namespace UI_Editor
{
    class Vector2Serializable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Vector2Serializable() { }
        public Vector2Serializable(Vector2 v)
        {
            X = v.X;
            Y = v.Y;
        }

        public Vector2 ToVector2 () => new Vector2(X, Y);
    }

    class PointSerializable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointSerializable() { }
        public PointSerializable(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Point ToPoint() => new Point(X, Y);
    }

    class ElementSerializationData
    {
        public string Type { get; set; }
        public PointSerializable Position { get; set; }
        public PointSerializable Size { get; set; }
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }
        public bool IsInteractable { get; set; }
        public bool IsVisible { get; set; }
        public List<Functions> OnHoverFunctions { get; set; } = new List<Functions>();
        public List<Functions> OnClickFunctions { get; set; } = new List<Functions>();

        public ElementSerializationData(ElementType type, Point position, Point size, string text, Color backgroundColor, bool isInteractable, bool isVisible)
        {
            Type = type.ToString();
            Position = new PointSerializable(position);
            Size = new PointSerializable(size);
            Text = text;
            BackgroundColor = backgroundColor;
            IsInteractable = isInteractable;
            IsVisible = isVisible;
            OnHoverFunctions = new List<Functions>();
            OnClickFunctions = new List<Functions>();
        }

        public Element CreateElement()
        {
            switch(Type)
            {
                case "Box":
                    Box box = new Box(Position.ToPoint(), Size.ToPoint(), Text, BackgroundColor);
                    box.IsInteractable = IsInteractable;
                    box.IsVisible = IsVisible;
                    foreach(Functions function in OnHoverFunctions)
                        box.AddOnHover(function);
                    foreach (Functions function in OnClickFunctions)
                        box.AddOnClick(function);
                    return box;
                default:
                    return null;
            }
        }

    }
}

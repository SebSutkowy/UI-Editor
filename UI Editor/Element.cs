using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Text.Json;
using System.IO;
using System.Transactions;
using System.Diagnostics;

namespace UI_Editor
{
    enum ElementType
    {
        Box
    }

    abstract class Element
    {
        public ElementSerializationData SerializationData { get; set; }
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }
        public Point Position { get; set; }
        public Point Size { get; set; }

        public Action OnHover;
        public Action OnClick;

        public bool IsInteractable = true;
        public bool IsVisible = true;

        public Element(ElementSerializationData serializationData)
        {
            SerializationData = serializationData;
            Load();
        }

        public Element(Point position, Point size, string text, Color backgroundColor)
        {
            Position = position;
            Size = size;
            Text = text;
            BackgroundColor = backgroundColor;
        }

        public void Hovering()
        {
            if (OnHover == null)
                Debug.WriteLine("OnHover is null");
            OnHover?.Invoke();
            
        }

        public void Clicked()
        {
            OnClick?.Invoke();
        }

        public void Update(Point windowSize)
        {
            Load();
            Rectangle hitbox = GetRectangle(windowSize);
            if (hitbox.Contains(InputManager.GetMousePos()))
            {
                Hovering();
                if (InputManager.WasMouseButtonPressed(MouseButtons.LeftButton))
                    Clicked();
            }
        }

        public void AddOnHover(Functions function)
        {
            OnHover += () => function.Execute(this);
            SerializationData.OnHoverFunctions.Add(function);
        }

        public void AddOnClick(Functions function)
        {
            OnClick += () => function.Execute(this);
            SerializationData.OnClickFunctions.Add(function);
        }


        public Rectangle GetRectangle(Point windowSize)
            => new Rectangle(
                (int)(Position.X * windowSize.X * 0.01),
                (int)(Position.Y * windowSize.Y * 0.01),
                (int)(Size.X * windowSize.X * 0.01),
                (int)(Size.Y * windowSize.Y * 0.01));

        public abstract void Draw(Texture2D _texture, SpriteBatch spriteBatch, Point windowSize);

        public abstract void Load();

        //public void GetJsonString()
        //{
        //    string jsonText = JsonSerializer.Serialize( new
        //    {
        //        ElementPosition = { Position.X, Position.Y},
        //        ElementSize = { Size.X, Size.Y
        //    }
        //    , new JsonSerializerOptions { WriteIndented = true });
        //    File.WriteAllText("Elements.json", jsonText);
        //}

        public string GetJson()
        {
            //Debug.WriteLine($"{{\n\t\"Type\" = \"{SerializationData.Type}\",\n\t\"IsInteractable\" = \"{SerializationData.IsInteractable}\"\n}}");
            return JsonSerializer.Serialize(SerializationData, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    class Box : Element
    {
        public const ElementType Type = ElementType.Box;

        public Box(ElementSerializationData serializationData) : base (serializationData) { }

        public Box(Point position, Point size, string text, Color backgroundColor) : base(position, size, text, backgroundColor)
        {
            SerializationData = new ElementSerializationData(Type, position, size, text, backgroundColor, IsInteractable, IsVisible);
            Debug.WriteLine(SerializationData.Type.ToString());
        }

        public override void Load()
        {
            Position = SerializationData.Position.ToPoint();
            Size = SerializationData.Size.ToPoint();
            Text = SerializationData.Text;
            BackgroundColor = SerializationData.BackgroundColor;
            IsInteractable = SerializationData.IsInteractable;
            IsVisible = SerializationData.IsVisible;
            OnHover = null;
            OnClick = null;
            foreach (Functions function in SerializationData.OnHoverFunctions)
                OnHover += () => function.Execute(this);
            foreach (Functions function in SerializationData.OnClickFunctions)
                OnClick += () => function.Execute(this);
        }

        public override void Draw(Texture2D _texture, SpriteBatch spriteBatch, Point windowSize)
        {
            Rectangle destinationRect = GetRectangle(windowSize);
            spriteBatch.Draw(_texture, destinationRect, BackgroundColor);
        }
    }
}


/*
 *  ** TO DO **
 *  Add custom functions that can be stored 
 * 
 * 
 */
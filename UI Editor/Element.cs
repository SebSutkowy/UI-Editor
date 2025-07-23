using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace UI_Editor
{
    abstract class Element
    {
        public Texture2D _texture { get; set; }
        public string Text { get; set; }
        public Color BackgroundColor { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Action Hovering;
        public Action Clicked;

        public bool IsInteractable = true;
        public bool IsVisible = true;

        public Element(GraphicsDevice graphicsDevice, Vector2 pos, Vector2 size, string text, Color backgroundColor)
        {
            // creating the 1 pixel texture
            _texture = new Texture2D(graphicsDevice, width: 1, height: 1);
            _texture.SetData(new[] { Color.White });

            Position = pos;
            Size = size;
            BackgroundColor = backgroundColor;
        }

        public void OnHover()
        {
            Console.WriteLine("Hovering");
            Hovering?.Invoke();
        }

        public void OnClick()
        {
            Console.WriteLine("Clicked");
            Clicked?.Invoke();
        }

        public void Update()
        {
            Rectangle hitbox = GetRectangle();
            if (hitbox.Contains(InputManager.GetMousePos()))
            {
                OnHover();
                if (InputManager.WasMouseButtonPressed(MouseButtons.LeftButton))
                    OnClick();
            }

        }

        public Rectangle GetRectangle()
            => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

        public abstract void Draw(SpriteBatch spriteBatch);

        public void GetJsonString()
        {

        }
    }

    class Box : Element
    {
        public Box(GraphicsDevice graphicsDevice, Vector2 pos, Vector2 size, string text, Color backgroundColor) : base(graphicsDevice, pos, size, text, backgroundColor) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRect = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            spriteBatch.Draw(_texture, destinationRect, BackgroundColor);
        }
    }
}

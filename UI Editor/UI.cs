using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Text.Json;

namespace UI_Editor
{
    static class UI
    {
        public static Texture2D Texture;
        public static List<Element> Elements = new List<Element>();
        public static Point WindowSize;

        #region AddElements
        // Boxes
        public static void AddNewBox(Box box) => Elements.Add(box);
        public static void AddNewBox(GraphicsDevice graphicsDevice, Point pos, Point size, string text, Color backgroundColor) 
            => Elements.Add(new Box(pos, size, text, backgroundColor));

        //Whatever else
        #endregion

        public static void Import(GraphicsDevice graphicsDevice, Point windowSize, string jsonFileName = "")
        {
            Texture = new Texture2D(graphicsDevice, width: 1, height: 1);
            Texture.SetData(new[] { Color.White });
            WindowSize = windowSize;
            if (jsonFileName != "")
                return; // Add the importing logic here
                
        }
        public static void Update()
        {
            foreach(Element element in Elements)
            {
                element.Update(WindowSize);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Element element in Elements)
            {
                element.Draw(Texture, spriteBatch, WindowSize);
            }
        }

    }
}

using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace UI_Editor
{
    static class UI
    {
        public static List<Element> Elements = new List<Element>();

        #region AddElements
        // Boxes
        public static void AddNewBox(Box box) => Elements.Add(box);
        public static void AddNewBox(GraphicsDevice graphicsDevice, Vector2 pos, Vector2 size, string text, Color backgroundColor) 
            => Elements.Add(new Box(graphicsDevice, pos, size, text, backgroundColor));

        //Whatever else
        #endregion

        public static void Update()
        {
            foreach(Element element in Elements)
            {
                element.Update();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Element element in Elements)
            {
                element.Draw(spriteBatch);
            }
        }

    }
}

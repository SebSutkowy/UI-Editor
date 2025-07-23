using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace UI_Editor
{
    enum MouseButtons
    {
        LeftButton,
        RightButton,
        MiddleButton
    }

    static class InputManager
    {
        private static MouseState prevMouseState;
        private static MouseState currMouseState = new MouseState();
        private static KeyboardState prevKeyState;
        private static KeyboardState currKeyState = new KeyboardState();

        public static void Update()
        {
            prevMouseState = currMouseState;
            currMouseState = Mouse.GetState();
            prevKeyState = currKeyState;
            currKeyState = Keyboard.GetState();
        }

        #region Input Methods
        // keys 
        public static bool IsKeyDown(Keys key) => currKeyState.IsKeyDown(key);
        public static bool WasKeyPressed(Keys key) => (currKeyState.IsKeyDown(key) && !prevKeyState.IsKeyDown(key));
        public static bool WasKeyReleased(Keys key) => (!currKeyState.IsKeyDown(key) && prevKeyState.IsKeyDown(key));

        // mouse buttons
        public static bool IsMouseButtonDown(MouseButtons button)
        {
            switch(button)
            {
                case MouseButtons.LeftButton:
                    return currMouseState.LeftButton == ButtonState.Pressed;
                case MouseButtons.RightButton:
                    return currMouseState.RightButton == ButtonState.Pressed;
                case MouseButtons.MiddleButton:
                    return currMouseState.MiddleButton == ButtonState.Pressed;
                default:
                    return false;
            }
        }
        
        public static bool WasMouseButtonPressed(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.LeftButton:
                    return (currMouseState.LeftButton == ButtonState.Pressed) && (prevMouseState.LeftButton != ButtonState.Pressed);
                case MouseButtons.RightButton:
                    return (currMouseState.RightButton == ButtonState.Pressed) && (prevMouseState.RightButton != ButtonState.Pressed);
                case MouseButtons.MiddleButton:
                    return (currMouseState.MiddleButton == ButtonState.Pressed) && (prevMouseState.MiddleButton != ButtonState.Pressed);
                default:
                    return false;
            }
        }

        public static bool WasMouseButtonReleased(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.LeftButton:
                    return (currMouseState.LeftButton == ButtonState.Released) && (prevMouseState.LeftButton != ButtonState.Released);
                case MouseButtons.RightButton:
                    return (currMouseState.RightButton == ButtonState.Released) && (prevMouseState.RightButton != ButtonState.Released);
                case MouseButtons.MiddleButton:
                    return (currMouseState.MiddleButton == ButtonState.Released) && (prevMouseState.MiddleButton != ButtonState.Released);
                default:
                    return false;
            }
        }

        public static Point GetMousePos() => currMouseState.Position;
        #endregion





    }
}

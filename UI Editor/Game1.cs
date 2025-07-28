using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Text.Json;

namespace UI_Editor;



public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Point _windowSize;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 1000;
        _graphics.PreferredBackBufferHeight = 1000;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _windowSize = new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        Point position = new Point(90, 10); // Size and Position are now in percentages of the screen size
        Point size = new Point(10, 3);
        string text = "";
        Color backgroundColor = new Color(254, 1, 154);
        Box box = new Box(
            position,
            size,
            text,
            backgroundColor
        );
        Debugging func = new Debugging
        {
            number = 2,
            transition = Transition.Logarithmic,
            translation = new PointSerializable(new Point(80, 10))
        };
        box.AddOnClick(func);
        box.OnClick += () => Debug.WriteLine(box.GetJson());
        UI.Import(GraphicsDevice, _windowSize);
        UI.AddNewBox(box);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        InputManager.Update();

        // TODO: Add your update logic here
        UI.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        UI.Draw(_spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Boxers
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Boxer boxer1;
        Boxer boxer2;
        

        public delegate void boxerAction();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            boxer1 = new Boxer(new Rectangle(10,10, 100, 100));
            boxer2 = new Boxer(new Rectangle(350, 10, 100, 100));

            boxer1.SetEnemy = boxer2;
            boxer2.SetEnemy = boxer1;


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            boxer1.bs.hitTexture = Content.Load<Texture2D>("b11");
            boxer1.bs.blockTexture = Content.Load<Texture2D>("b12");
            boxer1.bs.waitTexture = Content.Load<Texture2D>("b13");
            boxer1.hpTex = Content.Load<Texture2D>("hp");
            boxer1.bs.texture = boxer1.bs.blockTexture;
            boxer2.bs.hitTexture = Content.Load<Texture2D>("b21");
            boxer2.bs.blockTexture = Content.Load<Texture2D>("b22");
            boxer2.bs.waitTexture = Content.Load<Texture2D>("b23");
            boxer2.hpTex = Content.Load<Texture2D>("hp");
            boxer2.bs.texture = boxer2.bs.blockTexture;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            boxer1.Update();
            boxer2.Update();

            

            if (boxer1.hp == 0 || boxer2.hp == 0)
            {
                Thread.Sleep(200000);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            boxer1.Draw(spriteBatch);
            boxer2.Draw(spriteBatch);

            

            // TODO: Add your drawing code here
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
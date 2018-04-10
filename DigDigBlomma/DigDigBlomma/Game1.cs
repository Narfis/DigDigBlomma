using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace DigDigBlomma
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        float wormTime;
        Player player;
        Sunny sunny;
        List<Worm> worms;
        List<Bullet> bullets;
        enum GameState
        {
            MainMenu,
            Options, 
            Player,
        }
        GameState gameState = GameState.MainMenu;

 
        Random random;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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


            base.Initialize();
            player = new Player();
            sunny = new Sunny();
            worms = new List<Worm>();
            bullets = new List<Bullet>();
            wormTime = 60;

            random = new Random();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureLibrary.LoadContent(Content, "WhiteBox");
            TextureLibrary.LoadContent(Content, "sunny"); 
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
            
            player.Update(gameTime, worms);
            wormTime--;
            int randomX = random.Next(0, 2);
            if (wormTime == -1)
            {
                wormTime = 60;
            }
            if (wormTime <= 0)
            {
                worms.Add(new Worm());
                


                if (randomX == 1)
                {
                    worms.Last<Worm>().wormRec.X = -100;

                }
                if (randomX == 0)
                {
                    worms.Last<Worm>().wormRec.X = 1000;
                    worms.Last<Worm>().speed *= -1;
                }


            }
            for (int i = 0; i < worms.Count; i++)
            {
                worms[i].Update(gameTime);

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
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            sunny.Draw(spriteBatch);
            /*   if (worm != null)
               {
                   spriteBatch.Draw(worm, wormRec, wormColor);
               }*/
           
                for (int i = 0; i < worms.Count; i++)
                {
                    worms[i].Draw(spriteBatch);
                }
            
            player.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

     
    }
}

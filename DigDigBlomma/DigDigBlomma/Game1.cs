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
        SpriteFont deadFont;
        float wormTime;
        Player player;
        Sunny sunny;
        List<Worm> worms;
        List<Bullet> bullets;
        Healthbar healthbar;
        MainMenu button;
        SpriteFont font;
        bool isPaused = true;
        enum GameState
        {
            MainMenu,
            Dead, 
            Playing,
            Pause,
        }
        GameState gameState = GameState.MainMenu;

 
        Random random;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
           // graphics.IsFullScreen = true;
           // graphics.PreferredBackBufferHeight = 1080;
         //  graphics.PreferredBackBufferWidth = 1920;
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
            healthbar = new Healthbar();
            wormTime = 60;
            button = new MainMenu();
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
            TextureLibrary.LoadContent(Content, "flower");
            TextureLibrary.LoadContent(Content, "daggis");
            TextureLibrary.LoadContent(Content, "orm");
            TextureLibrary.LoadContent(Content, "flower_power");
            font = Content.Load<SpriteFont>("Score");
            deadFont = Content.Load<SpriteFont>("dead");
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
            if (gameState == GameState.MainMenu)
            {
                isPaused = true;
            }
            else
            {
                isPaused = false;
            }
            switch (gameState)
            {
                case GameState.MainMenu:
                   
                 //   if(button.isClicked == true)
                 if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        gameState = GameState.Playing;
                        
                    }
                    break;


                case GameState.Playing:
                    isPaused = false;
                    if (Keyboard.GetState().IsKeyDown(Keys.P) && gameState == GameState.Playing)
                    {
                        gameState = GameState.Pause;
                    }


                    break;

                case GameState.Pause:
                    isPaused = true;
                    if (Keyboard.GetState().IsKeyDown(Keys.P) && gameState == GameState.Pause)
                    {
                        gameState = GameState.Playing;
                    }



                    break;
                case GameState.Dead:


                    break;

            }
            if (isPaused == false)
            {
                player.Update(gameTime, worms);
                healthbar.Update(gameTime);
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
                    if (sunny.sunnyRec.Intersects(worms[i].wormRec))
                    {
                        Sunny.health -= worms[i].damage;
                        worms.RemoveAt(i);
                        if (Sunny.health <= 0)
                        {
                            //  sunny.sunnyRec.Y = 100000;
                           gameState = GameState.Dead;
                        }
                    }
                }

            }
            if (player.playerRec.X >= Window.ClientBounds.Width)
            {
                player.playerRec.X = -100;
            }
            else if(player.playerRec.X <= -100)
            {
                player.playerRec.X = Window.ClientBounds.Width;
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

            /*   if (worm != null)
               {
                   spriteBatch.Draw(worm, wormRec, wormColor);
               }*/

            
                switch (gameState)
                {
                    case GameState.MainMenu:
                        button.Draw(spriteBatch);
                        IsMouseVisible = true;
                        break;


                    case GameState.Playing:
                        sunny.Draw(spriteBatch);
                        for (int i = 0; i < worms.Count; i++)
                        {
                            worms[i].Draw(spriteBatch);
                        }
                        healthbar.Draw(spriteBatch);
                    spriteBatch.DrawString(font,"Score:" + Bullet.score.ToString(), new Vector2(GraphicsDevice.Viewport.Width - 100, 10), Color.White);
                        player.Draw(spriteBatch);

                        break;
                     case GameState.Pause:
                    sunny.Draw(spriteBatch);
                    for (int i = 0; i < worms.Count; i++)
                    {
                        worms[i].Draw(spriteBatch);
                    }
                    healthbar.Draw(spriteBatch);

                    player.Draw(spriteBatch);

                    break;
                case GameState.Dead:
                    spriteBatch.DrawString(deadFont, "Died".ToString(), new Vector2(100, 100), Color.White);
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        Exit();
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        player.playerRec.X = 350;
                        Bullet.score = 0;
                        Sunny.health = 100;
                      gameState =  GameState.Playing;
                        

                    }

                    break;

                }
            
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        
     
    }
}

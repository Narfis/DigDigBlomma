using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace DigDigBlomma
{
    public class Player
    {
        public Texture2D playerTex;
        public float playerSpeed;
        public Rectangle playerRec;
        public Vector2 playerPos;
        List<Bullet> bullets;



        public Player()
        {
             
            playerPos = new Vector2(350, 50);
            playerTex = TextureLibrary.textures["flower"];
            playerRec = new Rectangle((int)playerPos.X,(int) playerPos.Y, 100, 100);
            playerSpeed = 10f;
            bullets = new List<Bullet>();
        }


        
       

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTex, playerRec, Color.White);
            for (int i = 0; i < bullets.Count; i += 5)
            {
                bullets[i].Draw(spriteBatch);
            }
        }
        internal void Update(GameTime gameTime, List<Worm> worms)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.A))
            {
                playerRec.X -= (int)playerSpeed;
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                playerRec.X += (int)playerSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
               
                Shoot();
               
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime, worms);
            }

          /* for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].bulletRec.Y > graphicsDevice.GraphicsDevice.Viewport.Height)
                {
                    Console.WriteLine(i);
                    bullets.RemoveAt(i);
                    i--;
                }
            } */

        }

        public void Shoot()
        {
            {
                bullets.Add(new Bullet(playerRec.Location));
                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].bulletPos = playerPos;

                }
            }

        }
    }
    

}

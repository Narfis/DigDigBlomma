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
    class Bullet
    {
       public Rectangle bulletRec;
        public Vector2 bulletPos;
        public float speed;
        public Texture2D bulletTex;
       public bool isVisible = true;
        public static int score = 0;



        public Bullet(Point playerPosition)
        {
            bulletTex = TextureLibrary.textures["flower_power"];
            bulletRec = new Rectangle(playerPosition.X + 35, playerPosition.Y + 50, 25, 25);
            isVisible = false;
            speed = 10f;


        }
        public void Update(GameTime gameTime, List<Worm> worms)
        {
            for (int i = 0; i < worms.Count; i++)
            {
                if (bulletRec.Intersects(worms[i].wormRec))
                {
                    worms.RemoveAt(i);
                    i--;
                    score = score + 1;
                }
            }
            
            bulletRec.Y += (int)speed;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bulletTex, bulletRec, Color.White);
            

        }
    }

}


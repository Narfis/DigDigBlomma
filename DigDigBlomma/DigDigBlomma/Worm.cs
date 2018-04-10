using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace DigDigBlomma
{
    class Worm
    {
        public Texture2D wormTex;
        public Rectangle wormRec;
        public float speed;
        Sunny sunny = new Sunny();


        public Worm()
        {
            
            wormTex = TextureLibrary.textures["WhiteBox"];
            wormRec = new Rectangle(-100, 450, wormTex.Width / 5, wormTex.Height / 10);
            speed = 5f;
            
        }
        public void Update(GameTime gameTime)
        {
            wormRec.X += (int)speed;
            if (wormRec.Intersects(sunny.sunnyRec))
            {
                speed = 0f;
              
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(wormTex, wormRec, Color.DeepPink);
        }
    }
}

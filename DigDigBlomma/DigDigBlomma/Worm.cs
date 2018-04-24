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
        public Texture2D wormTex, ormTex;
        public Rectangle wormRec;
        public float speed;
        Sunny sunny = new Sunny();
        public int damage = 10;


        public Worm()
        {
            wormTex = TextureLibrary.textures["daggis"];
            ormTex = TextureLibrary.textures["orm"];
            wormRec = new Rectangle(-100, 450, wormTex.Width *2, wormTex.Height *2);
            speed = 5f;
            damage = 10;
            
        }
        public void Update(GameTime gameTime)
        {
            wormRec.X += (int)speed;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (wormRec.X < 300)
            {
                spriteBatch.Draw(ormTex, wormRec, Color.White);
            }
            else
            {
                spriteBatch.Draw(wormTex, wormRec, Color.White);
            }
        }
    }
}

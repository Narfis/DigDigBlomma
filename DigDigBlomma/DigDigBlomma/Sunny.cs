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
    class Sunny
    {
        public Texture2D sunnyTex;
        public Rectangle sunnyRec;
        public Vector2 sunnyPos;
        static public int health = 100;

        public Sunny()
        {

            sunnyPos = new Vector2(375, 375);
            Console.WriteLine(health);
            sunnyTex = TextureLibrary.textures["sunny"];
            sunnyRec = new Rectangle((int)sunnyPos.X,(int)sunnyPos.Y ,TextureLibrary.textures["sunny"].Width / 3,  TextureLibrary.textures["sunny"].Height / 3);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
        //  if (sunnyTex != null)
            spriteBatch.Draw(sunnyTex, sunnyRec,Color.White);
        }

    }
}

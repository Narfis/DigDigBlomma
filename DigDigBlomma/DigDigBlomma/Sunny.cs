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
        public float health;

        public Sunny()
        {
            health = 10;
            sunnyTex = TextureLibrary.textures["sunny"];
            sunnyRec = new Rectangle(300, 350, TextureLibrary.textures["sunny"].Width * 2, TextureLibrary.textures["sunny"].Height * 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        spriteBatch.Draw(sunnyTex, sunnyRec, Color.White);
        }

    }
}

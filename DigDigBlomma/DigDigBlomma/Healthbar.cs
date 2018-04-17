using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using System.Diagnostics;

namespace DigDigBlomma
{
    class HealthBar
    {
        Sunny sunny = new Sunny();

        Texture2D healthTexture;
        Rectangle healthRectangle;

        public HealthBar()
        {
       //     healthTexture = TextureLibrary.textures[""];
            healthRectangle = new Rectangle(50, 20, (int)sunny.health, 20);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
        }

    }
}

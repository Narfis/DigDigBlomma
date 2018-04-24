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
    class Healthbar
    {
        Sunny sunny = new Sunny();
        Texture2D healthTexture;
        Rectangle healthRectangle;

        public Healthbar()
        {
            healthTexture = TextureLibrary.textures["WhiteBox"];

        }

        public void Update(GameTime gameTime)
        {
            healthRectangle = new Rectangle(50, 20, Sunny.health, 20);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(healthTexture, healthRectangle, Color.LightGreen);
        }
    }
}

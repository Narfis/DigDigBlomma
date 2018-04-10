using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDigBlomma
{
    class Healthbar
    {
        Texture2D healthTexture;
        Rectangle healthRectangle;

        public Healthbar()
        {
            healthTexture = Content.Load<Texture2D>("health");
            healthRectangle = new Rectangle(50, 20, player.health, 20);
        }
    }
}

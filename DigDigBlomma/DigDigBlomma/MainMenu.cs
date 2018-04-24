using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DigDigBlomma
{
    class MainMenu
    {
        public Texture2D buttonTex;
        public Vector2 buttonPos;
        public Rectangle buttonRec;
        public Vector2 size;
        Color color = new Color(255, 255, 255, 255);

        public MainMenu()
        {
            buttonPos = new Vector2(0, 0);
            size = new Vector2(400, 400);
            buttonTex = TextureLibrary.textures["StartButton"];
        }
        bool down;
        public bool isClicked;
        public void  Update(MouseState mouse)
        {
            buttonRec = new Rectangle((int)buttonPos.X, (int)buttonPos.Y, (int)size.X / 10, (int)size.Y / 10);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(buttonRec))
            {
                if(color.A == 255)
                {
                    down = false;
                }
                if (color.A == 0)
                {
                    down = true;
                }
                if (down)
                {
                    color.A += 3;
                }

                else
                {
                    color.A -= 3;
                }
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;

                }
                else if(color.A < 255)
                {
                    color.A += 3;
                    isClicked = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(buttonTex, buttonRec, color);
        }
    }
}



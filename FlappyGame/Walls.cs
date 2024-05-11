using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyGame
{
    internal class Walls
    {
        public float x;
        public float y;

        public int sizeX;
        public int sizeY;
        

        

        public Image wallsImg;

        public bool isAlive;

        public Walls(int x, int y, bool isRotatedImage = false)
        {
            wallsImg = new Bitmap("C:\\Users\\User\\Desktop\\Новая папка\\прга учеба\\FlappyGame\\Arts\\necoarc.jpg");
            this.x = x;
            this.y = y;
            sizeX = 50;     
            sizeY = 200;
            if (isRotatedImage) { wallsImg.RotateFlip(RotateFlipType.Rotate180FlipX); }

        }
    }
}

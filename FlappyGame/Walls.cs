using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FlappyGame
{
    internal class Walls
    {
        public  float x;
        public  float y;
       
        public  int sizeX;
        public  int sizeY;
       

        public Image wallsImg;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public Walls(int x, int y, bool isRotatedImage = false)
        {
                       
            string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName;
            string imagePath = Path.Combine(projectDirectory, "Arts", "necoarc.jpg");
            if (File.Exists(imagePath))
            {
                wallsImg = new Bitmap(imagePath);
            }
            else
            {
                MessageBox.Show("File not found: " + imagePath);
            }
            this.x = x;
            this.y = y;
            sizeX = 50;     
            sizeY = 200;
            if (isRotatedImage) { wallsImg.RotateFlip(RotateFlipType.Rotate180FlipX); }

        }
   
    }
}


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
        public float x;
        public float yTop; 
        public float yBottom; 
        public int heightTop; 
        public int heightBottom; 
        public int width; 
        public Image wallsImgTop;
        public Image wallsImgBottom;
        public bool scoreCounted = false; 
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public Walls(float x, int screenHeight)
        {

            string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName;
            string imagePath = Path.Combine(projectDirectory, "Arts", "1.png");
            if (File.Exists(imagePath))
            {
                wallsImgTop = new Bitmap(imagePath);
                wallsImgBottom = new Bitmap(imagePath);
            }
            else
            {
                MessageBox.Show("File not found: " + imagePath);
            }
            this.x = x;
            this.width = 50;
           Random rand = new Random();
            this.heightTop = rand.Next(50, screenHeight - 300); 
            this.heightBottom = (screenHeight - heightTop - 150); 
            

        }

    }
}



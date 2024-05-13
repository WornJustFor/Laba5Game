using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyGame
{
    internal class Dori
    {
        public float x;
        public float y;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public int sizeDori;
      
        public Image DoriImg;

       

        public Dori(int x, int y)
        {
            string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName;
            string imagePath = Path.Combine(projectDirectory, "Arts", "coin.png");

            if (File.Exists(imagePath))
            {
                DoriImg = new Bitmap(imagePath);
            }
            else
            {
                MessageBox.Show("File not found: " + imagePath);
            }
            this.x = x;
            this.y = y;
            sizeDori = 30;          
            

        }
    }
}

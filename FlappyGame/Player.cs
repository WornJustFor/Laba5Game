using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyGame
{
    internal class Player
    {
        public float x;
        public float y;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public int size;
        public int score;

        public float gravityValue;

        public Image necoImg;

        public bool isAlive;
              
        public Player(int x, int y)
        {
           
            string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName;
            string imagePath = Path.Combine(projectDirectory, "Arts", "necoarc.jpg");

            if (File.Exists(imagePath))
            {
                necoImg = new Bitmap(imagePath);
            }
            else
            {
                MessageBox.Show("File not found: " + imagePath);
            }

            // necoImg = new Bitmap("Arts\\necoarc.jpg");
            this.x = x;
            this.y = y;
            gravityValue = 0.1f;
            size = 50;            
            isAlive = true;
            score = 0;
        }
    }
}

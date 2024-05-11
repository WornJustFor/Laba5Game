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

        public int size;
        public int score;

        public float gravityValue;

        public Image necoImg;

        public bool isAlive;

        public Player(int x, int y)
        {
            necoImg = new Bitmap("C:\\Users\\User\\Desktop\\Новая папка\\прга учеба\\FlappyGame\\Arts\\necoarc.jpg");
            this.x = x;
            this.y = y;
            gravityValue = 0.2f;
            size = 50;            
            isAlive = true;
            score = 0;
        }
    }
}

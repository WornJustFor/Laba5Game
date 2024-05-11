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

        public int sizeDori;
      
        public Image DoriImg;

       

        public Dori(int x, int y)
        {
            DoriImg = new Bitmap("C:\\Users\\User\\Desktop\\Новая папка\\прга учеба\\FlappyGame\\Arts\\necoarc.jpg");
            this.x = x;
            this.y = y;
            sizeDori = 50;          
            

        }
    }
}

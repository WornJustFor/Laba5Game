
using System.Timers;
namespace FlappyGame
{
    public partial class Form1 : Form
    {
        int dCounter=0;
        Player neco;
        Walls wall;
        Walls wall2;       
        Dori dori;
        float gravity;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered=true;
            InitPlayer();
            InitWalls();
            Invalidate();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
           
        }

        public void InitPlayer()
        {
            neco = new Player(Left+50, 200);
            
          
           
        }
        public void InitWalls()
        {
            Random rPosy = new Random();           
            int Posy;          
            Posy = rPosy.Next(-200, 000);
            wall = new Walls(300, Posy,true);
            wall2 = new Walls(400, Posy+400);
         
            dori = new Dori(300, 200);

        }
        private void update(object sender, EventArgs e)
        {
            
                if (neco.y > 600)
                {
                    neco.isAlive = false;
                    timer1.Stop();
                InitPlayer();
                InitWalls();
                }

                if (Collide(neco, wall) || Collide(neco, wall2))
                {
                    neco.isAlive = false;
                    timer1.Stop();

            }
            if (CollideDori(neco, dori))
            {

                neco.isAlive = true;
                neco.score += 10; 
                this.Text = "NecoScore: " + neco.score;
                
                CreateNewDori();
               

            }
            if (neco.gravityValue != 0.1f)
                    neco.gravityValue += 0.005f;
                gravity += neco.gravityValue;
                neco.y += gravity;

                if (neco.isAlive)
                {
                MoveWalls();
                MoveDori();
                }

                Invalidate();
          
        }
        private void MoveWalls()
        {
            wall.x -= 2;
            wall2.x -= 2;
          
            CreateNewWall();
        }
    
        private void MoveDori()
        {
            dori.x -= 2;

            if (dori.x < -dori.sizeDori)
            {
               
                CreateNewDori();
                
            }
        }
        private void CreateNewWall()
        {
            
               
            
            if (wall.x < neco.x - 100)
            {
                
                Random r = new Random();
                int y1;
                y1 = r.Next(-200, 000);
                wall.wallsImg.Dispose();
                wall2.wallsImg.Dispose();             
                wall = new Walls(500, y1, true);
                wall2 = new Walls(500, y1 + 400);
             
                this.Text = "NecoScore: " + ++neco.score;
                 dCounter++;
            }
        }
       
        private void CreateNewDori()
        {
            if (timer2.Enabled) return;
            
                Random dy = new Random();
                 Random dx = new Random();
               int x2;
                int y2;
                y2 = dy.Next(-200, 000);
                x2 = dx.Next(Left + 100, 500 );
                dori.DoriImg.Dispose();

                dori = new Dori(x2, y2);

                
                this.Text = "NecoScore: " + neco.score;
                
            
        }
        private bool Collide(Player neco, Walls wall1)
        {
            PointF delta = new PointF();
            delta.X = (neco.x + neco.size / 2) - (wall1.x + wall1.sizeX / 2);
            delta.Y = (neco.y + neco.size / 2) - (wall1.y + wall1.sizeY / 2);
            if (Math.Abs(delta.X) <= neco.size / 2 + wall1.sizeX / 2)
            {
                if (Math.Abs(delta.Y) <= neco.size / 2 + wall1.sizeY / 2)
                {
                    return true;
                }
            }
            return false;
        }
  
        private bool CollideDori(Player neco, Dori dori)
        {
           
            bool xCollide = Math.Abs(neco.x + neco.size / 2 - (dori.x + dori.sizeDori / 2)) <= (neco.size / 2 + dori.sizeDori / 2);
            bool yCollide = Math.Abs(neco.y + neco.size / 2 - (dori.y + dori.sizeDori / 2)) <= (neco.size / 2 + dori.sizeDori / 2);

            if (xCollide && yCollide)
            {
                dori.DoriImg.Dispose(); 
                CreateNewDori();        
                return true;
            }
            return false;
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            graphic.DrawImage(neco.necoImg, neco.x, neco.y, neco.size, neco.size);
            graphic.DrawImage(wall.wallsImg,wall.x,wall.y, wall.sizeX, wall.sizeY);
            graphic.DrawImage(wall2.wallsImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);
            graphic.DrawImage(dori.DoriImg, dori.x, dori.y, dori.sizeDori, dori.sizeDori);

        }

        private void PlayClick(object sender, EventArgs e)
        {
            if (neco.isAlive)
            {
                gravity = 0;
                neco.gravityValue = -0.120f;
            }
        }
    }
}
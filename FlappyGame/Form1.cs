
using System.Timers;
namespace FlappyGame
{
    public partial class Form1 : Form
    {
      
        Player neco;
        Walls wall;
        Walls wall2;
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

                if (neco.gravityValue != 0.1f)
                    neco.gravityValue += 0.005f;
                gravity += neco.gravityValue;
                neco.y += gravity;

                if (neco.isAlive)
                {
                MoveWalls();
                }

                Invalidate();
          
        }
        private void MoveWalls()
        {
            wall.x -= 2;
            wall2.x -= 2;
            CreateNewWall();
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
               

                // this.Text = "NecoScore: " + ++neco.score;
            }
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

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            graphic.DrawImage(neco.necoImg, neco.x, neco.y, neco.size, neco.size);
            graphic.DrawImage(wall.wallsImg,wall.x,wall.y, wall.sizeX, wall.sizeY);
            graphic.DrawImage(wall2.wallsImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);
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
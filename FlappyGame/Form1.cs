
namespace FlappyGame
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
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
           
        }

        public void InitPlayer()
        {
            neco = new Player(200, 200);
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
        }
        public void InitWalls()
        {
            wall = new Walls(300, 300);
            wall2 = new Walls(400, Top);
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
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
                   //×òî-íèáóäü äëÿ äâèæåíèå èëè óäàëåíèå ñòåí
                }

                Invalidate();
          
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
    }
}


using System.Timers;
namespace FlappyGame
{
    public partial class Form1 : Form
    {
       
        private Label NecoLabel;
        internal int nMovementSpeed = 2;
        List<Walls> walls = new List<Walls>();      
        
        Player neco;            
        Dori dori;
        float gravity;
       

        private string CheckImg()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName).FullName).FullName;
            string imagePath = Path.Combine(projectDirectory, "Arts", "nebo.jpg");
            //MessageBox.Show( imagePath);
            return imagePath;
        }
        private async Task<Bitmap> LoadImageAsync(string filePath)
        {
            return await Task.Run(() => new Bitmap(filePath));
        }

       
        public async void InitBackImg()
        {
            try
            {
                string imagePath = CheckImg(); 
                Bitmap backgroundImage = await LoadImageAsync(imagePath);
                this.BackgroundImage = backgroundImage; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Îøèáêà ïðè çàãðóçêå èçîáðàæåíèÿ: " + ex.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
           // string ImgPath = CheckImg();
            this.DoubleBuffered = true;
            //InitBackImg();
            //this.BackgroundImage = InitBackImg();
            InitBackImg();
            this.BackgroundImageLayout=ImageLayout.Center;


            InitPlayer();
            InitWalls();
            InitDori();
            Invalidate();
            timer1.Interval = 5;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            
            NecoLabel = new Label { Location = new System.Drawing.Point(10, 10), Text = "NecoScore: 0" };
            this.Controls.Add(NecoLabel);
            
        }


        public void InitPlayer()
        {
            neco = new Player(Left+50, 200);
              
           
        }
        public void InitWalls()
        {

            CreateNewWall();




        }
        public void InitDori() {
            Random rPosy = new Random();
            int Posy = rPosy.Next(-200, 000);
            dori = new Dori(Posy + 100, 200); }
        private void update(object sender, EventArgs e)
        {
            
                if (neco.y > 600 || !neco.isAlive || CheckCollisions())
                {
                    neco.isAlive = false;                
                    timer1.Stop();
                InitPlayer();
                InitWalls();
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
            int spacingX = 300;
            foreach (var wall in walls)
            {
                wall.x -= nMovementSpeed;

                if (wall.x + wall.width < neco.x && !wall.scoreCounted)
                {
                    neco.score += 1;
                    wall.scoreCounted = true;
                }

                if (wall.x < -wall.width)
                {
                    wall.x = walls.Max(w => w.x) + spacingX;
                    Random rand = new Random();
                    wall.heightTop = rand.Next(50, this.Height - 300);
                    wall.heightBottom = this.Height - wall.heightTop - 150;
                    wall.scoreCounted = false;
                }
            }
            this.Text = "NecoScore: " + neco.score;
        }



        private void MoveDori()
        {
            dori.x -= nMovementSpeed;

            if (dori.x < -dori.sizeDori)
            {
               
                CreateNewDori();
                
            }
        }
        
            private void CreateNewWall()
        {
            
            Random r = new Random();
            int initialX = 300;
            int spacingX = 300; 

            walls.Clear();
            for (int i = 0; i < 5; i++)
            {
                Walls newWall = new Walls(initialX + i * spacingX, this.Height);
                walls.Add(newWall);
            }
        }

       

        private void CreateNewDori()
        {
           
            int x2;
            int y2;            
            Random dy = new Random();
            Random dx = new Random();

           
                y2 = dy.Next(Top - 200, 500);
                x2 = dx.Next(Left + 100, Right);
              
                dori.DoriImg.Dispose();
                
                dori = new Dori(x2, y2);
             
             
                        
                this.Text = "NecoScore: " + neco.score;
                
            
        }
       

        private bool Collide(Player neco, Walls wall)
        {
           
            bool collideTop = neco.y < wall.heightTop && neco.x + neco.size > wall.x && neco.x < wall.x + wall.width;

            
            bool collideBottom = neco.y + neco.size > this.Height - wall.heightBottom && neco.x + neco.size > wall.x && neco.x < wall.x + wall.width;

            return collideTop || collideBottom;
        }
        private bool CheckCollisions()
        {
            foreach (var wall in walls)
            {
                if (Collide(neco, wall))
                {
                    neco.isAlive = false;
                    timer1.Stop();
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
            //if (this.BackgroundImage != null)
            //    graphic.DrawImage(this.BackgroundImage, 0, 0, this.Width, this.Height);

            graphic.DrawImage(neco.necoImg, neco.x, neco.y, neco.size, neco.size);
           
            graphic.DrawImage(dori.DoriImg, dori.x, dori.y, dori.sizeDori, dori.sizeDori);
                       
                NecoLabel.Text = $"NecoScore: {neco.score}";
                      
            
            foreach (var wall in walls)
            {
                if (wall.wallsImgTop != null)
                    graphic.DrawImage(wall.wallsImgTop, wall.x, 0, wall.width, wall.heightTop);
                if (wall.wallsImgBottom != null)
                    graphic.DrawImage(wall.wallsImgBottom, wall.x, this.Height - wall.heightBottom, wall.width,   wall.heightBottom);
            }
            
        }

       
        private void PlayClick(object sender, EventArgs e)
        {
            if (neco.isAlive)
            {
                gravity = 0;
                neco.gravityValue = -0.120f;
            }
        }
        private void PlayDoubleClick(object sender, EventArgs e)
        {
            if (neco.isAlive)
            {
                gravity = 0;
                neco.gravityValue = -0.240f;
            }
        }
    }
}

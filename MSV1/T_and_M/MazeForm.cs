using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_and_M
{
    public partial class MazeForm : Form
    {
        public MazeForm()
        {
            InitializeComponent();
        }

        void MazeForm_Load(object sender, EventArgs e)
        {
            CreateMap();
            PrintMap();
            LoadResources();
            Play();
            Render();
        }

        Tile[,] Map;
        Label[,] tile;
        Panel pnl;
        Bitmap img_theseus;
        Bitmap img_minotaur;
        PictureBox player;
        PictureBox opponent;
        Theseus theseus;
        Minotaur minotaur;
        Label Coord;
        enum direction : byte {Up = 1, Down, Left, Right};
        bool canMove = true;

        public void CreateMap()
        {
            Map = new Tile[3, 3];
            //Tile(UP, DOWN, LEFT, RIGHT)
            //[x,y]
            Map[0, 0] = new Tile(true, false, true, false);
            Map[1, 0] = new Tile(true, true, false, false);
            Map[2, 0] = new Tile(true, false, false, true);

            Map[0, 1] = new Tile(false, false, true, false);
            Map[1, 1] = new Tile(true, true, false, true);
            Map[2, 1] = new Tile(false, false, true, false);

            Map[0, 2] = new Tile(false, true, true, false);
            Map[1, 2] = new Tile(true, true, false, false);
            Map[2, 2] = new Tile(false, true, false, true);

            theseus = new Theseus(1, 2);
            minotaur = new Minotaur(1, 0);
        }

        public void PrintMap()
        {
            int mapWidth = Map.GetLength(0);
            int mapHeight = Map.GetLength(1);
            tile = new Label[mapWidth, mapHeight];

            pnl = new Panel();
            pnl.Size = new Size(this.Width, this.Height);
            pnl.Location = new Point(10, 10);
            this.Controls.Add(pnl);

            int width = 90;
            int height = 90;
            int xSpacing = 0;
            int ySpacing = 0;

            opponent = new PictureBox();
            player = new PictureBox();
            pnl.Controls.Add(opponent);
            opponent.Size = new System.Drawing.Size(width, height);
            opponent.SizeMode = PictureBoxSizeMode.CenterImage;
            opponent.BorderStyle = BorderStyle.FixedSingle;
            pnl.Controls.Add(player);
            player.Size = new System.Drawing.Size(width, height);
            player.SizeMode = PictureBoxSizeMode.CenterImage;
            player.BorderStyle = BorderStyle.FixedSingle;
            

            for (int row = 0; row < mapWidth; row++)
            {

                for (int column = 0; column < mapHeight; column++)
                {
                    if (Map[row, column].UpWall)
                    {
                        Label wall = new Label();
                        wall.Size = new Size(width, height / 5);
                        wall.Location = new Point((row * width) + xSpacing, (column * height) + ySpacing);
                        wall.BackColor = Color.Black;
                        pnl.Controls.Add(wall);
                        wall.BringToFront();
                    }
                }
            }

            for (int row = 0; row < mapWidth; row++)
            {
                for (int column = 0; column < mapHeight; column++)
                {
                    if (Map[row, column].DownWall)
                    {
                        Label wall = new Label();
                        wall.Size = new Size(width, height / 5);
                        wall.Location = new Point((row * width) + xSpacing, (column * height) + ySpacing + height - (height / 5));
                        wall.BackColor = Color.Black;
                        pnl.Controls.Add(wall);
                        wall.BringToFront();
                    }
                }
            }

            for (int row = 0; row < mapWidth; row++)
            {
                for (int column = 0; column < mapHeight; column++)
                {
                    if (Map[row, column].LeftWall)
                    {
                        Label wall = new Label();
                        wall.Size = new Size(width / 5, height);
                        wall.Location = new Point((row * width) + xSpacing, (column * height) + ySpacing);
                        wall.BackColor = Color.Black;
                        pnl.Controls.Add(wall);
                        wall.BringToFront();
                    }
                }
            }

            for (int row = 0; row < mapWidth; row++)
            {
                for (int column = 0; column < mapHeight; column++)
                {
                    if (Map[row, column].RightWall)
                    {
                        Label wall = new Label();
                        wall.Size = new Size(width / 5, height);
                        wall.Location = new Point((row * width) + xSpacing + width - (width / 5), (column * height) + ySpacing);
                        wall.BackColor = Color.Black;
                        pnl.Controls.Add(wall);
                        wall.BringToFront();
                    }
                }
            }

            for (int row = 0; row < mapWidth; row++)
            {
                for (int column = 0; column < mapHeight; column++)
                {
                    Label t = new Label();
                    t.Size = new Size(width, height);
                    t.Location = new Point((row * width) + xSpacing, (column * height) + ySpacing);
                    t.BackColor = Color.Gainsboro;
                    t.BorderStyle = BorderStyle.FixedSingle;
                    tile[row, column] = t;
                    pnl.Controls.Add(t);
                }
            }

            Coord = new Label();
            pnl.Controls.Add(Coord);
            Coord.SetBounds(0, this.Height-110, 60, 60);
            Coord.ForeColor = Color.White;
            Coord.BackColor = Color.Black;
            Coord.BringToFront();
        }

        private void LoadResources()
        {
            img_theseus = new Bitmap(Properties.Resources.Theseus);
            img_minotaur = new Bitmap(Properties.Resources.Minotaur);
            player.Image = img_theseus;
            opponent.Image = img_minotaur;
        }

        private void Play()
        {
            bool alive = true;
            bool win = false;
            
            player.Location = GetPosition(theseus.Position.X, theseus.Position.Y);
            opponent.Location = GetPosition(minotaur.Position.X, minotaur.Position.Y);

            TheseusTurn();
            MinotaurTurn();
            if (theseus.Position == minotaur.Position)
            {
                End();
            }
        }

        private Point GetPosition(int posX, int posY)
        {
            return tile[posX, posY].Location;
        }

        private string Coordinates(Thing thing)
        {
            return "{X=" + (thing.Position.X).ToString() + "," + "Y=" + (thing.Position.Y).ToString() + "}";
        }

        private void Render()
        {
            player.Location = GetPosition(theseus.Position.X, theseus.Position.Y);
            opponent.Location = GetPosition(minotaur.Position.X, minotaur.Position.Y);

            Coord.Text = ("Theseus: " + Coordinates(theseus));
            Coord.Text += ("Minotaur: " + Coordinates(minotaur));
            //MessageBox.Show("Theseus: " + player.Location.ToString());
            //MessageBox.Show("Minotaur: " + opponent.Location.ToString());
        }

        private void TheseusTurn()
        {
           canMove = true;
        }

        private void MinotaurTurn()
        {
            int count = 0;
            int ComboBreaker = 0;
            while (count <2)
            {
                ComboBreaker += 1;
                if (!(minotaur.Position.X == theseus.Position.X))
                {
                    if (minotaur.Position.X > theseus.Position.X)
                    {
                        if (!(IsBlocked(minotaur.Position, "left")))
                        {
                            Move(minotaur, "left");
                            MessageBox.Show("Minotaur says: LEFT");
                            count += 1;
                        }
                    }
                    else if (!(IsBlocked(minotaur.Position, "right")))
                    {
                        Move(minotaur, "right");
                        MessageBox.Show("Minotaur says: RIGHT");
                        count += 1;
                    }
                }

                if (!(minotaur.Position.Y == theseus.Position.Y))
                {
                    if (minotaur.Position.Y < theseus.Position.Y)
                    {
                        if (!(IsBlocked(minotaur.Position, "down")))
                        {
                            Move(minotaur, "down");
                            MessageBox.Show("Minotaur says: DOWN");
                            count += 1;
                        }
                    }
                    else if (!(IsBlocked(minotaur.Position, "up")))
                    {
                        Move(minotaur, "up");
                        MessageBox.Show("Minotaur says: UP");
                        count += 1;
                    }
                }
                if (ComboBreaker >= 5)
                {
                    break;
                }
            }
        }

        void Move(Thing thing, string direction)
        {
            switch (direction)
            {
                case "up":
                    thing.Position.Y -= 1;
                    Render();
                    break;
                case "down":
                    thing.Position.Y += 1;
                    Render();
                    break;
                case "left":
                    thing.Position.X -= 1;
                    Render();
                    break;
                case "right":
                    thing.Position.X += 1;
                    Render();
                    break;
            }

        }

        private void MoveTheseus(int x, int y, string direction)
        {
            if (!IsBlocked(theseus.Position, direction))
            {
                Move(theseus, direction);
                MessageBox.Show("Theseus says: " + direction.ToUpper());

                canMove = false;
            } 
        }

        private bool IsBlocked(Point pos, string direction)
        {
            if (Map[pos.X, pos.Y].UpWall && direction == "up")
            {
                return true;
            }
            else if (Map[pos.X, pos.Y].DownWall && direction == "down")
            {
                return true;
            }
            else if (Map[pos.X, pos.Y].LeftWall && direction == "left")
            {
                return true;
            }
            else if (Map[pos.X, pos.Y].RightWall && direction == "right")
            {
                return true;
            }
            return false;
        }

        private void MazeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (canMove)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        MoveTheseus(0, -1, "up");
                        Play();
                        break;
                    case Keys.Down:
                        MoveTheseus(0, 1, "down");
                        Play();
                        break;
                    case Keys.Left:
                        MoveTheseus(-1, 0, "left");
                        Play();
                        break;
                    case Keys.Right:
                        MoveTheseus(1, 0, "right");
                        Play();
                        break;
                }
            }
        }

        private void End()
        {
            MessageBox.Show("Minotaur says: YUM!");
            Application.Exit();
        }

    }
}
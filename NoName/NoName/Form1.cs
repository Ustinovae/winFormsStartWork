using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoName
{
    public partial class Form1 : Form
    {
        private PictureBox player = new PictureBox();
        private Size sizeField = new Size(800, 800);
        private Point direction = new Point(0, 0);
        private int step = 5;
        private Timer timer = new Timer();
        private PictureBox star = new PictureBox();
        private Label score = new Label();
        private bool checkJoin = false;

		public Form1()
        {
            score.Location = new Point(850, 0);
            score.Text = "Score: 0";
            BackgroundImage = Resource1.Background_png;
            star.Size = new Size(120, 200);
            star.Location = new Point(500, 500);
            star.Image = Resource1.star;
            ClientSize = sizeField;
            //Size = sizeField;
            GenerateMap();
            Controls.Add(score);
            Controls.Add(star);
            Controls.Add(player);
            this.player.Location = new Point(10, 10);
            this.player.Size = new Size(120, 200);
            player.Image = Resource1.Player_png;
            KeyDown += new KeyEventHandler(OKP);
            timer.Tick += new EventHandler(UpdateMap);
            timer.Interval = 30;
            timer.Start();
        }

        private void UpdateMap(object sender, EventArgs e)
        {
            MoveSnake();
        }

        private void GenerateMap()
        {
            for (var i = 0; i < 2; i++)
            {
                var board = new PictureBox();
                board.Location = new Point(i*800, 0);
                board.Height = 800;
                board.Width = 10;
                board.BackColor = Color.Black;
                Controls.Add(board);
            }

            for (var i = 0; i < 2; i++)
            {
                var board = new PictureBox();
                board.Location = new Point(0, i*800);
                board.Height = 10;
                board.Width = 810;
                board.BackColor = Color.Black;
                Controls.Add(board);
            }
        }

        private void MoveWithObject()
        {
            checkJoin = true;
        }

        private void MoveWithOutObject()
        {
            checkJoin = false;
        }

        private void MoveSnake()
        {
            if (checkBorders() || CheckObject())
            {
                direction.X = 0;
                direction.Y = 0;
            }
            player.Location = new Point(player.Location.X + direction.X * step, player.Location.Y + direction.Y * step);
            if (checkJoin)
                MoveStar();
        }

        private void MoveStar()
        {
            star.Location = new Point(star.Location.X + direction.X * step, star.Location.Y + direction.Y * step);
        }

        private bool CheckObject()
        {
            return player.Location.X + player.Width + direction.X * step > star.Location.X &&
                player.Location.X + direction.X * step < star.Location.X + star.Width &&
                player.Location.Y + player.Height + direction.Y * step > star.Location.Y &&
                player.Location.Y + direction.Y * step < star.Location.Y + star.Height;
        }

        private bool checkBorders()
        {
            return (player.Location.X + direction.X * step < 10 || player.Location.X + player.Width + direction.X * step >= 810 ||
                player.Location.Y + direction.Y * step < 10 || player.Location.Y + player.Height + direction.Y * step >= 810);
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    direction.X = 1;
                    direction.Y = 0;
                    break;
                case "Left":
                    direction.X = -1;
                    direction.Y = 0;
                    break;
                case "Up":
                    direction.X = 0;
                    direction.Y = -1;
                    break;
                case "Down":
                    direction.X = 0;
                    direction.Y = 1;
                    break;
                case "Q":
                    MoveWithObject();
                    break;
                case "A":
                    MoveWithOutObject();
                    break;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NoName
{
    class Player
    {
        private PictureBox player;
        private int step;

        public Player()
        {
            player = new PictureBox();
            player.BackColor = Color.Red;
            player.Location = new Point(100, 100);
            player.Width = 100;
            
        }

        public void MoveTo()
        {

        }
    }
}

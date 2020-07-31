using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YvanTheKnight
{
    

    class Hero : Knight
    {
        public int x, y;

        public Hero(String name, DateTime bday, String origin, int h, int w, String app, String king, float horseSpeed) : base(name, bday, origin, h, w, app, king, horseSpeed)
        {
            //the Hero starts at the top left corner
            x = 0;
            y = 0;
        }

        public void moveUp()
        {
            x--;
        }
        public void moveDown()
        {
            x++;
        }
        public void moveLeft()
        {
            y--;
        }
        public void moveRight()
        {
            y++;
        }
    }
}

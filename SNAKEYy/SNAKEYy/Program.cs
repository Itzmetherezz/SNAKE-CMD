using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKEYy
{
    internal class Coordinate
    {

        private int x;
        private int y;

        public int X
        {
            get { return x; }   
            
        }

        public int Y
        {
            get { return y; }

        }

        public Coordinate (int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)

        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Coordinate other = (Coordinate)obj;
            return (x == other.x) && (y == other.y);

        }
        public void ApplyMovementDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
            }
        }













    }
}

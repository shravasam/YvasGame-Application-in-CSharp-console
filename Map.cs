using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YvanTheKnight
{
    class Map
    {

        private const float _propabilityCellNotEmpty= 1 / 5.0f;
        private const float _propabilitySoldier = 8 / 10.0f;
        


        //possibles values that can take a cell
        public static Dictionary<string, char> _cellCode;

        //we create a 2D array of char (and not Person). We will generate a Person only when the cell tells us to do so
        private char[,] _map ;

        //we need this to redraw the correct value when the here lft a cell
        private char whatWasHereBeforeHero; 
        private int lastXHero;
        private int lastYHero;
        private bool firstTimeWeDrawTheHero;

        //castle information
        private int castleX;
        private int castleY;

        public Map(int sizeX, int sizeY)
        {
       
            
            _cellCode = new Dictionary<string, char>();
            _cellCode.Add("empty", '.'); //X is not very convenient, smaller character makes the map clearer
            _cellCode.Add("soldier", 'S');
            _cellCode.Add("knight", 'K');
            _cellCode.Add("hero", '*');
            _cellCode.Add("castle", '#');

            //memory allocation of the map
            _map = new char[sizeX, sizeY];

            //initialization of the content of the map
            Random r = new Random();

            for(int x = 0; x < _map.GetLength(0); x++) //for line number X
            {
                for (int y = 0; y < _map.GetLength(1); y++) //every colown Y
                {
                    if (r.NextDouble() <= _propabilityCellNotEmpty)
                    {
                        //cell is not empty
                        if (r.NextDouble() < _propabilitySoldier) //it's a soldier !
                            _map[x, y] = _cellCode["soldier"];
                        else
                            _map[x, y] = _cellCode["knight"];
                    }
                    else
                    {
                        //cell is empty
                        _map[x,y] = _cellCode["empty"];
                    }
                }
            }

            firstTimeWeDrawTheHero = true;

        }

        public void Print()
        {
           Console.Clear();
            for (int x = 0; x < _map.GetLength(0); x++)
            {
                for (int y = 0; y < _map.GetLength(1); y++)
                {
                    Console.Write(_map[x, y]);   
                }
                Console.WriteLine();
            }
        }

        public char getCell(int x, int y)
        {
            return whatWasHereBeforeHero;
        }

        

        public void setHeroLocation(Hero h)
        {

            if (!firstTimeWeDrawTheHero)
            {
                //let's draw back the cell he left!
                _map[lastXHero, lastYHero] = whatWasHereBeforeHero;
            }
            else
                firstTimeWeDrawTheHero = false;

            //we store the information of the cell he moves to before overdrawing it
            whatWasHereBeforeHero = _map[h.x, h.y];
            //we can draw the hero now
            _map[h.x, h.y] = _cellCode["hero"];
            
            //let's store what cell will need to be redrawn for the future
            lastXHero = h.x;
            lastYHero = h.y;

        }

        public void setCastleLocation(int x, int y)
        {
            if(x >= 0 && x < _map.GetLength(0) && y >= 0 && y < _map.GetLength(1))
            {
                _map[x, y] = _cellCode["castle"];
                castleX = x;
                castleY = y;
            }
            else
            {
                Console.WriteLine("error with coordinates in setCastleLocation");
            }
            
        }

        //returns the size of the dimension of the map (0 is x, 1 is y)
        public int getDimension(int dim)
        {
            if (dim == 0 || dim == 1)
                return _map.GetLength(dim);
            else
            {
                Console.WriteLine("dimension does not exist");
                return -1;
            }

        }

        public bool HeroReachTheCastle(Hero h)
        {
            if (h.x == castleX && h.y == castleY)
                return true;
            else
                return false;

        }
        public void emptyCell( Hero h)
        {
            whatWasHereBeforeHero = _cellCode["empty"];
        }
    }
}

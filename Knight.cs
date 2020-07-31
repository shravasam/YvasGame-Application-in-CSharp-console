using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YvanTheKnight
{

    class Knight : Soldier
    {
        private float _horseSpeed;

        public Knight(String name, DateTime bday, String origin, int h, int w, String app, String king, float horseSpeed) : base(name, bday, origin, h, w, app,king)
        {
            _horseSpeed = horseSpeed < 0 ? 0 : horseSpeed;

            //even if a Knight is a soldier, its weapon is different ! 
            _weapon.Name = "Diamond Blade";
            _weapon.Power = 3;

            _probabilityOfAttackSuccess = 4 / 5.0f;
        }

        public float HorseSpeed
        {
            get
            {
                return _horseSpeed;
            }
            set
            {
                _horseSpeed =   value < 0 ? 0 : value;
            }
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine("I am a knight ! ");

        }


    }
}

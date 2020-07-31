using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YvanTheKnight
{
    class Soldier : Person
    {
        protected Weapon _weapon; //child classes might want to access it! 
        private String _myKing;
        protected float _probabilityOfAttackSuccess;

        public Soldier(String name, DateTime bday, String origin, int h, int w, String app, String king) : base( name,  bday,  origin,  h,  w,  app)
        {
            _weapon = new Weapon("Iron Sword", 1);
            _probabilityOfAttackSuccess = 3 / 5.0f;


            if (king.ToUpper().Equals("NIGHT KING") || king.ToUpper().Equals("DAY KING"))
                _myKing = king.ToUpper();
            else
                _myKing = "UNKNOWN";
        }

        //properties
        public Weapon Weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value ;
            }
        }

        public String King
        {
            get
            {
                return _myKing;
            }
            set
            {
                if (value.ToUpper().Equals("NIGHT KING") || value.ToUpper().Equals("DAY KING"))
                    _myKing = value.ToUpper();
            }
        }


        public override void Display()
        {
            base.Display(); //let's print the Person part of the Soldier

            //and add what is specific to a soldier
            Console.WriteLine("I am a serving for " + _myKing);
        }

        public void Attack(Person targetPerson)
        {
            
            Random randomGenerator = new Random();

            if(randomGenerator.NextDouble() < _probabilityOfAttackSuccess )
            {

                Console.WriteLine("succesful attack from " + _name);
                //we use OUR weapon to inflict damages to the target
                targetPerson.receiveDamage( _weapon.Use() );
                
            }
            else
            {
                Console.WriteLine("the attack from " + _name + " failed");
            }
             
        }


    }
}

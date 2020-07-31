using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YvanTheKnight
{
    class Weapon
    {
        private String _name;
        private int _power;
        private int _state; //is the weapon in good condition? Exrpessed as %

        public Weapon(String name, int power)
        {
            _name = name;
            _power = power > 0 ? power : 0;
            _state = 100; //100% when the weapon is new !

        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Power
        {
            get { return _power; }
            set { _power = value > 0 ? value : 0; }
        }

        public int State
        {
            get{ return _state; }
            
        }
        /// <summary>
        /// Will return the strength of the weapon depending on its state and update its state
        /// </summary>
        /// <returns></returns>
        public float Use()
        {
            //the weapon will be less strong next time we use it
            getOlder();
            //the lower the state, the weaker the attack
            return _power * (_state / 100.0f);
            
        }
        
            

        //updating the state of the weapon if it is used
        private void getOlder()
        {
            if (_state >= 55)
                _state -= 5;
        }

        public void repair()
        {
            _state = 100;
        }

    }
}

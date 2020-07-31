using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace YvanTheKnight
{
    class Person
    {
        protected String _name;
        private DateTime _birthDate; //we will only use the date part of this type
        private String _originVillage;
        private int _height_cm;
        private int _weight_kg;
        private String _appearance;
        private float _hp; //health points

        public String Name
        {
            get {return _name;}
        }

        public float HP
        {
            get { return _hp; }
        }

        


        //constructor
        public Person(String name, DateTime bday, String origin, int h, int w, String app)
        {
            _name = name;
            _birthDate = bday.Date;
            _originVillage = origin;
            _height_cm = h;
            _weight_kg = w;
            _appearance = app;
            _hp = 10;
        }

        private double ComputeBodyMassIndex()
        {
            return _weight_kg / Math.Pow(_height_cm / 100.0f, 2);
        }

        public virtual void Display()
        {
            String figure;
            double BMI = ComputeBodyMassIndex();

            if (BMI > 30)
                figure = "really heavy";
            else if (BMI > 18.5)
                figure = "not so heavy";
            else
                figure = "really thin";

            Console.WriteLine("-------------------");
            Console.WriteLine("A " + figure + " person is approaching, looking " + _appearance);

            int age = DateTime.Now.Year - _birthDate.Year;
            String ageLook;

            if (age < 20)
                ageLook = "really young";
            else if (age < 40)
                ageLook = "young";
            else if (age < 60)
                ageLook = "middle aged";
            else
                ageLook = "quite old";



            Console.WriteLine("This " + ageLook + " person suddenly starts to speak:");
            Console.WriteLine("Hello, my name is " + _name);
            Console.WriteLine("I come from " + _originVillage);

        }


        public bool isAlive()
        {
            if (_hp > 0)
                return true;
            else
                return false;
        }

        public void receiveDamage(float damage)
        {
            Console.WriteLine(_name + " received " + damage + " points of damages");
            _hp -= damage;
        }

        
    }


}

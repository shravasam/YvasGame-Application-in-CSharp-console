﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YvanTheKnight
{
    class Program
    {
        public static void showRules()
        {
            Console.WriteLine("use zqsd letters to move Yvan (represented as the * on the map");
            Console.WriteLine("You need to reach the castle, represented as the # on the map");
            Console.WriteLine("---have a safe journey---");
            Console.WriteLine("\npress ENTER to begin");
            Console.ReadLine();
            Console.Clear();
        }

        //this function will manage all the steps of a battle
        //return true if Yvan won the battle
        public static bool Battle(Hero h , Soldier ennemy)
        {
            //who will start the fight?
         
            Random r = new Random();
            bool herosTurn = r.NextDouble() < 0.5f ? true : false;

            while(h.isAlive() && ennemy.isAlive())
            {
                if(herosTurn)
                {
                    h.Attack(ennemy);
                }
                else
                {
                    ennemy.Attack(h);
                }

                herosTurn = !herosTurn;
            }
            String nameOfTheLooser = h.isAlive() ? ennemy.Name : h.Name;

            Console.WriteLine();
            Console.WriteLine(nameOfTheLooser + " lost the battle");
            Console.WriteLine("\npress ENTER to carry on the adventure");
            Console.ReadLine();
            Console.Clear();

            return h.isAlive();
        }


        static void Main(string[] args)
        {

            Console.WriteLine("---Yvan the Knight---");
            Random rnd = new Random(); //in order to pick entries amongst the following pools

            String[] poolOfKnightNames = { "Arthur" , "Karadoc" , "Perceval","Lancelot"};
            String[] poolOfSoldierNames = { "Joe" , "Brian" , "Kevin","Mattew"};
            String[] poolOfCities = { "Rome", "Palermo", "Florence", "Milano" };
            String[] poolOfAppearances = { "funny", "strong", "impressive", "scary" };
            String[] poolOfKings = { "Dlsay King", "Night King"};



           
            showRules();

            //the user has to choose a king to fight for
            String kingChoice;
            do
            {
                Console.WriteLine("Welcome to the game ! Please select a King !");
                Console.WriteLine("King Day : enter the letter 'd' and press enter");
                Console.WriteLine("King Night : enter the letter 'n' and press enter");

                kingChoice = Console.ReadLine();

            } while (kingChoice[0] != 'd' && kingChoice[0] != 'n');
         
            
            //creation of the hero of the game
            Hero Yvan = new Hero("Yvan", new DateTime(1989, 12, 25), "Rome", 190, 85, "heroic", "Day king", 100);

            //creation of the map of the game
            Map map = new Map(10, 10);

            //place our Hero at his starting point
            map.setHeroLocation(Yvan);

            //place the caslte at the bottom right corner
            map.setCastleLocation(map.getDimension(0)-1, map.getDimension(1) - 1);

            //show the map to the player
            map.Print();

            /*let's start the game !! 
             * we will be playing until yvan reach the castle or dies
            */

            do
            {

                //let's refresh the screen to show new Yvan's Location
                map.setHeroLocation(Yvan);
                map.Print();
                Console.WriteLine("Yvan's HP => " + Yvan.HP);



                String userInput = Console.ReadLine();

                if(userInput.Length > 0)
                {

                    switch (userInput[0])
                    {
                        case 'z':
                            if (Yvan.x > 0)
                            {
                                Yvan.moveUp();
                            }
                            else
                            {
                                Console.WriteLine("out of bound, look out for Yvan !");
                            }
                            break;

                        case 's':
                            if (Yvan.x < map.getDimension(0) - 1)
                            {
                                Yvan.moveDown();
                            }
                            else
                            {
                                Console.WriteLine("out of bound, look out for Yvan !");
                            }
                            break;
                        case 'q':
                            if (Yvan.y > 0)
                            {
                                Yvan.moveLeft();
                            }
                            else
                            {
                                Console.WriteLine("out of bound, look out for Yvan !");
                            }
                            break;
                        case 'd':
                            if (Yvan.y < map.getDimension(1) - 1)
                            {
                                Yvan.moveRight();
                            }
                            else
                            {
                                Console.WriteLine("out of bound, look out for Yvan !");
                            }
                            break;
                        default:
                            Console.WriteLine("wrong input (zqsd to move)");
                            break;
                    }//end of user input reading

                    //let's refresh the screen to show new Yvan's Location
                    map.setHeroLocation(Yvan);
                    map.Print();
                    Console.WriteLine("Yvan's HP => " + Yvan.HP);

                    //let's manage encounters on this new cell
                    char cell = map.getCell(Yvan.x, Yvan.y);

                    

                    if (cell == Map._cellCode["empty"])
                    {
                        Console.WriteLine("nothing to do here");
                    }
                    else if (cell == Map._cellCode["soldier"])
                    {
                        String rndName = poolOfSoldierNames[rnd.Next(0, poolOfSoldierNames.Length)];
                        String rndCity = poolOfCities[rnd.Next(0, poolOfCities.Length)];
                        String rndApp = poolOfAppearances[rnd.Next(0, poolOfAppearances.Length)];
                        String rndKing = poolOfKings[rnd.Next(0, poolOfKings.Length)];
                        int rndYear = rnd.Next(1960, 2018);
                        int rndMonth = rnd.Next(1, 12);
                        int rndDay = rnd.Next(1, 30);
                        int rndHeight = rnd.Next(150, 210);
                        int rndWeight = rnd.Next(50, 150);

                        Soldier randomSoldier = new Soldier(rndName, new DateTime(rndYear, rndMonth, rndDay), rndCity, rndHeight, rndWeight, rndApp, rndKing);

                        randomSoldier.Display();
                        //is he friendly?
                        if (Yvan.King == randomSoldier.King)
                        {
                            Console.WriteLine("he is a friend ! He proposes to repair your " + Yvan.Weapon.Name);
                            Yvan.Weapon.repair();
                            Console.WriteLine("\npress ENTER to continue");
                            Console.ReadLine();
                            Console.Clear();

                        }
                        else //ennemy
                        {
                            Console.WriteLine("he is an ennemy ! You have to fight");
                            bool yvanWon = Battle(Yvan, randomSoldier);
                            if (yvanWon)
                                map.emptyCell(Yvan);

                        }
                    }
                    else if (cell == Map._cellCode["knight"])
                    {
                        String rndName = poolOfSoldierNames[rnd.Next(0, poolOfSoldierNames.Length)];
                        String rndCity = poolOfCities[rnd.Next(0, poolOfCities.Length)];
                        String rndApp = poolOfAppearances[rnd.Next(0, poolOfAppearances.Length)];
                        String rndKing = poolOfKings[rnd.Next(0, poolOfKings.Length)];
                        int rndYear = rnd.Next(1960, 2018);
                        int rndMonth = rnd.Next(1, 12);
                        int rndDay = rnd.Next(1, 31);
                        int rndHeight = rnd.Next(150, 210);
                        int rndWeight = rnd.Next(50, 150);
                        int rndHorseSpeed = rnd.Next(1, 100);

                        Knight randomKnight = new Knight(rndName, new DateTime(rndYear, rndMonth, rndDay), rndCity, rndHeight, rndWeight, rndApp, rndKing, rndHorseSpeed);

                        randomKnight.Display();
                        //is he friendly?
                        if (Yvan.King == randomKnight.King)
                        {
                            Console.WriteLine("he is a friend ! He proposes to repair your " + Yvan.Weapon.Name);
                            Yvan.Weapon.repair();

                        }
                        else
                        {
                            Console.WriteLine("he is an ennemy ! You have to fight");
                            bool yvanWon = Battle(Yvan, randomKnight);
                            if (yvanWon)
                                map.emptyCell(Yvan);
                        }
                    }//end of Knight encounter
                    else if (cell == Map._cellCode["castle"])
                        Console.WriteLine("welcome to the castle");
                    else
                        Console.WriteLine("problem of unknown cell");





                }//end of input length check

            } while (Yvan.isAlive() && !map.HeroReachTheCastle(Yvan));

            if (Yvan.isAlive())
                Console.WriteLine("!! congratulation !!");
            else
                Console.WriteLine("!! game over !!");


            Console.Read();
        }
    }
}

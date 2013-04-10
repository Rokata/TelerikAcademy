﻿using System;

namespace MinesGame
{
    public class Player
    {
        string name;
        int points;

        public Player() 
        { 
        }

        public Player(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }     
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class Player : IPlayer
    {
        private string _name;
        private string _marker;

        public Player(string name, string marker)
        {
            _name = name;
            _marker = marker;
        }

        public string Name => _name; 

        public string Marker => _marker;
    }
}
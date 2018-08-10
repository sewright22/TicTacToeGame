using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class Game
    {
        private IGameBoard _gameBoard;

        public Game(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public bool IsOver => false;
        public IGameBoard GameBoard => _gameBoard;

        public void MakeMove(int playerInput)
        {
            _gameBoard.PlaceMarker((int)playerInput, "X");
        }
    }
}

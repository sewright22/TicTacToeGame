using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class Game
    {
        private IGameBoard _gameBoard;
        private IMoveValidator _moveValidator;

        public Game(IGameBoard gameBoard, IMoveValidator moveValidator)
        {
            _gameBoard = gameBoard;
            _moveValidator = moveValidator;
        }

        public bool IsOver => _moveValidator.HasWinner(_gameBoard) || _gameBoard.IsFull();
        public IGameBoard GameBoard => _gameBoard;

        public bool MakeMove(IPlayer player, int playerInput)
        {
            var retVal = false;

            if (_moveValidator.IsMoveValid(_gameBoard, playerInput))
            {
                _gameBoard.PlaceMarker((int)playerInput, player.Marker);
                retVal = true;
            }

            return retVal;
        }
    }
}

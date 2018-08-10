using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public interface IMoveValidator
    {
        bool IsMoveValid(IGameBoard gameBoard, int input);
        bool HasWinner(IGameBoard gameBoard);
    }
}

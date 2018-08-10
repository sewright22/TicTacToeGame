using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class MoveValidator : IMoveValidator
    {
        public bool HasWinner(IGameBoard gameBoard)
        {
            var retVal = false;
            var list = new List<string>();
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(1), gameBoard.GetSpace(2), gameBoard.GetSpace(3)));
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(4), gameBoard.GetSpace(5), gameBoard.GetSpace(6)));
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(7), gameBoard.GetSpace(8), gameBoard.GetSpace(9)));
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(1), gameBoard.GetSpace(5), gameBoard.GetSpace(9)));
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(7), gameBoard.GetSpace(5), gameBoard.GetSpace(3)));
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(3), gameBoard.GetSpace(6), gameBoard.GetSpace(9)));
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(2), gameBoard.GetSpace(5), gameBoard.GetSpace(8)));
            list.Add(string.Format("{0}{1}{2}", gameBoard.GetSpace(1), gameBoard.GetSpace(4), gameBoard.GetSpace(7)));

            if(list.Contains("XXX") || list.Contains("OOO"))
            {
                retVal = true;
            }

            return retVal;
        }

        public bool IsMoveValid(IGameBoard gameBoard, int input)
        {
            var retVal = false;

            if (input > 0 && input < 10)
            {
                var curValue = gameBoard.GetSpace(input);

                if (curValue != "X" && curValue != "O")
                {
                    retVal = true;
                }
            }

            return retVal;
        }
    }
}

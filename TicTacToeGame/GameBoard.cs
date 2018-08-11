using System;
using System.Collections.Generic;

namespace TicTacToeGame
{
    public class GameBoard : IGameBoard
    {
        private Dictionary<int, string> boardAsList;

        public GameBoard()
        {
            boardAsList = new Dictionary<int, string>();
            boardAsList.TryAdd(1, "0");
            boardAsList.TryAdd(2, "0");
            boardAsList.TryAdd(3, "0");
            boardAsList.TryAdd(4, "0");
            boardAsList.TryAdd(5, "0");
            boardAsList.TryAdd(6, "0");
            boardAsList.TryAdd(7, "0");
            boardAsList.TryAdd(8, "0");
            boardAsList.TryAdd(9, "0");
        }

        public IDictionary<int, string> GetSpaces()
        {
            return boardAsList;
        }

        public bool IsFull()
        {
            var hasBlank = false;

            foreach (var space in boardAsList)
            {
                if (space.Value != "X" && space.Value != "O")
                {
                    hasBlank = true;
                }
            }

            return hasBlank==false;
        }

        public string GetSpace(int v)
        {
            return boardAsList[v];
        }

        public void PlaceMarker(int playerInput, string marker)
        {
            boardAsList[playerInput] = marker;
        }
    }
}

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
            boardAsList.TryAdd(1, "1");
            boardAsList.TryAdd(2, "2");
            boardAsList.TryAdd(3, "3");
            boardAsList.TryAdd(4, "4");
            boardAsList.TryAdd(5, "5");
            boardAsList.TryAdd(6, "6");
            boardAsList.TryAdd(7, "7");
            boardAsList.TryAdd(8, "8");
            boardAsList.TryAdd(9, "9");
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

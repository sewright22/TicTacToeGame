using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public interface IGameBoard
    {
        void PlaceMarker(int playerInput, string marker);
        IDictionary<int, string> GetSpaces();
        bool IsFull();
        string GetSpace(int v);
    }
}

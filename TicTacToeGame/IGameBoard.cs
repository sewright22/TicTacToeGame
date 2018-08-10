using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public interface IGameBoard
    {
        void PlaceMarker(int playerInput, string marker);
        string GetSpace(int v);
    }
}

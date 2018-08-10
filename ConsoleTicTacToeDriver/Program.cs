using System;
using TicTacToeGame;

namespace ConsoleTicTacToeDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter when you are ready to start.");
            Console.ReadLine();
            var game = new Game(new GameBoard());

            while (game.IsOver == false)
            {
                Console.WriteLine("Player 1 please enter your move.");
                DrawGameBoard(game);
                var playerInput = Console.ReadLine();
                game.MakeMove(Convert.ToInt32(playerInput));
            }
        }

        private static void DrawGameBoard(Game game)
        {
            Console.WriteLine(" {0} | {1} | {2} ", game.GameBoard.GetSpace(1), game.GameBoard.GetSpace(2), game.GameBoard.GetSpace(3));
            Console.WriteLine(" {0} | {1} | {2} ", game.GameBoard.GetSpace(4), game.GameBoard.GetSpace(5), game.GameBoard.GetSpace(6));
            Console.WriteLine(" {0} | {1} | {2} ", game.GameBoard.GetSpace(7), game.GameBoard.GetSpace(8), game.GameBoard.GetSpace(9));
        }
    }
}

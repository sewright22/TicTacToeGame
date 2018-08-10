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
            var gameBoard = new GameBoard();
            var moveValidator = new MoveValidator();
            var game = new Game(gameBoard, new MoveValidator());
            var playerOne = new Player("Player 1", "X");
            var playerTwo = new Player("Player 2", "O");
            IPlayer curPlayer = null;

            while (game.IsOver == false)
            {
                if (curPlayer != null && curPlayer.Name == "Player 1")
                {
                    curPlayer = playerTwo;
                }
                else
                {
                    curPlayer = playerOne;
                }

                Console.WriteLine("{0} please enter your move.", curPlayer.Name);
                DrawGameBoard(game);
                var playerInput = Console.ReadLine();
                while (game.MakeMove(curPlayer, Convert.ToInt32(playerInput)) == false)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    playerInput = Console.ReadLine();
                }
            }

            DrawGameBoard(game);

            if(moveValidator.HasWinner(gameBoard) )
            {
                Console.WriteLine("{0} Wins!!!", curPlayer.Name);

            }
            else
            {
                Console.WriteLine("{0} Wins!!!", "NOBODY");
            }
            Console.ReadLine();
        }

        private static void DrawGameBoard(Game game)
        {
            Console.WriteLine(" {0} | {1} | {2} ", game.GameBoard.GetSpace(1), game.GameBoard.GetSpace(2), game.GameBoard.GetSpace(3));
            Console.WriteLine("-----------------");
            Console.WriteLine(" {0} | {1} | {2} ", game.GameBoard.GetSpace(4), game.GameBoard.GetSpace(5), game.GameBoard.GetSpace(6));
            Console.WriteLine("-----------------");
            Console.WriteLine(" {0} | {1} | {2} ", game.GameBoard.GetSpace(7), game.GameBoard.GetSpace(8), game.GameBoard.GetSpace(9));
        }
    }
}

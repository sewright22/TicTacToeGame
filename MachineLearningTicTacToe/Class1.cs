using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using System;
using System.IO;
using TicTacToeGame;

namespace MachineLearningTicTacToe
{
    public class Class1
    {
        public void SOMLearning()
        {
            var turnNumber = 1;
            var random = new Random();
            var playCount = 0;
            var player1Wins = 0;
            var player2Wins = 0;
            var ties = 0;
            var gameBoard = new GameBoard();
            var moveValidator = new MoveValidator();
            var game = new Game(gameBoard, moveValidator);
            var playerOne = new Player("Player 1", "X");
            var playerTwo = new Player("Player 2", "O");
            IPlayer curPlayer = null;
            TicTacToeLearning currentTrainer = null;
            TicTacToeNetwork network1 = new TicTacToeNetwork(10, 9); 

            TicTacToeNetwork network2 = new TicTacToeNetwork(10, 9); 
            //DistanceNetwork

            //network1.Output = output;

            // create learning algorithm
            TicTacToeLearning trainer1 = new TicTacToeLearning(network1);
            TicTacToeLearning trainer2 = new RandomTicTacToeLearning(network2);
            //TicTacToeLearning trainer2 = new TicTacToeLearning(network2);
            //// network's input
            double[] input = new double[10];
            // loop
            while (playCount<100000)
            {
                if (curPlayer == null)
                {
                    var goesFirst = random.Next(1, 3);

                    if (goesFirst == 1)
                    {
                        curPlayer = playerOne;
                        currentTrainer = trainer1;
                    }
                    else
                    {
                        curPlayer = playerTwo;
                        currentTrainer = trainer2;
                    }
                }
                else if (curPlayer.Name == "Player 1")
                {
                    curPlayer = playerTwo;
                    currentTrainer = trainer2;
                }
                else
                {
                    curPlayer = playerOne;
                    currentTrainer = trainer1;
                }

                input = ConvertGameBoard(turnNumber, game);

                var playerInput = currentTrainer.Run(input);

                while (game.MakeMove(curPlayer, Convert.ToInt32(playerInput)) == false)
                {
                    //currentTrainer.AddPoints(-1);
                    playerInput = currentTrainer.Run(input);
                }

                //currentTrainer.AddMove(playerInput, turnNumber);
                turnNumber++;
                if (game.IsOver)
                {
                    if (moveValidator.HasWinner(gameBoard))
                    {
                        input = ConvertGameBoard(turnNumber, game);
                        if (curPlayer.Name == "Player 1")
                        {
                            player1Wins++;
                            trainer1.AddResult(1, input);
                            trainer2.AddResult(-1, input);
                        }
                        else
                        {
                            player2Wins++;
                            trainer1.AddResult(-1, input);
                            trainer2.AddResult(1, input);
                        }
                    }
                    else
                    {
                        ties++;
                        trainer1.AddResult(0, input);
                        trainer2.AddResult(0, input);
                    }

                    turnNumber = 1;
                    gameBoard = new GameBoard();
                    moveValidator = new MoveValidator();
                    game = new Game(gameBoard, moveValidator);
                    curPlayer = null;
                    playCount++;
                }
            }

            Console.WriteLine(string.Format("Player 1: {0}", player1Wins));
            Console.WriteLine(string.Format("Player 2: {0}", player2Wins));
            Console.WriteLine(string.Format("Cats: {0}", ties));
        }

        private static double[] ConvertGameBoard(int turnNumber, Game game)
        {
            var space1 = game.GameBoard.GetSpace(1);
            var space2 = game.GameBoard.GetSpace(2);
            var space3 = game.GameBoard.GetSpace(3);
            var space4 = game.GameBoard.GetSpace(4);
            var space5 = game.GameBoard.GetSpace(5);
            var space6 = game.GameBoard.GetSpace(6);
            var space7 = game.GameBoard.GetSpace(7);
            var space8 = game.GameBoard.GetSpace(8);
            var space9 = game.GameBoard.GetSpace(9);

            double[] input = new double[10];
            input[0] = turnNumber;
            input[1] = space1 == "X" ? 1 : space1 == "O" ? 2 : Convert.ToDouble(space1);
            input[2] = space2 == "X" ? 1 : space2 == "O" ? 2 : Convert.ToDouble(space2);
            input[3] = space3 == "X" ? 1 : space3 == "O" ? 2 : Convert.ToDouble(space3);
            input[4] = space4 == "X" ? 1 : space4 == "O" ? 2 : Convert.ToDouble(space4);
            input[5] = space5 == "X" ? 1 : space5 == "O" ? 2 : Convert.ToDouble(space5);
            input[6] = space6 == "X" ? 1 : space6 == "O" ? 2 : Convert.ToDouble(space6);
            input[7] = space7 == "X" ? 1 : space7 == "O" ? 2 : Convert.ToDouble(space7);
            input[8] = space8 == "X" ? 1 : space8 == "O" ? 2 : Convert.ToDouble(space8);
            input[9] = space9 == "X" ? 1 : space9 == "O" ? 2 : Convert.ToDouble(space9);

            return input;
        }

        public void BackLearning()
        {
            double[][] input = new double[1][]
            {
                new double[] {0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            double[][] output = new double[4][]
            {
                new double[] {0}, new double[] {1},
                new double[] {1}, new double[] {0}
            };

            ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(2),
                                                              9, // two inputs in the network
                                                              2, // two neurons in the first layer
                                                              1); // one neuron in the second layer
            //DistanceNetwork
            // create teacher
            BackPropagationLearning teacher = new BackPropagationLearning(network);

            var needToStop = false;
            while (!needToStop)
            {
                // run epoch of learning procedure
                //double error = teacher.RunEpoch(input, output);
                // check error value to see if we need to stop
                // ...
            }
        }

        public void TensorFlow()
        {
            //var ten = new TensorFlow.
        }
    }
}

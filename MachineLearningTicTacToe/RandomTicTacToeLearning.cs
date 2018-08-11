using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearningTicTacToe
{
    public class RandomTicTacToeLearning : TicTacToeLearning
    {
        private Random random;

        public RandomTicTacToeLearning(TicTacToeNetwork network) : base(network)
        {
            random = new Random();
        }

        public override double Run(double[] input)
        {
            return random.Next(1, 10);
        }
    }
}

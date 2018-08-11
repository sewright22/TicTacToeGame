using AForge;
using AForge.Neuro;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearningTicTacToe
{
    public class TicTacToeNeuron : Neuron
    {
        private int _inputs;
        private int _index;
        private int gamesPlayedCount;
        private int gamesWonCount;
        private int gamesLostCount;
        private int gamesTiedCount;
        private Dictionary<int, int> turnHistory;
        private int timesSelected;

        public TicTacToeNeuron(int inputs, int index) : base(inputs)
        {
            RandRange = new Range(0, 1);
            turnHistory = new Dictionary<int, int>();
            _inputs = inputs;
            _index = index;
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = (double)1 / _inputs;
            }
        }

        public void AddResult(int point)
        {
            gamesPlayedCount++;

            if(point==-1)
            {
                gamesLostCount++;
            }
            else if(point==0)
            {
                gamesTiedCount++;
            }
            else
            {
                gamesWonCount++;
            }
        }

        public void AddMove(int move)
        {
            timesSelected++;
        }

        public override double Compute(double[] input)
        {
            if(input[0]!= _index)
            {
                return 0;
            }
            if (gamesPlayedCount > 0)
            {
                var percentageOfWins = (double)gamesWonCount / gamesPlayedCount;
                var percentageOfLosses = (1 - ((double)gamesLostCount / gamesPlayedCount));
                var percentageOfTies = (double)gamesTiedCount / gamesPlayedCount;

                return (double)input[_index] / (Math.Max(percentageOfWins, Math.Max(percentageOfTies, percentageOfLosses)));
            }
            else
            {
                return (double)1 / 9;
            }
        }
    }
}

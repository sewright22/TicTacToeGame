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
        private double biasWeight;

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
            biasWeight = RandGenerator.NextDouble();
            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = RandGenerator.NextDouble();
            }
        }

        public void AddResult(int point, double[] input)
        {
            gamesPlayedCount++;
            var sig = new SigmoidFunction();
            var result = 0;
            if(point==-1)
            {
                gamesLostCount++;
            }
            else if(point==0)
            {
                gamesTiedCount++;
                result = 1;
            }
            else
            {
                result = 2;
                gamesWonCount++;
            }

            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] += sig.Derivative(Weights[i]) * (result - Weights[i]);
            }

            biasWeight += sig.Derivative(biasWeight) * (biasWeight);
        }

        public void AddMove(int move)
        {
            //timesSelected++;
        }

        public override double Compute(double[] input)
        {
            if(_index==0)
            {
                return 0;
            }
            else
            {
                var sigmoid = new SigmoidFunction();

                return sigmoid.Function(weights[1] * input[1] +
                                        weights[2] * input[2] +
                                        weights[3] * input[3] +
                                        weights[4] * input[4] +
                                        weights[5] * input[5] +
                                        weights[6] * input[6] +
                                        weights[7] * input[7] +
                                        weights[8] * input[8] +
                                        weights[9] * input[9] + biasWeight);
            }
        }
    }
}

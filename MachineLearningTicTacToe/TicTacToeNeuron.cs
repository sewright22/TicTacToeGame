using AForge;
using AForge.Neuro;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearningTicTacToe
{
    public class TicTacToeNeuron : Neuron
    {
        private double prevValue;
        private int _inputs;
        private int _index;
        private List<double[]> turnHistory;

        public TicTacToeNeuron(int inputs, int index) : base(inputs)
        {
            RandRange = new Range(0, 1);
            turnHistory = new List<double[]>();
            _inputs = inputs;
            _index = index;
            Initialize();
            prevValue = RandGenerator.NextDouble();
        }

        private void Initialize()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = (double)1 / _inputs;
            }
        }

        public void AddPoints(int point)
        {
            for(int i=0;i<weights.Length;i++)
            {
                if (point == -1)
                {
                    Weights[i] = RandGenerator.NextDouble();
                }
            }
        }

        public void AddMove(double move)
        {
        }

        public override double Compute(double[] input)
        {
            var runningTotal = (double)0;
            var total = (double)0;

            for (int i = 0; i < input.Length; i++)
            {
                total += Weights[i];
                foreach (var array in winningHistory)
                {
                    if (array[i] == 1)
                    {
                        total += array[i];
                    }
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                runningTotal += (input[i] + Weights[i]) / 2;
            }

            return runningTotal / _inputs;
        }
    }
}

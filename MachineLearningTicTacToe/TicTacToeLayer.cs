using AForge.Neuro;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearningTicTacToe
{
    public class TicTacToeLayer : Layer
    {
        public TicTacToeLayer(int neuronsCount, int inputsCount) : base(neuronsCount, inputsCount)
        {
            for (int i = 0; i < neuronsCount; i++)
            {
                Neurons[i] = new TicTacToeNeuron(inputsCount, i);
            }
        }

        public void AddPoints(int point)
        {
            //for (int i = 0; i < neuronsCount; i++)
            //{
            //    var neuron = Neurons[i] as TicTacToeNeuron;
            //    neuron.AddPoints(point);
            //}
        }

        internal void AddResult(int v, double[] input)
        {
            for (int i = 0; i < neuronsCount; i++)
            {
                var neuron = Neurons[i] as TicTacToeNeuron;
                neuron.AddResult(v, input);
            }
        }
    }
}

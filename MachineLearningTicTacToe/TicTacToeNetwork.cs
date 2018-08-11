using AForge.Neuro;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearningTicTacToe
{
    public class TicTacToeNetwork : Network
    {
        public TicTacToeNetwork(int inputsCount, int layersCount, int outputCount = 9) : base(inputsCount, layersCount)
        {
            for (int i = 0; i < layersCount; i++)
            {
                Layers[i] = new TicTacToeLayer(outputCount, inputsCount);
            }
        }

        public void AddPoints(int points)
        {
            for (int i = 0; i < layersCount; i++)
            {
                var layer = Layers[i] as TicTacToeLayer;
                layer.AddPoints(points);
            }
        }

        internal void AddMove(double playerInput, int turnNumber)
        {
            (Layers[turnNumber - 1].Neurons[(int)playerInput - 1] as TicTacToeNeuron).AddMove((int)playerInput);
        }

        internal void AddResult(int v)
        {
            for (int i = 0; i < layersCount; i++)
            {
                var layer = Layers[i] as TicTacToeLayer;
                layer.AddResult(v);
            }
        }
    }
}

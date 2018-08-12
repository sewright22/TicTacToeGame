using AForge.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearningTicTacToe
{
    public class TicTacToeLearning : IUnsupervisedLearning
    {
        private TicTacToeNetwork _network;
        private int _turnNumber;

        public TicTacToeLearning(TicTacToeNetwork network)
        {
            _network = network;
        }

        public void AddPoints(int point)
        {
            _network.AddPoints(point);
        }

        public virtual double Run(double[] input)
        {
            var retVal = 0;
            var outputs = _network.Compute(input);
            var max = (double)-1;

            //for(int i=1;i<outputs.Len)

            while (retVal == 0)
            {
                for (int i = 1; i < outputs.Length; i++)
                {
                    if (outputs[i] > max)
                    {
                        max = outputs[i];
                        retVal = i;
                    }
                }

                if(input[retVal]!=0)
                {
                    outputs[retVal] = -1;
                    retVal = 0;
                    max = -1;
                }
            }

            return retVal;
        }

        public double RunEpoch(double[][] input)
        {
            throw new NotImplementedException();
        }

        internal void AddMove(double playerInput, int turnNumber)
        {
            _network.AddMove(playerInput, turnNumber);
        }

        internal void AddResult(int v, double[] input)
        {
            _network.AddResult(v, input);
        }
    }
}

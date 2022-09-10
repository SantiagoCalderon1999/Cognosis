
using Cognosis.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cognosis.Algorithms.Kohonen
{
    /// <summary>
    /// Creates a Self-Organized Map, also called Kohonen Network
    /// </summary>
    public class ModelKohonen
    {

        private List<List<double>> _weights;
        public List<List<double>> Weights
        {
            get
            {
                return _weights;
            }

        }
        private List<List<double>> _input;
        private double _sigma0;
        private int _numberOfWeights;

        /// <summary>
        /// No args constructor
        /// </summary>
        public ModelKohonen()
        {
            
        }

        /// <summary>
        /// Constructor including input, sigma0 and number of weights
        /// </summary>
        /// <param name="input">Input of the network</param>
        /// <param name="sigma0">Initial value of sigma</param>
        /// <param name="numberOfWeights">Number of weights that are going to be used in the neural network</param>
        public ModelKohonen(List<List<double>> input, double sigma0, int numberOfWeights)
        {
            this._input = input;
            this._sigma0 = sigma0;
            this._numberOfWeights = numberOfWeights;
            double minimumInput = input.Select(list => list.Min()).Min();
            double maximumInput = input.Select(list => list.Max()).Max();
            int dimensionOfInput = input[0].Count;
            this._weights = InitializeWeights(minimumInput, maximumInput, numberOfWeights, dimensionOfInput);
        }

        /// <summary>
        /// Trains the model created in the class
        /// </summary>
        /// <param name="iterations">Number of iterations</param>
        public void Train(int iterations)
        {
            for (int currentIteration = 0; currentIteration < iterations; currentIteration++)
            {
               _weights = Step(currentIteration);
            }
        }

        /// <summary>
        /// Executes an iteration in the neural network
        /// </summary>
        /// <param name="iteration">Number of iteration</param>
        /// <returns>List of updated weights</returns>
        public List<List<double>> Step(int iteration)
        {
            int currentInputIndex = iteration % _input.Count;
            List<double> currentInputCoordinates = _input[currentInputIndex];

            // Get the distance from each weight to the current input
            List<double> geometricDistances = _weights.Select(weightCoordinates =>
                MathFunctions.ComputeEuclideanDistance(weightCoordinates, currentInputCoordinates)).ToList();

            // Get the index of the minimum distance from one weight to the current input
            double minimumDistance = geometricDistances.Min();
            int indexMinimumDistance = geometricDistances.FindIndex(distance => distance == minimumDistance);

            // Compute scalar gain function
            double sigma = MathFunctions.GetScalarGainFunction(_sigma0, iteration);

            // Update weights based on Topological neighbourhood
            return UpdateTopologicalNeighbourhood(indexMinimumDistance, sigma, currentInputCoordinates);
        }

        /// <summary>
        /// Creates a List contanining the coordinates of the weights. It is initialized randomly given a minimum and a maximum
        /// </summary>
        /// <param name="minimum">Minimum weight value</param>
        /// <param name="maximum">Maximum weight value</param>
        /// <param name="numberOfWeights">Number of weights</param>
        /// <param name="dimensionOfEachWeight">Dimension of each weight</param>
        /// <returns>Returns a list of lists containing double value</returns>
        public List<List<double>> InitializeWeights(double minimum, double maximum, int numberOfWeights, int dimensionOfEachWeight)
        {
            Random random = new Random();
            List<List<double>> initializedWeights = new List<List<double>>();
            for (int i = 0; i < numberOfWeights; i++)
            {
                List<double> auxiliarList = new List<double>();
                for (int j = 0; j < dimensionOfEachWeight; j++)
                {
                    double randomValue = random.NextDouble();
                    double scaledRandomValue = MathFunctions.ScaleLinearFunction(minimum, maximum, randomValue);
                    auxiliarList.Add(scaledRandomValue);
                }
                initializedWeights.Add(auxiliarList);
            }
            return initializedWeights;
        }

        /// <summary>
        /// Applies an exponential function to make the topological neighbourhood of the minimum value closer to that point
        /// </summary>
        /// <param name="minimumIndex">Index of the value with the minimum distance</param>
        /// <param name="sigma">Sigma value obtained from the Scalar Gain Function</param>
        /// <param name="currentInputCoordinates">Coordinates of the input in the current iteration</param>
        /// <returns>List of weights updated with the topological neghbourhood function</returns>
        private List<List<double>> UpdateTopologicalNeighbourhood(int minimumIndex, double sigma, List<double> currentInputCoordinates)
        {
            List<List<double>> updatedWeights = new List<List<double>>();
            foreach (List<double> weightCoordinates in _weights)
            {
                int currentIndex = _weights.FindIndex(weight => weight == weightCoordinates);
                List<double> updatedIndividualWeight = weightCoordinates.Zip(currentInputCoordinates, (individualWeight, individualInput) =>
                {
                    double hk = MathFunctions.GetTopologicalNeighbourhood(1, (minimumIndex - currentIndex), sigma);
                    return hk * hk * (individualInput - individualWeight) + individualWeight;
                }
                ).ToList();
                updatedWeights.Add(updatedIndividualWeight);
            }
            return updatedWeights;
        }

    }
}

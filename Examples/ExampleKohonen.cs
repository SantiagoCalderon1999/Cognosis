using System;
using System.Collections.Generic;
using Cognosis.ModelKohonen;

namespace Examples
{
    class ExampleKohonen
    {
        /// <summary>
        /// This example solves the Travelling Salesman Problem for a list of 5 cities, though it can be extended for any desired number of cities
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create input List
            List<double> coordinate1 = new List<double>() { 0, 0 };
            List<double> coordinate2 = new List<double>() { 1, 2 };
            List<double> coordinate3 = new List<double>() { 3, 4 };
            List<double> coordinate4 = new List<double>() { 5, 5 };
            List<double> coordinate5 = new List<double>() { 8, 9 };
            List<List<double>> input = new List<List<double>>()
            {
                coordinate1,
                coordinate2,
                coordinate3,
                coordinate4,
                coordinate5
            };

            // Set parameters
            double sigma0 = 10;
            int iterations = 3000;
            int numberOfWeights = 20;

            // Create model
            ModelKohonen kohonen = new ModelKohonen(input, sigma0, numberOfWeights);
            
            // Train model
            kohonen.Train(iterations);

            // Get weights of the trained network
            List<List<double>> weights = kohonen.Weights;

            // Show weights in console
            weights.ForEach(weight => 
            {
                weight.ForEach(individualWeight =>
                    Console.Write(individualWeight + "-")
                );
                Console.WriteLine();
            });
        }
    }
}

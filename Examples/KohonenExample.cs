using Cognosis.SOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examplessss
{
    public class KohonenExample
    {
        /// <summary>
        /// Example of Kohonen creation
        /// </summary>
        public void CreateKohonen()
        {
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
            double sigma0 = 10;
            ModelKohonen kohonen = new ModelKohonen(input, sigma0, 10);
            int iterations = 100;
            kohonen.Train(iterations);
            List<List<double>> weights = new List<List<double>>();
            weights = kohonen.Weights;
            Console.WriteLine(weights.ToString());
        }
    }
}

using Cognosis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognosis.Utility
{
    public static class MathFunctions
    {
        /// <summary>
        /// Computes the value of the topological neighbourhood function for a given distance
        /// This function is referred as h(k) in the original paper
        /// </summary>
        /// <param name="h0">Constant which multiplies the function</param>
        /// <param name="distance">Distance between the points which are being analyzed with the Topological Neighbourhood function></param>
        /// <param name="sigma"> Current value of a function decreasing over time</param>
        /// <returns>A double containing the value of the function</returns>
        public static double GetTopologicalNeighbourhood(double h0, double distance, double sigma)
        {
            return h0 * Math.Exp(- distance * distance / (2 * sigma * sigma));
        }

        internal static double ScaleLinearFunction(double randomValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the value of the Scalar Gain Function, which is a function that decreases over time
        /// </summary>
        /// <param name="sigma0">First value of the scalar gain function</param>
        /// <param name="iteration">Value of the current interation</param>
        /// <returns>Double with the result of the Sclar Gain function</returns>
        public static double GetScalarGainFunction(double sigma0, int iteration)
        {
           double t1 = GetPeriodConstant(sigma0);
           return sigma0 * Math.Exp(- (double) iteration / t1);
        }

        /// <summary>
        /// Computes a constant used to change how fast the Scalar Gain Function will decrease
        /// It is arbitrarily defined by the function 1000/log(sigma0)
        /// </summary>
        /// <param name="sigma0">First value of the Scalar Gain Function</param>
        /// <returns>Double with the value of the Period constant, often referred as t1 as well</returns>
        public static double GetPeriodConstant(double sigma0)
        {
            return 1000 / Math.Log10(sigma0);
        }

        /// <summary>
        /// Computes Euclidean distance of two points whose coordinates are given by lists
        /// </summary>
        /// <param name="coordinate1">Coordinates of the first point</param>
        /// <param name="coordinate2">Coordinates of the second point</param>
        /// <returns>Distance between both points</returns>
        public static double ComputeEuclideanDistance(List<double> coordinate1, List<double> coordinate2)
        {
            if (coordinate1.Count != coordinate2.Count)
                throw new InvalidMathParameterException("The dimensions of both lists must match");
            IEnumerable<double> acumulatedValues = coordinate1.Zip(coordinate2, (number1, number2) =>
                (number2 - number1) * (number2 - number1)
            );
            return Math.Sqrt(acumulatedValues.Sum());
        }

        /// <summary>
        /// Scales a number betweeon 0 and 1 to a range defined by a minimum and a maximum. This function uses a linear function of the form y = m * x + b
        /// </summary>
        /// <param name="minimum">Maximum value in the scaling range</param>
        /// <param name="maximum">Minimum value in the scaling range</param>
        /// <param name="x">Value to be scaled</param>
        /// <returns>Value scaled</returns>
        public static double ScaleLinearFunction(double minimum, double maximum, double x)
        {
            double m = (maximum - minimum);
            double b = (minimum);
            return m * x + b; 
        }
    }
}

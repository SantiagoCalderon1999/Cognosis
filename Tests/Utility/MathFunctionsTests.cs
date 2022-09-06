using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cognosis.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognosis.Exceptions;

namespace Cognosis.Utility.Tests
{
    [TestClass()]
    public class MathFunctionsTests
    {
        [TestMethod()]
        public void GetTopologicalNeighbourhoodTest()
        {
            // Given
            double h0 = 20;
            double distance = 40;
            double sigma = 10;
            double expected = 20 / Math.Exp(8);  // Testing values were chosed to throw this  result

            // When
            double result = MathFunctions.GetTopologicalNeighbourhood(h0, distance, sigma);

            // Then
            Assert.AreEqual(expected, result, 1e-10 * Math.Abs(expected)); // Delta is directly proportional to the expected value
        }

        [TestMethod()]
        public void GetScalarGainFunctionTest()
        {
            // Given
            double sigma0 = 100;
            int iteration = 1000;
            double expected = 100 / Math.Exp(2); // Testing values were chosed to throw this particular result


            // When
            double result = MathFunctions.GetScalarGainFunction(sigma0, iteration);

            // Then
            Assert.AreEqual(expected, result, 1e-10 * Math.Abs(expected)); // Delta is directly proportional to the expected value
        }

        [TestMethod()]
        public void GetPeriodConstantTest()
        {
            // Given
            double sigma0 = 100;
            double expected = 500; // Testing values were chosed to throw this particular result

            // When
            double result = MathFunctions.GetPeriodConstant(sigma0);

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void CalculateDistanceTest()
        {
            // Given
            List<double> coordinate1 = new List<double>()
            {
                0,
                0,
                1
            };
            List<double> coordinate2 = new List<double>()
            {
                3,
                4,
                1
            };
            double expected = 5;

            // When
            double result = MathFunctions.ComputeEuclideanDistance(coordinate1, coordinate2);

            // Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidMathParameterException))]
        public void CalculateDistanceInvalidSizeTest()
        {
            // Given
            List<double> coordinate1 = new List<double>()
            {
                0,
                0,
                1
            };
            List<double> coordinate2 = new List<double>()
            {
                3,
                4
            };

            // When
            double result = MathFunctions.ComputeEuclideanDistance(coordinate1, coordinate2);

            // Then
            // InvalidMathParameterException should be thrown
        }

        [TestMethod()]
        public void ScaleLinearFunction()
        {
            // Given
            double minimum = 21.8;
            double maximum = 65.3;
            double input1 = 0;
            double input2 = 1;

            //  When
            double result1 = MathFunctions.ScaleLinearFunction(minimum, maximum, input1);
            double result2 = MathFunctions.ScaleLinearFunction(minimum, maximum, input2);

            // Then
            Assert.AreEqual(minimum, result1);
            Assert.AreEqual(maximum, result2);

        }
    }
}
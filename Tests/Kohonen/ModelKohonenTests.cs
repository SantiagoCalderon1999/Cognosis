using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cognosis.ModelKohonen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Cognosis.ModelKohonen.Tests
{
    [TestClass()]
    public class ModelKohonenTests
    {
        ModelKohonen SOM;
        List<List<double>> inputTest;
        int numberOfWeights;

        [TestInitialize]
        public void InitializeTest()
        {
            // Create input List
            List<double> coordinate1 = new List<double>() { 0, 0 };
            List<double> coordinate2 = new List<double>() { 1, 2 };
            inputTest = new List<List<double>>() { coordinate1, coordinate2 };

            // Set parameters
            double sigma0 = 10;
            numberOfWeights = 20;

            // Create model
            SOM = new ModelKohonen(inputTest, sigma0, numberOfWeights);
        }

        [TestMethod()]
        public void InitializeWeightsTest()
        {
            // Given
            double minimum = 30;
            double maximum = 150;
            int dimensionOfEachWeight = 3;

            // When
            List<List<double>> resultList = SOM.InitializeWeights(minimum,
                                                                    maximum,
                                                                    numberOfWeights,
                                                                    dimensionOfEachWeight);

            // Then
            Assert.AreEqual(numberOfWeights,resultList.Count);
            Assert.AreEqual(dimensionOfEachWeight, resultList[0].Count);
            double minimumResult = resultList.Select(list => list.Min()).Min();
            double maximumResult = resultList.Select(list => list.Max()).Max();
            Assert.IsTrue(minimum <= minimumResult);
            Assert.IsTrue(maximum >= maximumResult);
        }

        [TestMethod()]
        public void StepTest()
        {
            // Given
            int testingIteration = 100;

            // When
            List<List<double>>  resultList = SOM.Step(testingIteration);

            // Then
            Assert.AreEqual(numberOfWeights, resultList.Count);
            Assert.AreEqual(inputTest[0].Count, resultList[0].Count);
        }
    }
}
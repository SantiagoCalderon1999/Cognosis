using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cognosis.SOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognosis.SOM.Tests
{
    [TestClass()]
    public class ModelKohonenTests
    {

        [TestMethod()]
        public void InitializeWeightsTest()
        {
            // Given
            double minimum = 30;
            double maximum = 150;
            int numberOfWeights = 10;
            int dimensionOfEachWeight = 3;

            // When
            ModelKohonen SOM = new ModelKohonen();
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
    }
}
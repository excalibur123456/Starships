using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculations
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GetNumberofStops()
        {
            // arrange  
            var consumables = "2 years";
            var planetDistance = 1000000;
            var mglt = 40;
            var expected = 1;

            // act  
            var actual = StarShips.Calculation.GetNumberofStops(consumables, planetDistance, mglt);

            // assert  
            Assert.AreEqual(expected, actual, "Incorrect number of stops required.");
        }

        [TestMethod]
        public void Test_GetByConsumables()
        {
            // arrange  
            var consumables = "10 years";
            var expected = StarShips.TimeUnit.year;

            // act  
            var actual = StarShips.Calculation.GetByConsumables(consumables);

            // assert  
            Assert.AreEqual(expected, actual, "Incorrect time unit.");
        }
    }
}

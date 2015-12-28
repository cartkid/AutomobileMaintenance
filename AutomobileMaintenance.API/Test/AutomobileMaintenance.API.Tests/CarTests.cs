using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomobileMaintenance.API.Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void GetAllCars()
        {
            var cars = Models.Car.GetAllCars();
            Assert.AreEqual(1, cars.Count);
        }
    }
}

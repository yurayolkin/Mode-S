using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeS.Data;

namespace ModeS.Test
{
    [TestClass]
    public class DataLayer
    {
        [TestMethod]
        public void ConnectionDateBaseWithParameters()
        {
            var result = new DataBase().GetFlights(new DateTime(2014, 04, 28), new DateTime(2014, 04, 28),
                "United States", "C-17A", "97-0042", "USAF | 62AW [KTCM]");
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GetSerial()
        {
            var result = new DataBase().GetSerials("C-17A");
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GerAircraft()
        {
            var result = new DataBase().GetAirCraftList();
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GerOperator()
        {
            var result = new DataBase().GetOperators();
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GetCountries()
        {
            var result = new DataBase().GetCountriList();
            Assert.AreNotEqual(null, result);
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GetCoordinateFromCityName()
        {
            var cityName = "Naaldwijk, NL";
            var result = new DataBase().GetCoordination(cityName);
            Assert.AreNotEqual(result.Lat, 0);
            Assert.AreNotEqual(result.Lng, 0);
        }

        [TestMethod]
        public void GetCoordinateTest()
        {
            var cityName = "Kiev, UA";
            var result = new DataBase().GetCoordination(cityName);
            Assert.AreNotEqual(result.Lat, 0);
            Assert.AreNotEqual(result.Lng, 0);
            Assert.AreEqual(30, Math.Round(result.Lat));
            Assert.AreEqual(50, Math.Round(result.Lng));
        }
    }
}

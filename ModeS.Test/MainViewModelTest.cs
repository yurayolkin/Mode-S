using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeS.ViewModel;

namespace ModeS.Test
{
    [TestClass]
    public class MainViewModelTest
    {
        [TestMethod]
        public void AircraftListTest()
        {
            var data = new DataLayerMock();
            var aircraftList = data.GetAirCraftList();
            var mainview = new MainViewModel(data);
            CollectionAssert.AreEqual(aircraftList, mainview.AirCrafts);
        }

        [TestMethod]
        public void CountryListTest()
        {
            var data = new DataLayerMock();
            var countries = data.GetCountriList();
            var mainView = new MainViewModel(data);
            CollectionAssert.AreEqual(countries, mainView.Countries);
        }

        [TestMethod]
        public void OperatorListTest()
        {
            var data = new DataLayerMock();
            var oper = data.GetOperators();
            var mainView = new MainViewModel(data);
            CollectionAssert.AreEqual(oper, mainView.Operators);
        }
    }
}

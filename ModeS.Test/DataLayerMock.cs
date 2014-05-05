using System;
using System.Collections.Generic;
using ModeS.Data;

namespace ModeS.Test
{
    /// <summary>
    /// Mock object for testing.
    /// </summary>
    public class DataLayerMock : IData
    {
        public List<string> GetCountriList()
        {
            var result = new List<string>(100);
            for (var index = 0; index < 100; index++)
            {
                result.Add(index.ToString());
            }

            return result;
        }

        public List<string> GetAirCraftList()
        {
            var result = new List<string>(100);
            for (var index = 0; index < 100; index++)
            {
                result.Add(index.ToString());
            }

            return result;
        }

        public List<string> GetOperators()
        {
            var result = new List<string>(100);
            for (var index = 0; index < 100; index++)
            {
                result.Add(index.ToString());
            }

            return result;
        }

        public List<string> GetSerials(string aircraftType)
        {
            var result = new List<string>(100);
            for (var index = 0; index < 100; index++)
            {
                result.Add(index.ToString());
            }

            return result;
        }

        public List<Flight> GetFlights(DateTime dateS, DateTime dateE, string country, string aircraft, string serial, string oper)
        {
            var result = new List<Flight>(10);
            for (var index = 0; index < 10; index++)
            {
                result.Add(new Flight() {CallSign = index.ToString(), Country = index.ToString(), Gmt = DateTime.Now, Location = index.ToString(), Operator = index.ToString(), Serial = index.ToString(), Type = index.ToString()});
            }

            return result;
        }
    }
}
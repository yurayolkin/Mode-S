using System;
using System.Collections.Generic;

namespace ModeS.Data
{
    public interface IData
    {
        List<string> GetCountriList();
        List<string> GetAirCraftList();
        List<string> GetOperators();
        List<string> GetSerials(string aircraftType);
        List<Flight> GetFlights(DateTime dateS, DateTime dateE, string country, string aircraft, string serial, string oper);
    }
}
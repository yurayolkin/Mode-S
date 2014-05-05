using System;
using System.Collections.Generic;
using System.Text;
using ModeS.Data.Helpers;
using MySql.Data.MySqlClient;

namespace ModeS.Data
{
    public sealed class DataBase : IData
    {

        private readonly MySqlConnectionStringBuilder _connection;

        public DataBase()
        {
            _connection = new MySqlConnectionStringBuilder
            {
                Server = "85.25.235.202",
                UserID = "SBSRemoteNET5",
                Password = "SBSRemoteNET5",
                Database = "modes",
                Pooling = true,
                MinimumPoolSize = 0,
                MaximumPoolSize = 10
            };
        }

        public List<string> GetCountriList()
        {
            var result = new List<string>();
            using (var dataCoonection = new MySqlConnection(_connection.ToString()))
            {
                dataCoonection.Open();
                var sqlCommand = new MySqlCommand("SELECT * FROM Country", dataCoonection);
                var dataResult = sqlCommand.ExecuteReader();

                while (dataResult.Read())
                {
                    result.Add(dataResult.GetString(0));
                }
            }

            return result;
        }

        public List<string> GetAirCraftList()
        {
            var result = new List<string>();
            using (var dataCoonection = new MySqlConnection(_connection.ToString()))
            {
                dataCoonection.Open();
                var sqlCommand = new MySqlCommand("SELECT * FROM type", dataCoonection);
                var dataResult = sqlCommand.ExecuteReader();

                while (dataResult.Read())
                {
                    result.Add(dataResult.GetString(0));
                }

            }

            return result;
        }

        public List<string> GetOperators()
        {
            var result = new List<string>();
            using (var dataCoonection = new MySqlConnection(_connection.ToString()))
            {
                dataCoonection.Open();
                var sqlCommand = new MySqlCommand("SELECT * FROM Operator", dataCoonection);
                var dataResult = sqlCommand.ExecuteReader();

                while (dataResult.Read())
                {
                    result.Add(dataResult.GetString(0));
                }

            }

            return result;
        }

        public List<string> GetSerials(string aircraftType)
        {
            var result = new List<string>();
            using (var dataCoonection = new MySqlConnection(_connection.ToString()))
            {
                dataCoonection.Open();
                var sqlCommand = new MySqlCommand(string.Format("SELECT DISTINCT serial FROM AlertSResults WHERE type = '{0}' ORDER BY serial", aircraftType), dataCoonection);
                var dataResult = sqlCommand.ExecuteReader();

                while (dataResult.Read())
                {
                    result.Add(dataResult.GetString(0));
                }
            }

            return result;            
        }

        public List<Flight> GetFlights(DateTime dateS, DateTime dateE, string country, string aircraft, string serial, string oper)
        {
            var sqlRequest = new StringBuilder();
            sqlRequest.Append("SELECT  * FROM AlertSResults ");
            sqlRequest.Append(string.Format("WHERE Date >= '{0}' AND Date <= '{1}'", dateS.SqlDate(), dateE.SqlDate()));

            if (!string.IsNullOrEmpty(country))
            {
                sqlRequest.AppendFormat(" AND Country = '{0}'", country);
            }

            if (!string.IsNullOrEmpty(aircraft))
            {
                sqlRequest.AppendFormat(" AND type = '{0}'", aircraft);
            }

            if (!string.IsNullOrEmpty(serial))
            {
                sqlRequest.AppendFormat(" AND serial = '{0}'", serial);
            }

            if (!string.IsNullOrEmpty(oper))
            {
                sqlRequest.AppendFormat(" AND Operator = '{0}'", oper);
            }
            
            var result = new List<Flight>();
            using (var dataConnection = new MySqlConnection(_connection.ToString()))
            {
                dataConnection.Open();
                var sqlCommand = new MySqlCommand(sqlRequest.ToString(), dataConnection);
                var dataResult = sqlCommand.ExecuteReader();

                while (dataResult.Read())
                {
                    var fligth = new Flight
                    {
                        Serial = dataResult.GetString(14),
                        CallSign = dataResult.GetString(11),
                        Country = dataResult.GetString(13),
                        Operator = dataResult.GetString(15),
                        Type = dataResult.GetString(12),
                        Gmt = dataResult.GetDateTime(5),
                        Location = dataResult.GetString(8)
                    };

                    result.Add(fligth);
                }
            }
            return result;
        }
    }
}

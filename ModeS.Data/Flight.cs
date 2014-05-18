using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.Gauge;

namespace ModeS.Data
{
    /// <summary>
    /// Class for describe of flight.
    /// </summary>
    public sealed class Flight
    {
        public static List<Flight> DistinctByDate(List<Flight> flights)
        {
            var distinqtSelect = (from fl in flights select fl.Gmt).Distinct();
            return distinqtSelect.Select(dateTime => flights.FirstOrDefault(fl => fl.Gmt == dateTime)).ToList();
        }

        public bool Show { get; set; }

        /// <summary>
        /// Gets serial of plain.
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// Gets callsign of flight.
        /// </summary>
        public string CallSign { get; set; }

        /// <summary>
        /// Gets date time of flight.
        /// </summary>
        public DateTime Gmt { get; set; }

        /// <summary>
        /// Gets aircraft type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets country where flight was found.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets aircraft operator. 
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Gets current location of aircraft.
        /// </summary>
        public string Location { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public override string ToString()
        {
            return string.Format("Type: {4}{1}Data: {0}{1}Serial: {2}{1}Callsign: {3}{1}Location{5}", this.Gmt, Environment.NewLine,
                this.Serial, this.CallSign, this.Type, this.Location);
        }
    }
}

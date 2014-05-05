using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeS.Data
{
    /// <summary>
    /// Class for describe of flight.
    /// </summary>
    public sealed class Flight
    {
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
    }
}

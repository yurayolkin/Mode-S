using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls.Map;

namespace ModeS.Data
{
    public class InformationLayer
    {
        public Location Location { get; set; }

        public string Caption { get; set; }

        public double BaseZoomLevel
        {
            get;
            set;
        }
        public ZoomRange ZoomRange
        {
            get;
            set;
        }

        public InformationLayer(Coordination coordination, string caption)
        {
            this.Location = new Location(coordination.Lat, coordination.Lng);
            this.Caption = caption;
            BaseZoomLevel = 5;
            ZoomRange = new ZoomRange(5, 10000);
        }
    }
}

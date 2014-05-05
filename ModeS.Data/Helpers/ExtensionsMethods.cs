using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeS.Data.Helpers
{
    public static class ExtensionsMethods
    {
        public static string SqlDate(this DateTime time)
        {
            return string.Format("{2}-{1}-{0}", time.Day, time.Month, time.Year);
        }
    }
}

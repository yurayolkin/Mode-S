using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ModeS.ViewModel.Validators
{
    public class DateValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime dateTime;

            if (value == null)
            {
                return new ValidationResult(false, "Date is not correct");
            }

            if(!DateTime.TryParse(value.ToString(), out dateTime))
            {
                return new ValidationResult(false, "Date is not correct");
            }

            if (dateTime.Year < 2000)
            {
                return new ValidationResult(false, "Date is not correct");                
            }

            if (dateTime > DateTime.Now)
            {
                return new ValidationResult(false, "Date is not correct");                
                
            }
            
            return new ValidationResult(true, null);
        }
    }
}

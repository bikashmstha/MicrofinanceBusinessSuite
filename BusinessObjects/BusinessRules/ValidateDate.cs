using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObjects.BusinessRules
{
    /// <summary>
    /// Email validation rule.
    /// </summary>
    public class ValidateDate : ValidateRegex
    {
        public ValidateDate(string propertyName) :
            base(propertyName, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        {
            ErrorMessage = propertyName + " is not a valid email address";
        }

        public ValidateDate(string propertyName, string errorMessage) :
            this(propertyName)
        {
            ErrorMessage = errorMessage;
        }
    }
}

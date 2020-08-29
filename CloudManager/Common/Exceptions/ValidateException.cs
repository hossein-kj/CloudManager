using CloudManager.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Common.Exceptions
{
    [Serializable]
    public class ValidateException : Exception
    {
        public ValidateException(string message) : base(string.Format(Resources.InvalidException,message)) { }

        public ValidateException(string message, Exception innerException) : base(string.Format(Resources.InvalidException, message), innerException)
        {
        }
    }
}

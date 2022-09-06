using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognosis.Exceptions
{
    [Serializable]
    public class InvalidMathParameterException : Exception
    {
        public InvalidMathParameterException() { }

        public InvalidMathParameterException(string message) : base (message) { }
    }
}

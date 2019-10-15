using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_ExceptionLayer
{
    public class HMS_Exception : ApplicationException
    {
        public HMS_Exception() : base() { }
        public HMS_Exception(string message) : base(message) { }
        public HMS_Exception(string message, Exception innerException) : base(message, innerException) { }
    }
}

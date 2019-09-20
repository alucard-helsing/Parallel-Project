using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Exception Layer to handle the exceptions
/// </summary>

namespace CMSExceptionLayer
{
    public class CMSExceptions:ApplicationException
    {
        public CMSExceptions() : base() { }
        public CMSExceptions(string errorMessage) : base(errorMessage) { }
        public CMSExceptions(string errorMessage,Exception innerException) : base(errorMessage, innerException) { }
    }
}

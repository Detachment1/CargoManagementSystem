using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.Exception
{
    public class NumberLowerThanZeroException : ApplicationException
    {
        public NumberLowerThanZeroException(string message) : base(message)
        {
        }
    }
    public class InstanceNotExistException : ApplicationException
    {
        public InstanceNotExistException(string message) : base(message)
        {
        }
    }
    public class FailedToConnectDatabase : ApplicationException
    {
        public FailedToConnectDatabase(string message) : base(message)
        {
        }
    }
}

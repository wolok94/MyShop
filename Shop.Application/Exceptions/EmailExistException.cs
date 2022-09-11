using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Exceptions
{
    public class EmailExistException : Exception
    {
        public EmailExistException(string message) : base(message)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.Infrastructure
{
    public class ValidatorException : Exception
    {
        public string Property { get; protected set; }
        public ValidatorException(string message, string prop): base(message)
        {
            Property = prop;
        }
    }
}

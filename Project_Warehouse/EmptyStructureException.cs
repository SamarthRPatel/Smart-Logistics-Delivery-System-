using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    internal class EmptyStructureException : Exception
    {
        public EmptyStructureException(string msg) : base(msg)
        {

        }
    }
}

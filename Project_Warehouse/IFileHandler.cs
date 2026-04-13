using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Warehouse
{
    internal interface IFileHandler
    {
        void Save(string Path);
        void Load(string Path);
    }
}

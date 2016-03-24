using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.View
{
    interface ILogin
    {
        event EventHandler request;
        string Test {set;}
    }
}

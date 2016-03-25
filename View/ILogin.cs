using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.View
{
    interface ILogin
    {
        event EventHandler<EventArgs> request;
        string Email { get; set; }
        string Mot_de_passe { get; set; }
    }
}

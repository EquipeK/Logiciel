using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Controller
{
    class Bureau
    {
        private string login;
        private string droit;

        public Bureau()
        {
            Logiciel.cs.View.Bureau viewBureau = new Logiciel.cs.View.Bureau();
            //viewBureau.
        }
        public string Droit
        {
            get
            {
                return droit;
            }

            set
            {
                droit = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }
    }
}

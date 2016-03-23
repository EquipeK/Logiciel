using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.Controller
{
    class Login
    {
        private string email;

        public string Email
        {
            get { return email; }
            private set { email = value; }
        }
        private string mot_de_passe;

        public string Mot_de_passe
        {
            get { return mot_de_passe; }
            private set { mot_de_passe = value; }
        }

        public Login()
        {
            Logiciel.cs.View.Login viewLogin = new Logiciel.cs.View.Login();
            //viewLogin.
        }
        public static bool verifierLogin(string email, string password)
        {
            return true;
        }
    }
}

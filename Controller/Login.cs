using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Logiciel.cs.Controller
{
    class Login
    {
        private cs.View.ILogin IViewLogin = null;
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
            viewLogin.ShowDialog();
            IViewLogin.request += onRequest;
            IViewLogin.Test = "";
        }
        public string verifierLogin(string email, string password)
        {
            return "";
        }

        private void onRequest(object sender, EventArgs e)
        {
            //MessageBox.Show()
        }
    }
}

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
        Logiciel.cs.View.Login viewLogin = new Logiciel.cs.View.Login();
        Logiciel.cs.View.Bureau viewBureau = new Logiciel.cs.View.Bureau();
        public Login()
        {
            viewLogin.request += onRequest;
            viewLogin.ShowDialog();
        }
        public string verifierLogin(string email, string password)
        {
            if (true)
            {
                viewLogin.Hide();
                viewBureau.ShowDialog();
            }
            return "";
        }

        public void onRequest(object sender, EventArgs e)
        {
            Email = viewLogin.Email;
            Mot_de_passe = viewLogin.Mot_de_passe;
            verifierLogin(Email, Mot_de_passe);
        }

    }

}

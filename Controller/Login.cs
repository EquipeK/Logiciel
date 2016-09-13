using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logiciel.cs.Model;


namespace Logiciel.cs.Controller
{
    class Login
    {
        //Attribut pour la fenetre de connexion
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
        cs.Model.Users gestUser = null;

        //Contructeur affichant la fenetre de connexion au demarrage du logiciel
        public Login()
        {
            viewLogin.request += onRequest;
            viewLogin.ShowDialog();
            
        }

        //Methode envoyant les idenfiants de l'utilisateur au model pour vérifié si celui-ci existe
        public void verifierLogin(string email, string password)
        {
            gestUser = new cs.Model.Users();
            Users user = gestUser.verifUser(email,password);

            if (user != null)
            {
                viewLogin.Hide();
                Bureau bureauCtrl = new Bureau(user);
            }
        }

        //Evenement sur le bouton de connexion qui recupere les identifiants
        public void onRequest(object sender, EventArgs e)
        {
            Email = viewLogin.Email;
            Mot_de_passe = viewLogin.Mot_de_passe;
            verifierLogin(Email, Mot_de_passe);
        }
    }

}

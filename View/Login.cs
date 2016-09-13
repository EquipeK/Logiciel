using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logiciel.cs.Controller;
namespace Logiciel.cs.View
{
    public partial class Login : Form, ILogin
    {
        //Attribut listener connexion
        public event EventHandler<EventArgs> request;

        //Attribut login
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string mot_de_passe;

        public string Mot_de_passe
        {
            get { return mot_de_passe; }
            set { mot_de_passe = value; }
        }

        public Login()
        {
            InitializeComponent();
        }

        //Methode connexion
        private void click_connexion(object sender, EventArgs e)
        {
            EventHandler<EventArgs> request_connexion = request;

            if (this.text_box_login.Text == "" || this.text_box_mot_de_passe.Text == "")
            {
                MessageBox.Show("Login et/ou mot de passe est incorrect");
            }
            else
            {
                if (request_connexion != null)
                {
                    Email = this.text_box_login.Text;
                    Mot_de_passe = this.text_box_mot_de_passe.Text;
                    request_connexion(this, e);
                }
            }
        }

        public override string ToString()
        {
            return this.text_box_login.Text + " | " + this.text_box_mot_de_passe.Text;
        }

    }
}

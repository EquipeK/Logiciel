using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logiciel.Controller;
namespace Logiciel.cs.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void click_connexion(object sender, EventArgs e)
        {
            if (this.text_box_login.Text == "" || this.text_box_mot_de_passe.Text == "")
            {
                MessageBox.Show("Login et/ou mot de passe est incorrect");
            }
            else
            {
                Controller.Login.verifierLogin(this.text_box_login.Text, this.text_box_mot_de_passe.Text);
            }
        }

        private void label_mot_de_passe_Click(object sender, EventArgs e)
        {

        }




    }
}

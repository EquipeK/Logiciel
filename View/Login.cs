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
        public event EventHandler request;
        public string Test
        {
            set
            {
                this.text_box_login.Text = value;
            }
        }
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
                MessageBox.Show("lste"+this.text_box_login);                
                request(this, EventArgs.Empty);
            }
        }
    }
}

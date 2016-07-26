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
using Logiciel.cs.Model;
namespace Logiciel.cs.View
{
    public partial class Bureau : Form
    {
        public string label { get; set; }
        public event EventHandler<EventArgs> loadGroupRequest;
        public List<IGroups> listGroup = new List<IGroups>();
        private string label_group;
        public Bureau(Users users)
        {
            InitializeComponent();
            this.labelLogin.Text = users.users_email;
            this.labelLevelDroit.Text = users.users_group_label;
            this.label_email2.Text = users.users_email;
            this.label1.Text = users.users_group_label;
            this.label_signature2.Text = users.users_signature;
            this.panel_parent.Visible = true;
            this.panel_stock.Visible = true;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = false;
        }
        public Bureau(List<IGroups> ListGroup)
        {
           
            this.listGroup = ListGroup;
            
            
        }
        public event EventHandler<EventArgs> requestDisplayUsers;
        public event EventHandler<EventArgs> requestCloseSession;
        private void displayUsers(object sender, EventArgs e)
        {
            EventHandler<EventArgs> requestSendCtrl = requestDisplayUsers;
            if (requestSendCtrl != null)
            {
                requestSendCtrl(this, e);
            }
        }

        private void deconnexion(object sender, EventArgs e)
        {
            EventHandler<EventArgs> requestCloseSendCtrl = requestCloseSession;
            if (requestCloseSendCtrl != null)
            {
                requestCloseSendCtrl(this, e);
            }
        }

        private void btn_profil_Click(object sender, EventArgs e)
        {
            this.panel_stock.Visible = false;
            this.panelUsers.Visible = true;
            this.panel_add_user.Visible = false;
        }

        private void btn_stock_Click(object sender, EventArgs e)
        {
            this.panel_stock.Visible = true;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = false;
           
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> requestFillGroup = loadGroupRequest;
            if (requestFillGroup != null)
            {
                requestFillGroup(this, e);
               
            }
            cs.Model.InterfaceDeDonnees inter = new InterfaceDeDonnees();
            inter.ListerTable();
            this.listGroup = inter.Groups;
            foreach (IGroups group in this.listGroup)
            {
                if (group.groups_label != null)
                {
                    Groups grp = new Groups();
                    grp.groups_label = group.groups_label;
                    this.add_user_listbox_group.Items.Add(grp.groups_label);   
                }
            }
            
            this.panel_stock.Visible = false;
            this.panelUsers.Visible = false;
            this.panel_add_user.Visible = true;
        }

        private void add_user_btn_create_Click(object sender, EventArgs e)
        {

            int retour = 0;
            Users newUser = new Users();
            newUser.users_firstname = this.add_user_input_prenom.Text.ToString();
            newUser.users_lastname = this.add_user_input_nom.Text.ToString();
            newUser.users_email = this.add_user_input_email.Text.ToString();
            newUser.users_password = this.add_user_input_password.Text.ToString();
            newUser.users_group_label = label_group;
            newUser.createUser(newUser);
            if (retour != 1)
            {
                init_input_create_user();
            }
            else
            {
                MessageBox.Show("Enregistrement effectuer");
            }
        }


        private void init_input_create_user()
        {
            this.add_user_input_prenom.Text = "";
            this.add_user_input_nom.Text = "";
            this.add_user_input_email.Text = "";
            this.add_user_input_password.Text = "";
        }

        private void add_user_listbox_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            label_group = this.add_user_listbox_group.SelectedItem.ToString();
            
            // Find the string in ListBox2.
            int index = this.add_user_listbox_group.FindString(label_group);
            // If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
            if (index == -1)
                MessageBox.Show("Item is not available in ListBox2");
            else
                MessageBox.Show(label_group);
        }

    }
}

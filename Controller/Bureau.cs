using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logiciel.cs.Model;

namespace Logiciel.cs.Controller
{
    public class Bureau
    {
        private string login;
        private string group;
        public string loginBureau { get; set; }
        public string Group
        {
            get
            {
                return group;
            }

            set
            {
                group = value;
            }
        }
        private Users user;
        Logiciel.cs.View.Bureau viewBureau = null;
        cs.Model.Groups modelGroup = null;
        public Bureau(Users user)
        {
            this.user = user;
            this.login = user.users_email;
            this.group = user.users_group_label;
            viewBureau = new View.Bureau(user);
            login = loginBureau;
            viewBureau.requestDisplayUsers += onRequestDisplayUsers;
            viewBureau.requestCloseSession += onRequestCloseSession;
            viewBureau.loadGroupRequest += onRequestFillGroup;
            viewBureau.ShowDialog();
            
            //rjouter un event sur le label
        }

        private void onRequestFillGroup(object sender, EventArgs e)
        {
            this.getGroup();
        }

        private void onRequestCloseSession(object sender, EventArgs e)
        {
            viewBureau.Hide();
            View.Login viewLogin = new View.Login();
            viewLogin.ShowDialog();
        }

        public void onRequestDisplayUsers(object sender, EventArgs e)
        {
            //MessageBox.Show("Panel Users");   
        }
        public void getGroup()
        {
            modelGroup = new cs.Model.Groups("");
            List<IGroups> list = new List<IGroups>();
            list = modelGroup.getListGroup();
            viewBureau = new View.Bureau(list);
        }
        
    }
}

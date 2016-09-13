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
        public string Group {get; set;}
        private Users user;
        Logiciel.cs.View.Bureau viewBureau = null;
        cs.Model.Groups modelGroup = null;

        //Constructeur affichant la fenetre de gestion de stok après identification
        public Bureau(Users user)
        {
            this.user = user;
            this.login = user.users_email;
            this.group = user.users_group_label;
            viewBureau = new View.Bureau(user);
            login = loginBureau;
            viewBureau.requestCloseSession += onRequestCloseSession;
            viewBureau.loadGroupRequest += onRequestFillGroup;
            viewBureau.ShowDialog();
            
            //rjouter un event sur le label
        }

        //Evenement récuperant le groupe de l'utilisateur après conneexion
        private void onRequestFillGroup(object sender, EventArgs e)
        {
            this.getGroup();
        }

        //Evement fermant la session de l'utilisateur
        private void onRequestCloseSession(object sender, EventArgs e)
        {
            viewBureau.Hide();
            viewBureau = null;
            View.Login viewLogin = new View.Login();
            viewLogin.ShowDialog();
        }

        //Methode retournant le group de l'utilistaeur en fonction de ses identidfiants
        public void getGroup()
        {
            modelGroup = new cs.Model.Groups("");
            List<IGroups> list = new List<IGroups>();
            list = modelGroup.getListGroup();
            viewBureau = new View.Bureau(list);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logiciel.cs.Model
{
    public class Groups : IGroups
    {
        //Attribut du group basé sur la BDD
        public int id_groups { get; set; }
        public int groups_level { get; set; }
        public string groups_label { get; set; }
        private InterfaceDeDonnees inter;
        private List<IGroups> listGroup = new List<IGroups>();

        //Contrsucteur par defaut 
        public Groups()
        {

        }

        //Constructeur instanciant l'interface de donné (requete vers la BDD) et recuperant les group de droit 
        public Groups(string label){
            inter = new InterfaceDeDonnees();
            inter.ListerTable();
            this.getListGroup();
        }

        public List<IGroups> getListGroup()
        {
            listGroup = inter.Groups;
            return listGroup;
        }

        public int getId(string label)
        {
            inter = new InterfaceDeDonnees();
            inter.ListerTable();
            int id = 0;
            foreach (IGroups grp in inter.Groups)
            {
                if (label == grp.groups_label)
                {
                    id = grp.id_groups;
                    MessageBox.Show(id.ToString());
                }
            }
            return id;
        }
    }
}

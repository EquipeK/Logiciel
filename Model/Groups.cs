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
        public int id_groups { get; set; }
        public int groups_level { get; set; }
        public string groups_label { get; set; }
        private InterfaceDeDonnees inter;
        private List<IGroups> listGroup = new List<IGroups>();
        public Groups()
        {

        }
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

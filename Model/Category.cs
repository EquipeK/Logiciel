using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    class Category : ICategory
    {
        //Attribut d'une category basé sur la BDD
        public int id_category { get; set; }
        public string category_name { get; set; }
        public int id_parent { get; set; }
        public string code_cat { get; set; }
        public int itemSequence { get; set; }
        private InterfaceDeDonnees inter;
        private List<ICategory> listCategory = new List<ICategory>();

        //Contructeur qui instancie l'interface de donné pour remplir la list des catégories issus de la BDD
        public Category()
        {
            inter = new InterfaceDeDonnees();
            inter.ListerTable();
        }

        //Methode retournant la liste des categories
        public List<ICategory> getListProduct()
        {
            listCategory = inter.Categories;
            return listCategory;
        }

    }
}

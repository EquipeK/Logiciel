using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    class Category : ICategory
    {
        public int id_category { get; set; }
        public string category_name { get; set; }
        public int id_parent { get; set; }
        public string code_cat { get; set; }
        public int itemSequence { get; set; }
        private InterfaceDeDonnees inter;
        private List<ICategory> listCategory = new List<ICategory>();

        public Category()
        {
            inter = new InterfaceDeDonnees();
            inter.ListerTable();
        }

        public List<ICategory> getListProduct()
        {
            listCategory = inter.Categories;
            return listCategory;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    interface ICategory
    {
        int id_category {get; set;}
        string category_name { get; set; }
        int id_parent { get; set; }
        string code_cat { get; set; }
        int itemSequence { get; set; }
    }
}

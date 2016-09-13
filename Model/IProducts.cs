using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    interface IProducts
    {
        int id_products { get; set; }
        string name { get; set; }
        int quantity { get; set; }
        string slug { get; set; }
        Boolean online { get; set; }
        string reference { get; set; }
        DateTime created_at { get; set; }
        DateTime deleted_at { get; set; }
        DateTime updated_at { get; set; }
        string description1 { get; set; }
        string description2 { get; set; }
    }
}

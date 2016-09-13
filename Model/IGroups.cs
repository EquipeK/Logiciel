using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    public interface IGroups
    {
        int id_groups { get; set; }
        string groups_label { get; set; }
        int groups_level { get; set; }
    }
}

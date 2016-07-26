using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    public interface IUsers
    {
        int id_users { get; set; }
        string users_email { get; set; }
        string users_password { get; set; }
        string users_firstname { get; set; }
        string users_lastname { get; set; }
        int users_id_group { get; set; }
        string users_signature { get; set; }
        string users_group_level { get; set; }
        string users_group_label { get; set; }
        DateTime users_createdAt { get; set; }
        DateTime users_editedAt { get; set; }
        DateTime users_deletedAt { get; set; }

    }
}

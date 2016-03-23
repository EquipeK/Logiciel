using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.Model
{
    struct User
    {
        public int id_users;
        public string users_email;
        public string users_password;
        public int users_id_droits;
        public string users_signature;
        public string users_droit_signature;
    }

    struct Droit
    {
        public int id_droits;
        public string droits_level;
        public int droits_id_users;
    }
}

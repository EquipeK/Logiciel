using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    public class Users : IUsers
    {
        public int id_users { get; set; }
        public string users_email { get; set; }
        public string users_password { get; set; }
        public int users_id_group { get; set; }
        public string users_signature { get; set; }
        public string users_group_level { get; set; }
        public string users_group_label { get; set; }
        public string users_firstname { get; set; }
        public string users_lastname { get; set; }
        private InterfaceDeDonnees inter;
        public DateTime users_createdAt { get; set; }
        public DateTime users_editedAt { get; set; }
        public DateTime users_deletedAt { get; set; }
        public List<IUsers> listUsers = new List<IUsers>(); 
        
        public Users()
        {
           inter  = new InterfaceDeDonnees();
        }

        public Users verifUser(string email, string password)
        {
            Users U = new Users();
            inter.ListerTable();
            inter.closeConnection();
            foreach (IUsers u in inter.Users)
            {
                if (email == u.users_email && password == u.users_password)
                {
                    U.id_users = u.id_users;
                    U.users_email = u.users_email;
                    U.users_password = u.users_password;
                    U.users_signature = u.users_signature;
                    U.users_id_group = u.users_id_group;
                    foreach (IGroups d in inter.Groups)
                    {
                        if (u.users_id_group == d.id_groups)
                        {
                            U.users_group_label = d.groups_label;
                        }
                    }
                }
            }
            inter.closeConnection();
            return U;
        }

        public int createUser(Users user)
        {
            return inter.createUser(user);
        }

        public int deleteUser(string id)
        {
            return inter.deleteUser(id);
        }

        public List<IUsers> getListUsers()
        {
            inter.ListerTable();
            listUsers = inter.Users;
            return listUsers;
        }

        public Users getUser(int id)
        {
            Users user = new Users();
            inter.ListerTable();
            foreach (Users usr in inter.getUsers())
            {
                if(usr.id_users == id){
                    user = usr;
                }
            }
            return user;
        }
    }
}

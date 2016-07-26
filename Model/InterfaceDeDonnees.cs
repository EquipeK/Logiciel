using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logiciel.cs.Model
{
    class InterfaceDeDonnees
    {
        private MySqlConnection logicielConnexion;
        private MySqlDataAdapter daUsers, daGroups;
        private DataTable tUser, tGroup;
        private DataSet dsStock;
        private string bddName;
        public List<IUsers> Users { get { return getUsers(); } }
        public List<IGroups> Groups { get { return getGroups(); } }

        /* Constrcuteur */

        public InterfaceDeDonnees()
        {
            //bddName = ConfigurationManager.ConnectionStrings[0].Name;
            string connexion = "SERVER=localhost; DATABASE=cgfr_rubvitrine;UID=root;PASSWORD=";
            logicielConnexion = new MySqlConnection(connexion);
        }

        public void runApp()
        {
            cs.Controller.Login log = new cs.Controller.Login();
        }

        public void ListerTable()
        {
            try
            {
                logicielConnexion.Open();

                try
                {
                    dsStock = new DataSet();

                    daUsers = new MySqlDataAdapter("SELECT id_user, email, password, signature, id_group FROM user", logicielConnexion);
                    daUsers.TableMappings.Add("Table", "users");
                    daUsers.Fill(dsStock, "users");
                    tUser = dsStock.Tables["users"];

                    daGroups = new MySqlDataAdapter("SELECT * FROM `group`", logicielConnexion);
                    daGroups.TableMappings.Add("Table", "groups");
                    daGroups.Fill(dsStock, "groups");
                    tGroup = dsStock.Tables["groups"];

                    closeConnection();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("lecture de la base impossible", e.Message);
                }
                finally
                {
                    closeConnection();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Acces impossible a la base", e.Message);
            }
            finally
            {
                closeConnection();
            }
        }


        public List<IUsers> getUsers()
        {
            List<IUsers> userList = new List<IUsers>();
            foreach (DataRow userLu in dsStock.Tables["users"].Rows)
            {
                Users user = new Users();
                user.id_users = Int32.Parse(userLu["id_user"].ToString());
                user.users_email = userLu["email"].ToString();
                user.users_password = userLu["password"].ToString();
                user.users_signature = userLu["signature"].ToString();
                user.users_id_group = Int32.Parse(userLu["id_group"].ToString());
                userList.Add(user);
            }
            return userList;
        }

        public List<IGroups> getGroups()
        {
            List<IGroups> groupList = new List<IGroups>();
            foreach (DataRow groupLu in tGroup.Rows)
            {
                Groups group = new Groups();
                group.id_groups = Int32.Parse(groupLu["id_group"].ToString());
                group.groups_level = Int32.Parse(groupLu["level"].ToString());
                group.groups_label = groupLu["label"].ToString();

                groupList.Add(group);
            }
            return groupList;
        }
        public void closeConnection()
        {
            logicielConnexion.Close();
        }

        public int createUser(Users user)
        {
            int retour = 0;
            DateTime created_at = DateTime.Now;
            Groups grp = new Groups();
            try
            {
                logicielConnexion.Open();
                try
                {
                    string requete = "INSERT INTO user (firstname, lastname, email, password, created_at, id_group, signature) VALUES (?firstname,?lastname,?email, ?password, ?created_at, ?id_group, ?signature)";
                    MySqlCommand command = logicielConnexion.CreateCommand();
                    command.CommandText = requete;
                    int id_group = grp.getId(user.users_group_label);

                    command.Parameters.AddWithValue("?firstname", user.users_firstname);
                    command.Parameters.AddWithValue("?lastname", user.users_lastname);
                    command.Parameters.AddWithValue("?email", user.users_email);
                    command.Parameters.AddWithValue("?password", user.users_password);
                    command.Parameters.AddWithValue("?created_at", created_at);
                    command.Parameters.AddWithValue("?id_group", id_group);
                    command.Parameters.AddWithValue("?signature", user.users_lastname);

                   retour = command.ExecuteNonQuery();


                }
                catch(MySqlException e){
                    MessageBox.Show("Insert"+e.Message);
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("connection"+e.Message);
            }
            finally
            {
                logicielConnexion.Close();
            }
            
            //daGroups.InsertCommand.Parameters.AddWithValue("@id_group", id_group);

            //daGroups.Update(dsStock, "users");
            return retour;
        }

        
    }
}

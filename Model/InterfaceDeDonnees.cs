using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Logiciel.cs.Model
{
    class InterfaceDeDonnees
    {
        private MySqlConnection logicielConnexion;
        private MySqlDataAdapter daUsers;
        private MySqlDataAdapter daDroits;
        private DataSet dsStock;
        private string bddName;

        /* Constrcuteur */

        public InterfaceDeDonnees()
        {
            bddName = ConfigurationManager.ConnectionStrings[0].Name;

            string connexion =
                ConfigurationManager.ConnectionStrings[0].ConnectionString;
            logicielConnexion = new MySqlConnection(connexion);
        }

        public void ListerUsers()
        {
            try
            {
                logicielConnexion.Open();

                try
                {
                    dsStock = new DataSet(bddName);

                    daUsers = new MySqlDataAdapter("SELECT * FROM users", logicielConnexion);
                    daUsers.TableMappings.Add("Table", "users");
                    daUsers.Fill(dsStock, "users");

                    daDroits = new MySqlDataAdapter("SELECT * FROM droits", logicielConnexion);
                    daDroits.TableMappings.Add("Table", "droits");
                    daDroits.Fill(dsStock, "droits");
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("lecture de la base impossible", e.Message);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Acces impossible a la base", e.Message);
            }
            finally
            {
                logicielConnexion.Close();
            }
        }
    }
}

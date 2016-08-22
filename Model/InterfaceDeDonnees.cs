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
        private MySqlDataAdapter daUsers, daGroups, daProducts, daCategories, daCategoriesWithProduct;
        private DataTable tUser, tGroup, tProduct, tCategory, tCategoriesWithProduct;
        private DataSet dsStock;
        private string bddName;
        public List<IUsers> Users { get { return getUsers(); } }
        public List<IGroups> Groups { get { return getGroups(); } }
        public List<IProducts> Products { get { return getProducts(); } }
        public List<ICategory> Categories { get { return getCategories(); } }
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

        public void openConnection()
        {
            logicielConnexion.Open();
        }

        public void ListerTable()
        {
            try
            {
                logicielConnexion.Open();

                try
                {
                    dsStock = new DataSet();

                    daUsers = new MySqlDataAdapter("SELECT id_user, firstname, lastname ,email, password, signature, id_group , deleted_at FROM `user` WHERE `deleted_at` IS NULL", logicielConnexion);
                    daUsers.TableMappings.Add("Table", "users");
                    daUsers.Fill(dsStock, "users");
                    tUser = dsStock.Tables["users"];

                    daGroups = new MySqlDataAdapter("SELECT * FROM `group`", logicielConnexion);
                    daGroups.TableMappings.Add("Table", "groups");
                    daGroups.Fill(dsStock, "groups");
                    tGroup = dsStock.Tables["groups"];

                    daProducts = new MySqlDataAdapter("SELECT id_product, name, quantity, online, slug, reference, description1, description2, deleted_at FROM `product` WHERE `deleted_at` IS NULL ORDER BY id_product ASC", logicielConnexion);
                    daProducts.TableMappings.Add("Table", "products");
                    daProducts.Fill(dsStock, "products");
                    tProduct = dsStock.Tables["products"];

                    daCategories = new MySqlDataAdapter("SELECT * FROM `category`", logicielConnexion);
                    daCategories.TableMappings.Add("Table", "categories");
                    daCategories.Fill(dsStock, "categories");
                    tCategory = dsStock.Tables["categories"];
                    
                    closeConnection();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("lecture de la base impossible", e.Message);
                }
                finally
                {
                    closeConnection();
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Acces impossible a la base", e.Message);
            }
            finally
            {
                closeConnection();
            }
        }


        public List<IUsers> getUsers()
        {
            List<IUsers> userList = new List<IUsers>();
             
                foreach (DataRow userLu in tUser.Rows)
                {
                    Users user = new Users();
                    user.id_users = Int32.Parse(userLu["id_user"].ToString());
                    user.users_firstname = userLu["firstname"].ToString();
                    user.users_lastname = userLu["lastname"].ToString();
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

        public List<IProducts> getProducts()
        {
            List<IProducts> productList = new List<IProducts>();
            foreach (DataRow productLu in tProduct.Rows)
            {
                
                Products product = new Products();
                product.id_products = Int32.Parse(productLu["id_product"].ToString());
                product.name = productLu["name"].ToString();
                product.quantity = Int32.Parse(productLu["quantity"].ToString());
                product.online = Boolean.Parse(productLu["online"].ToString());
                product.slug = productLu["slug"].ToString();
                product.reference = productLu["reference"].ToString();
                product.description1 = productLu["description1"].ToString();
                product.description2 = productLu["description2"].ToString();
                productList.Add(product);
            }
            return productList;
        }


        public List<ICategory> getCategories()
        {
            List<ICategory> categoryList = new List<ICategory>();
            foreach (DataRow caregoryLu in tCategory.Rows)
            {

                Category category = new Category();
                category.id_category = Int32.Parse(caregoryLu["id_category"].ToString());
                category.category_name = caregoryLu["category_name"].ToString();
                category.code_cat = caregoryLu["code_cat"].ToString();
                category.itemSequence = Int32.Parse(caregoryLu["itemSequence"].ToString());

                categoryList.Add(category);
            }
            return categoryList;
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

        public int deleteUser(string id)
        {
            int retour = 0;
            DateTime deleted = DateTime.Now;
            try
            {
                logicielConnexion.Open();
                try
                {
                    string requete = "UPDATE user SET deleted_at=@deleted WHERE id_user=@id";
                    MySqlCommand command = logicielConnexion.CreateCommand();
                    command.CommandText = requete;

                    command.Parameters.AddWithValue("@deleted", deleted);
                    command.Parameters.AddWithValue("@id", id);

                    retour = command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("update " + e.Message);
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("connection " + e.Message);
            }
            finally
            {
                logicielConnexion.Close();
            }
            return retour;
        }

        public int createProduct(Products product, List<int> ids_category)
        {
            int retour = 0;
            DateTime created_at = DateTime.Now;
            try
            {
                logicielConnexion.Open();
                try
                {
                    
                    int idToIncr = Products[Products.Count-1].id_products;
                    idToIncr = idToIncr + 1;
                    MessageBox.Show("before inser : " + idToIncr.ToString());
                    string requete = "INSERT INTO product (id_product, name, quantity, slug, online, reference, created_at,description1)"
                        + " VALUES (?id_product, ?name,?quantity,?slug, ?online, ?reference ,?created_at, ?description1);";
                    MySqlCommand command = logicielConnexion.CreateCommand();
                    command.CommandText = requete;
                    //int id_group = grp.getId(user.users_group_label);
                    idToIncr = idToIncr + 1;
                    command.Parameters.AddWithValue("?id_product", idToIncr);
                    command.Parameters.AddWithValue("?name", product.name);
                    command.Parameters.AddWithValue("?quantity", product.quantity);
                    command.Parameters.AddWithValue("?slug", product.slug);
                    command.Parameters.AddWithValue("?online", product.online);
                    command.Parameters.AddWithValue("?reference", product.reference);
                    command.Parameters.AddWithValue("?created_at", created_at);
                    command.Parameters.AddWithValue("?description1", product.description1);
                    command.Parameters.AddWithValue("?description2", product.description2);
                    retour = command.ExecuteNonQuery();
                    logicielConnexion.Close();
                    ListerTable();
                    logicielConnexion.Open();
                    
                    MessageBox.Show("last element "+ idToIncr.ToString());
                    foreach (int id_cat in ids_category)
                    {
                        requete = "INSERT INTO product_has_category (product_id_product, category_id_category)" +
                            " VALUES (?product_id_product,?category_id_category)";
                        command = logicielConnexion.CreateCommand();
                        command.CommandText = requete;

                        command.Parameters.AddWithValue("?product_id_product", idToIncr);
                        command.Parameters.AddWithValue("?category_id_category", id_cat);

                        retour = command.ExecuteNonQuery();
                        
                    }
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Insert " + e.Message);
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("connection " + e.Message);
            }
            finally
            {
                logicielConnexion.Close();
            }
            return retour;
        }

        public int deleteProduct(string id)
        {
            int retour = 0;
            DateTime deleted = DateTime.Now; 
            try
            {
                logicielConnexion.Open();
                try
                {
                    string requete = "UPDATE product SET deleted_at=@deleted WHERE id_product=@id";
                    MySqlCommand command = logicielConnexion.CreateCommand();
                    command.CommandText = requete;

                    command.Parameters.AddWithValue("@deleted",deleted);
                    command.Parameters.AddWithValue("@id", id);

                    retour = command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("update " + e.Message);
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("connection " + e.Message);
            }
            finally
            {
                logicielConnexion.Close();
            }
            return retour;
        }

        public List<ICategory> getProductWithCategories(int id_product) {

            MySqlCommand maCommand = new MySqlCommand();
            maCommand.Connection = logicielConnexion;
            maCommand.CommandText = "SELECT * FROM `product` INNER JOIN `product_has_category` ON product.id_product = product_id_product INNER JOIN category ON `category_id_category` = category.id_category WHERE id_product=" + id_product + ";";
            MySqlDataReader reader = maCommand.ExecuteReader();
            
            List<ICategory> listCategoriesWithProduct = new List<ICategory>();
            Category categoryWithProduct = new Category();
            while(reader.Read()){
                categoryWithProduct.id_category = Int32.Parse(reader["id_category"].ToString());
                categoryWithProduct.category_name = reader["category_name"].ToString();
                listCategoriesWithProduct.Add(categoryWithProduct);
            }
            reader.Close();
            return listCategoriesWithProduct;
        }

        public int createPreOrder(Users user)
        {
            long retour = 0;
            DateTime created_at = DateTime.Now;
            try
            {
                logicielConnexion.Open();
                try
                {
                    string requete = "INSERT INTO preorder (date_order,id_users,email) VALUES (?date_order,?id_users,?email);" ;
                    long valueRetour;
                    MySqlCommand command = logicielConnexion.CreateCommand();
                    command.CommandText = requete;

                    command.Parameters.AddWithValue("?date_order", created_at);
                    command.Parameters.AddWithValue("?id_users", user.id_users);
                    command.Parameters.AddWithValue("?email", user.users_email);
                    command.ExecuteNonQuery();
                    valueRetour = command.LastInsertedId;
                    retour = valueRetour;
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Insert" + e.Message);
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("connection" + e.Message);
            }
            finally
            {
                logicielConnexion.Close();
            }
            return (int)retour;
        }

        public void createPreOrderToProduct(int id_preorder, int id_product, int quantity)
        {
            try
            {
                logicielConnexion.Open();
                try
                {
                    string requete = "INSERT INTO preorder_to_product (id_preorder,id_product,quantity) VALUES (?id_preorder,?id_product,?quantity);";
                    MySqlCommand command = logicielConnexion.CreateCommand();
                    command.CommandText = requete;

                    command.Parameters.AddWithValue("?id_preorder", id_preorder);
                    command.Parameters.AddWithValue("?id_product", id_product);
                    command.Parameters.AddWithValue("?quantity", quantity);
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("Insert" + e.Message);
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("connection" + e.Message);
            }
            finally
            {
                logicielConnexion.Close();
            }
        }
    }
}

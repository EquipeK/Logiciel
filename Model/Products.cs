using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    class Products: IProducts
    {
        //Attribut formant un produit basé sur la BDD
        public int id_products { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string slug { get; set; }
        public Boolean online { get; set; }
        public string reference { get; set; }
        public DateTime created_at { get; set; }
        public DateTime deleted_at { get; set; }
        public DateTime updated_at { get; set; }
        public string description1 { get; set; }
        public string description2 { get; set; }
        private InterfaceDeDonnees inter;
        private List<IProducts> listProducts = new List<IProducts>();

        //Constructeur instanciant l'interface de donné (requete vers la BDD) et remplissant la une list de produit
        public Products()
        {
            inter = new InterfaceDeDonnees();
            inter.ListerTable();
        }

        //Methode appelant l'interface de donnée pour la création de produit et fixant le produit non visible sur le site vitrine
        public int createProduct(Products product, List<int> ids_category)
        {
            product.online = false;
            return inter.createProduct(product, ids_category);
        }

        //Methode remplissant la list de produit
        public List<IProducts> getListProduct()
        {
            listProducts = inter.Products;
            return listProducts;
        }

        //Methode appelant l'interface de donnée pour la suppression d'un produit
        public int deleteProduct(string id)
        {
            return inter.deleteProduct(id);
        }

        //Methode retournant un produit en fonction de son ID
        public Products getProduct(int id_product)
        {
            Products product = new Products();
            inter.ListerTable();
            foreach (Products prd in inter.getProducts())
            {
                if (prd.id_products == id_product)
                {
                    product = prd;
                }
            }
            return product;
        }
    }
}

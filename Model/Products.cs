using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel.cs.Model
{
    class Products: IProducts
    {
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
        public Products()
        {
            inter = new InterfaceDeDonnees();
            inter.ListerTable();
        }

        public int createProduct(Products product, List<int> ids_category)
        {
            product.online = false;
            return inter.createProduct(product, ids_category);
        }

        public List<IProducts> getListProduct()
        {
            listProducts = inter.Products;
            return listProducts;
        }
        public int deleteProduct(string id)
        {
            return inter.deleteProduct(id);
        }

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

using Back_End.Models;

namespace Back_End.Repositories
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            Product product1 = new Product(1, "Producto 1", 3000, false);
            product1.Description = "Remera basica blanca";
            product1.category = new Category(1, "Remeras");
            products.Add(product1);

            Product product2 = new Product(2, "Producto 2", 500, true);
            product2.Description = "Buzo canguro con capucha";
            product2.category = new Category(2, "Buzos");
            products.Add(product2);

            Product product3 = new Product(3, "Producto 3", 1000, false);
            product3.Size = "XXXL";
            products.Add(product3);

            Product product4 = new Product(4, "Producto 4", 1000, true);
            product4.Description = "Buzo canguro con capucha 4 ";
            product4.category = new Category(2, "Buzos");
            products.Add(product4);

            Product product5 = new Product(5, "Producto 5", 1000, false);
            product5.Description = "Remera basica blanca 5";
            product5.category = new Category(1, "Remeras");
            products.Add(product5);

            return products;
        }
    }
}

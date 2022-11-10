using Back_End.Models;

namespace Back_End.Repositories
{
    public class CartRepository
    {
        private static Cart _cart { get; set; }

        public static Cart GetCart() { 
            return _cart;
        }
        public static void AddNewProductToCart(int idProduct, int cantidad) {
            if(_cart==null)_cart = new Cart();
            ProductRepository repo = new ProductRepository();
            List<Product> products = new List<Product>();
            products = repo.GetProducts();
            Product product = products.Find(prod => prod.Id == idProduct);
            if (product != null)
            {
                _cart.items.Add(new CartItem(product, cantidad));
            }
            else
            {
                throw new Exception("Producto no encontrado");
            }
        }
        public static void AddProductToCartMasLindo(int idProduct, int cantidad) 
        {
            try
            {
                if (_cart == null) _cart = new Cart();
                var productToAdd = _cart.items.Find(item => item.product.Id == idProduct);
                if (productToAdd == null)
                    buscarElProductoEnRepoyAgregarloAlCarrito(idProduct, cantidad);
                else 
                    productToAdd.cantidad += cantidad;
                    //productToAdd.cantidad = productToAdd.cantidad +cantidad;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el AddProductTocart {ex.Message}");
            }
        }

        private static void buscarElProductoEnRepoyAgregarloAlCarrito(int idProduct, int cantidad)
        {
            ProductRepository repo = new ProductRepository();
            List<Product> products = new List<Product>();
            products = repo.GetProducts();
            var product = products.Find(productRepo => productRepo.Id == idProduct);
            if (product == null) throw new Exception("Problema no lo econtre ni en el repo");

            _cart.items.Add(new CartItem(product, cantidad));
        }

        public static void AddProductToCart(int idProduct, int cantidad) 
        {
            try
            {
                if (_cart == null) _cart = new Cart();
                
                //Verificar si el producto con id idProduct existe en el carrito
                bool existe = false;
                
                foreach (var item in _cart.items)
                {
                    if (item.product.Id == idProduct)
                    {
                        //Si existe le sumo la cantidad
                        existe = true;
                        item.cantidad = item.cantidad + cantidad;
                        break;
                    }
                }

                //if (!existe)
                if (existe == false)
                {
                    //Si no existe lo busco de la lista de productos y lo agrego al carrito
                    ProductRepository repo = new ProductRepository();
                    List<Product> products = new List<Product>();
                    products = repo.GetProducts();
                    Product product = products.Find(prod => prod.Id == idProduct);
                    if (product != null)
                    {
                        _cart.items.Add(new CartItem(product, cantidad));
                    }
                    else
                    {
                        throw new Exception("Producto no encontrado");
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el AddProductTocart {ex.Message}");
            }
        }


    }
}

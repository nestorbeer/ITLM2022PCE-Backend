using Back_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("GetProductsHome")]
        public ActionResult GetProductsHome() {
            List<Product> products = new List<Product>();

            Product product1 = new Product(1, "Producto 1");
            product1.Description = "Remera basica blanca";
            product1.Price = 3000;
            product1.FinalPrice = product1.Price * 1.21;
            products.Add(product1);

            Product product2 = new Product(2, "Producto 2");
            product2.Description = "Buzo canguro con capucha";
            products.Add(product2);
            Product product3 = new Product(3, "Producto 3");
            product3.Size = "XXXL";
            products.Add(product3);

            return Ok(products);
        }
    }
}

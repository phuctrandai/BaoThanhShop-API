using BaoThanhShopAPI2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BaoThanhShopAPI2.Controllers
{
    public class ProductController : ApiController
    {                
        [HttpGet]
        public IHttpActionResult GetProducts(string productCode)
        {
            if (string.IsNullOrEmpty(productCode))
            {
                return BadRequest("Tham số truyền vào không hợp lệ");
            }

            Entities db = new Entities();

            var product = db.Products.FirstOrDefault(p => p.ProductCode.Equals(productCode));

            if (product == null)
            {
                return BadRequest("Mã sản phẩm không tồn tại");
            }

            var products = db.VProducts.Where(p => p.GroupCode.Equals(product.GroupCode)).ToList();

            return Ok(products);
        }
    }
}

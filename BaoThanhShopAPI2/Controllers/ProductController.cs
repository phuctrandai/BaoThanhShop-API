using BaoThanhShopAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaoThanhShopAPI2.Controllers
{
    public class ProductController : ApiController
    {                
        [HttpGet]
        public IHttpActionResult GetProducts(string productCode)
        {
            Entities db = new Entities();

            var product = db.Products.FirstOrDefault(p => p.ProductCode.Equals(productCode));

            if (product == null)
                return Ok(new List<VProduct>());

            var products = db.VProducts.Where(p => p.GroupCode.Equals(product.GroupCode)).ToList();
            return Ok(products);
        }
    }
}

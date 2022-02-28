using AboutMusicInvMgr.Models.Product;
using AboutMusicInvMgrServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AboutMusicInventoryManagerMVC.Controllers
{
    public class ProductController : ApiController
    {
        //Post(Create)

        private ProductServices CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ProductService = new ProductServices(userId);
            return ProductService;


        }


        [HttpPost]
        public IHttpActionResult Post(ProductCreate product)
        {

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var service = CreateProductService();
            if (!service.CreateProduct(product)) { return InternalServerError(); }
            return Ok($"New product '{product.ProductId}' created!");
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            ProductServices productService = CreateProductService();
            var product = productService.GetProducts();
            return Ok(product);

        }

        //Get By ID
        public IHttpActionResult GetById(int id)
        {
            ProductServices service = CreateProductService();
            var product = service.GetProductById(id);
            return Ok(product);
        }

        //Put (update)
        [HttpPut]
        public IHttpActionResult Put(ProductEdit product)

        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.UpdateProducts(product)) return InternalServerError();

            return Ok($" Item '{product.ProductId}' was updated");

        }

        //Delete (delete)

        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();
            if (!service.DeleteProduct(id)) return InternalServerError();
            return Ok($"Successfully Deleted Product {id} ");
        }
    }
}
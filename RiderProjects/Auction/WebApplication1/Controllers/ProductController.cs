using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Auction.Models;
using BLL.DTOs;
using BLL.Interfaces;
using WebApplication1.Controllers;

namespace Auction.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController()
        {
            
        }

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        public IHttpActionResult GetProducts()
        {
            var product = HomeController._productservice.GetProducts();
            var newProducts = HomeController._mapper.Map<IEnumerable<Product>>(product);
            return Ok(newProducts);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = HomeController._productservice.GetProducts().SingleOrDefault(p => p.Id == id);
            var newProduct = HomeController._mapper.Map<Product>(product);
            if (newProduct == null)
                return BadRequest();
            return Ok(newProduct);
        }


        [HttpPost]
        public IHttpActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var newProduct = HomeController._mapper.Map<ProductDTO>(product);
            HomeController._productservice.AddProduct(newProduct);
            return Created(new Uri(Request.RequestUri + "/" + newProduct.Id), product.Id);
        }
        
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            HomeController._productservice.DeleteProduct(id);
        }
        
        protected override void Dispose(bool disposing)
        { 
            _productService.Dispose();
            base.Dispose(disposing);
        }
    }
}
using AutoMapper;
using GeekBurger.Products.Repository;
using GeekBurger.Products.Service;
using GeekBurger.StoreCatalog.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GeekBurger.Products.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private IProductsRepository _productsRepository;
        private IProductChangedService productChangedService;
        private IMapper _mapper;

        public ProductsController(IProductsRepository productsRepository, IMapper mapper, IProductChangedService productChangedService)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            this.productChangedService = productChangedService;
        }

        [HttpGet]
        [Route("products/{user}")]
        public async System.Threading.Tasks.Task<IActionResult> GetProductsAsync([FromBody] User user)
        {
            var result = new OperationResult<IEnumerable<Product>>();

            try
            {
                result.Data = _productsRepository.GetProductsFromUser(user);
                var wrapper = new ProductsByUserWrapper(user, result.Data);
                productChangedService.SendMessagesAsync();

                result.Success = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
                return BadRequest(result);
            }
        }
    }
}

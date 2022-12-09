
using CatalogueAranda.Entities.Entities;
using CatalogueAranda.Model.ResponseModel;
using CatalogueAranda.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogueAranda.Controllers
{

    public class ProductsController : BaseApiController
    {
        private ProductService _productservices;
        public ProductsController(ProductService productservices)
        {
            _productservices = productservices;
        }

        [HttpGet]
        [Route("GetAllProducts/{filtro}/{page}/{cantity}")]
        public async Task<ActionResult> GetAllProducts([FromRoute] string filtro, int page, int cantity)
        {
            try
            {
      
                var result = (await _productservices.
                    GetAll(filtro, page, cantity).ConfigureAwait(false)) as GenericResponse;

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new GenericResponse
                {
                    ErrorMessage = $"{e.Message ?? string.Empty}",
                    OperationSucces = false
                });
            }
        }
    }
}


using CatalogueAranda.Entities.Entities;
using CatalogueAranda.Model.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogueAranda.Controllers
{

    public class ProductsController : BaseApiController
    {
        private CatalogoArandaContext _context;
        public ProductsController(CatalogoArandaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllProducts/{filtro}/{page}/{cantity}")]
        public async Task<ActionResult> GetAllProducts([FromRoute] string filtro, int page, int cantity)
        {
            try
            {
               // var result = await _context.Products.ToListAsync();
                var result = (await _Productservices.GetAll(filtro, page, cantity).ConfigureAwait(false)) as GenericResponse;
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

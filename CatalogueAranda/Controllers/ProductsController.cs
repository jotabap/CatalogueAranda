
using AutoMapper;
using CatalogueAranda.Entity.Entities;
using CatalogueAranda.Entity.Entities;
using CatalogueAranda.Model.ResponseModel;
using CatalogueAranda.Models.DTOs;
using CatalogueAranda.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogueAranda.Controllers
{

    public class ProductsController : BaseApiController
    {
        private ProductService _productservices;
        private readonly IMapper mapper;

        public ProductsController(ProductService productservices, IMapper mapper)
        {
            _productservices = productservices;
            this.mapper = mapper;
        }
        [HttpPost]
        [Route("InsertProduct")]
        public async Task<ActionResult> InsertProduct([FromForm]ProductInsertDTO modelDto)
        {
            try
            {
                var model = mapper.Map<Product>(modelDto);

                var result = (await _productservices.
                    InsertModel(model).ConfigureAwait(false)) as GenericResponse;

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
        [HttpGet]
        [Route("FilterProducts/{filtro}/{page}/{cantity}")]
        public async Task<ActionResult> FilterProducts([FromRoute] string filtro, int page, int cantity)
        {
            try
            {
      
                var result = (await _productservices.
                    FilterSearch(filtro, page, cantity).ConfigureAwait(false)) as GenericResponse;

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
        [HttpPut("{id}")]
       // [Route("EditProduct")]
        public async Task<ActionResult> EditProduct(int id,[FromForm] ProductInsertDTO modelDto)
        {
            try
            {
                var model = mapper.Map<Product>(modelDto);

                var result = (await _productservices.
                    EditModel(id,model).ConfigureAwait(false)) as GenericResponse;

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
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
               

                var result = (await _productservices.
                    DeleteItem(id).ConfigureAwait(false)) as GenericResponse;

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

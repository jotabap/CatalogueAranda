using CatalogueAranda.Entities.Entities;
using CatalogueAranda.Model.ResponseModel;
using CatalogueAranda.Models.BidingModels;
using CatalogueAranda.Utility.CommonDecoration;
using Microsoft.EntityFrameworkCore;

namespace CatalogueAranda.Services
{
    [Service]
    public class ProductService
    {
        private readonly CatalogoArandaContext _context;
       
        public ProductService(CatalogoArandaContext context)
        {
            _context = context;
        }

        public async Task<object> InsertModel(Product model)
        {
            var apiResponse = new GenericResponse();
            try
            {
                _context.Add(model);

                await _context.SaveChangesAsync();

                apiResponse.OperationSucces = true;
            }
            catch(Exception e)
            {
                apiResponse.ErrorMessage = $"{e.Message ?? string.Empty}";
                apiResponse.OperationSucces = false;
            }
            return apiResponse;
        }

        public async Task<object> FilterSearch(string filtro, int skip, int take)
        {
            var apiResponse = new GenericResponse();
            try
            {                            
               var lstProduct = await _context.Products.Where(fil => (fil.Name.ToUpper().Contains(filtro.ToUpper()))
               || (fil.Description.ToUpper().Contains(filtro.ToUpper()))
               || (fil.Category.ToUpper().Contains(filtro.ToUpper()))).OrderByDescending(x=>x.Name).Take(1000).ToListAsync();

                if (!lstProduct.Any())
                {
                    apiResponse.OperationSucces = false;
                    apiResponse.ErrorMessage = "la consulta no arrojó resultado";
                    return apiResponse;
                }

                var count= lstProduct?.Skip((skip- 1)*take)?.Take(take).Count();
                var total = lstProduct.Count;
                apiResponse.ObjectResponse = lstProduct?.Skip((skip-1)*take)?.Take(take);
                apiResponse.TotalRecords = total;
                apiResponse.CountRecords = (long)count;
                apiResponse.OperationSucces = true;
               
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = $"{ex.Message ?? string.Empty}";
                apiResponse.OperationSucces = false;

            }
            return apiResponse;
        }

    }
}

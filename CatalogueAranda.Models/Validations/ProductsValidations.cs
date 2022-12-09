using CatalogueAranda.Entity.Entities;
using CatalogueAranda.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueAranda.Models.Validations
{
    public static class ProductsValidations
    {
        public static GenericResponse Validations(this Product model)
        {
            var  apiResponse= new GenericResponse();

            if (string.IsNullOrEmpty(model.Name))
            {
                apiResponse.ErrorMessage = "El campo Nombre no puede estar vacio";
                apiResponse.OperationSucces = false;
                return apiResponse;
            }
            if (string.IsNullOrEmpty(model.Category))
            {
                apiResponse.ErrorMessage = "El campo Categoria no puede estar vacio";
                apiResponse.OperationSucces = false;
                return apiResponse;
            }
            if (string.IsNullOrEmpty(model.Image))
            {
                apiResponse.ErrorMessage = "Faltó cargar la imágen";
                apiResponse.OperationSucces = false;
                return apiResponse;
            }
            apiResponse.OperationSucces = true;
            return apiResponse;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogueAranda.Model.ResponseModel
{
    public class GenericResponse
    {
        public bool OperationSucces { get; set; }
        public string ErrorMessage { get; set; }
        public object ObjectResponse { get; set; }
    }
}

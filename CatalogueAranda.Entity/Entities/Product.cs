using System;
using System.Collections.Generic;

namespace CatalogueAranda.Entities.Entities;

public partial class Product:EntityBase
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public string Image { get; set; }


}

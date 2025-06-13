﻿using Microsoft.Azure.Cosmos;

namespace CatalogApi.Data.Entities
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public required string ContactEmail { get; set; }
    }
}

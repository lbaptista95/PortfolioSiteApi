// Em um novo arquivo chamado SchemaHelper.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PortfolioSiteApi.Models;
using PortfolioSiteApi.Data;

namespace PortfolioSiteApi.Helpers
{
    public static class SchemaHelper
    {
        public static List<DbColumnInfo> GetTableSchema<T>(AppDbContext dbContext) where T : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            return entityType.GetProperties().Select(prop => new DbColumnInfo
            {
                Name = prop.Name,
                Type = prop.ClrType.Name
            }).ToList();
        }
    }
}

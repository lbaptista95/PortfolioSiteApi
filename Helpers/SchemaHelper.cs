// Em um novo arquivo chamado SchemaHelper.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PortfolioSiteApi.Models.DTO;
using PortfolioSiteApi.Models.Entity;
using PortfolioSiteApi.Data;

namespace PortfolioSiteApi.Helpers
{
    public static class SchemaHelper
    {
        public static List<DbColumnInfo> GetTableSchema<T>(AppDbContext dbContext, List<string> notIncludedColumns = null) where T : class
        {
            notIncludedColumns = notIncludedColumns ?? new List<string>();
            notIncludedColumns.Add("Id");

            var entityType = dbContext.Model.FindEntityType(typeof(T));  

            foreach(var p in entityType.GetProperties())
            {
                Console.WriteLine(p.Name);
            }        
            
            List<DbColumnInfo> columnList = entityType.GetProperties()            
            .Where(p=> !notIncludedColumns.Contains(p.Name))
            .Select(prop => new DbColumnInfo
            {
                Name = prop.Name,
                Type = CheckImportantFields(prop)
            }).ToList();

            foreach(var c in columnList)
                Console.WriteLine(c.Name);

            return columnList;
        }

        private static string CheckImportantFields(IProperty property)
        {
            string name = property.Name;
            string fieldType = property.ClrType.Name;

            name = name.ToUpper();

            if (name == "PASSWORD")
            {
                fieldType = "Password";
            }
            else if (name == "EMAIL")
            {
                fieldType = "Email";
            }

            return fieldType;
        }
    }


}

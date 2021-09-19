using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asi.Server
{
    [Bind("PageNumber,PageSize")]
    public class PaginationFilter:IModelBinder
    {
        [ModelBinder(Name = "instructor_id")]
        public int PageNumber { get; set; }
        [ModelBinder(Name = "instructor")]
        public int PageSize { get; set; }
        

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
         //   bindingContext.HttpContext.Request;
            var x = (bindingContext.Model as PaginationFilter);
            return Task.CompletedTask;
        }
    }
}

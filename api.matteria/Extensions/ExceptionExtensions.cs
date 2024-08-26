using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.ExceptionHandler;

namespace api.matteria.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ConfigureGlobalException(this IApplicationBuilder app)
        {
            app.UseMiddleware<api.matteria.ExceptionHandler.ExceptionHandler>();
        }
    }
}

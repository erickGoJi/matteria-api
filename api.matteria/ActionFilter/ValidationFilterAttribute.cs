﻿using api.matteria.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.ActionFilter
{
    public class ValidationFilterAttribute: IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = new ApiResponse<List<string>>
                {
                    Success = false,
                    Message = $"Invalid model",
                    Result = context.ModelState.Values
                        .SelectMany(m => m.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList()
                };

                context.Result = new BadRequestObjectResult(response);
                return;
            }
        }
    }
}

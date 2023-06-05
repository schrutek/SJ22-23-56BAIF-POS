using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Filters
{
    public class AuthorisationFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        public string RoleName { get; set; } = string.Empty;

        public override void OnActionExecuted(ActionExecutedContext context)
        { }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(RoleName))
            {
                context.Result = new RedirectToActionResult("Forbidden", "Home", default);
                return;
            }
            string? json = context.HttpContext.Request.Cookies["login_56baif"];
            if (string.IsNullOrEmpty(json))
            {
                context.Result = new RedirectToActionResult("Forbidden", "Home", default);
                return;
            }
            UserDto? dto = JsonSerializer.Deserialize<UserDto>(json);
            if (dto == null)
            {
                context.Result = new RedirectToActionResult("Forbidden", "Home", default);
                return;
            }
            string signature = HashHelper.CalcHash($"{dto?.Fullname}{dto?.Role.Key}");
            if (dto.Signature != signature)
            {
                context.Result = new RedirectToActionResult("Forbidden", "Home", default);
                return;
            }
            if (dto.Role.Key != RoleName)
            {
                context.Result = new RedirectToActionResult("Forbidden", "Home", default);
                return;
            }
            // Hier gehts zur "echgten" Action
        }
    }
}

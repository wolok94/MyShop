using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public int? GetUserId => User == null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public int? GetBasketId => User == null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == "BasketId").Value);

        public ClaimsPrincipal User => httpContextAccessor.HttpContext.User;
    }
}

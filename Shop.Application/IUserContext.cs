using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public interface IUserContext
    {
        int? GetUserId { get; }
        int? GetShoppingCartId { get; }
        ClaimsPrincipal User { get; }
    }
}

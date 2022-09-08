using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.JwtToken
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user, ShoppingCart shoppingCart);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}

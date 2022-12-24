using Shop.Application.DtoModels;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Functions.Users.Queries.Login
{
    public class LogedUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public UserAddressDto Address { get; set; }
        public int AddressId { get; set; }
        public UserRoleDto Role { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserShoppingCartDto ShoppingCart { get; set; }
    }
}

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
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderToSend> Orders { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string GeneratedToken { get; set; }
    }
}

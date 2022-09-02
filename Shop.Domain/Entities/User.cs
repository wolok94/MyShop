using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string hashedPassword { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public List<Comment> Comments { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; } = 1;

    }
}

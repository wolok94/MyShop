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

    }
}

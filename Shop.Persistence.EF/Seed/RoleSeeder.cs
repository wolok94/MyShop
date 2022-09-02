using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Seed
{
    public class RoleSeeder
    {
        private readonly ShopDbContext _dbContext;

        public RoleSeeder(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedRoles()
        {
            if (!_dbContext.Roles.Any())
            {
                var roles = GetRoles();
                await _dbContext.AddRangeAsync(roles);
                await _dbContext.SaveChangesAsync();
            }
        }
        public List<Role> GetRoles()
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Name = "User"
                },
                new Role
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
    }
}

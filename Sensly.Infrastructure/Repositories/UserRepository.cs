using Sensly.Core.Domain.Entities;
using Sensly.Core.Domain.RepositoryContracts;
using Sensly.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context; 

        public UserRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task AddAsync(User user)
        { 
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(); 
        }
    }
}

using Sensly.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.Domain.RepositoryContracts
{
    public interface IUserRepository
    {
        Task AddAsync(User user); 

    }
}

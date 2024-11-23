using Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TokenService
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(AppUser appUser);

    }
}

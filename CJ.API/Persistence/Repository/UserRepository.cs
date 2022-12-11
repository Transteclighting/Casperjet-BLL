using System.Data.Entity;
using CJ.API.Models.Core.Domain;
using CJ.API.Models.Core.Repository;

namespace CJ.API.Persistence.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public CasperJetContext CasperJetContext => Context as CasperJetContext;
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
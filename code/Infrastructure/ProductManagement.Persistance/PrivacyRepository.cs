using ProductManagement.Core;
using Shared.EF;

namespace ProductManagement.Persistance
{
    public class PrivacyRepository : IPrivacyRepository
    {
        public Task<UserPrivacy> GetBy(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

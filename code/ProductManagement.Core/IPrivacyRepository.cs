namespace ProductManagement.Core
{
    public interface IPrivacyRepository
    {
        Task<UserPrivacy> GetBy(string userId);
    }
}

namespace LZRStatsApi.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepo { get; }
        void Save();
    }
}

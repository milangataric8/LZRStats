namespace LZRStatsApi.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepo { get; }
        ITeamRepository TeamRepo { get; }
        void Save();
    }
}

namespace LZRStatsApi.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepo { get; }
        ITeamRepository TeamRepo { get; }
        IPlayerRepository PlayerRepo { get; }
        void Save();
    }
}

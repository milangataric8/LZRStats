using LZRStatsApi.Data;

namespace LZRStatsApi.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private LzrStatsContext _context;
        private IUserRepository _userRepository;
        private ITeamRepository _teamRepository;

        public IUserRepository UserRepo
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }

        public ITeamRepository TeamRepo
        {
            get
            {
                if (_teamRepository == null)
                {
                    _teamRepository = new TeamRepository(_context);
                }

                return _teamRepository;
            }
        }

        public RepositoryWrapper(LzrStatsContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

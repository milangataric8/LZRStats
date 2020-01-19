using LZRStatsApi.Data;

namespace LZRStatsApi.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private LzrStatsContext _context;
        private IUserRepository _userRepository;

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

using Evaluation.DAL.IDao;

namespace Evaluation.DAL.Dapper
{
    internal class DaoFactory : IDaoFactory
    {
        public IUserCredDao UserCredDao
        {
            get
            {
                return new UserCredDao();
            }
        }
    }
}

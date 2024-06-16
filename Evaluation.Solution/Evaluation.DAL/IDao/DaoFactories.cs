using Evaluation.DAL.Dapper;

namespace Evaluation.DAL.IDao
{
    public static class DaoFactories
    {
        public static IDaoFactory GetFactory()
        {
            return new DaoFactory();
        }
    }
}

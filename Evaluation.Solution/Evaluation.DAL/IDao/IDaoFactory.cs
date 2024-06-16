namespace Evaluation.DAL.IDao
{
    public interface IDaoFactory
    {
        IUserCredDao UserCredDao { get; }
    }
}

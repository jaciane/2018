namespace Domain.Interfaces.Repositories
{
    public interface IOrderGenericRepository<T> where T : class
    {
        void OrderByOrderAndTimeStamp(int param,int? param2 = null);
        short FindNextOrder(int WeldingStandardID);
    }
}

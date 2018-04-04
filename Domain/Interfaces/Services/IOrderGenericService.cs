namespace Domain.Interfaces.Services
{
    public interface IOrderGenericService<T> where T : class
    {
        void OrderByOrderAndTimeStamp(int param, int? param2);
        short FindNextOrder(int WeldingStandardID);
    }
}


namespace Application.Interfaces
{
    public interface IOrderGenericAppService<T> where T : class
    {
        void OrderByOrderAndTimeStamp(int param, int? param2);
    }
}

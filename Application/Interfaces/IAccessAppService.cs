using Application.ViewModels;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Interfaces
{
    public interface IAccessAppService : IOrderGenericAppService<AccessViewModel>, ISortedComposedKeyService<AccessViewModel>
    {
    }
}

using Application.ViewModels;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAccessAppService : IOrderGenericAppService<AccessViewModel>, ISortedComposedKeyService<AccessViewModel>
    {
    }
}

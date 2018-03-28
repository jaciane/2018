using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IParameterAppService : IGenericAppService<ParameterViewModel>
    {
        ParameterViewModel GetParameterByName(string name);
        Dictionary<string, string> GetParameterByType(string type);
    }
}

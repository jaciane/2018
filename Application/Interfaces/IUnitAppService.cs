using Domain.Entities;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IUnitAppService :  IGenericAppService<EnterpriseTypeViewModel>
    {
       bool VerifyUnitExists(EnterpriseTypeViewModel u);
        //bool VerifyUnitExistsBySymbol();
        //bool VerifyUnitExistsByDescription();
       
    }
}

using Domain.Entities;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IUnitAppService :  IGenericAppService<UnitViewModel>
    {
       bool VerifyUnitExists(UnitViewModel u);
        //bool VerifyUnitExistsBySymbol();
        //bool VerifyUnitExistsByDescription();
       
    }
}

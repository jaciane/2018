using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Service
{
    public class UnitService : GenericService<Unit>, IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository) : base(unitRepository)
        {
            _unitRepository = unitRepository;
        }

    }


}

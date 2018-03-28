using Application.Interfaces;
using System;
using System.Collections.Generic;
using Domain.Entities;
using Data.Interfaces;
using Domain.Interfaces.Services;
using Application.ViewModels;

namespace Application
{
    public class AccessAppService : GenericAppService, IAccessAppService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAccessService _accessService;

        public AccessAppService(IAccessService accessService, IUnitOfWork uow) : base(uow)
        {
            _accessService = accessService;
            _uow = uow;
        }

        public void OrderByOrderAndTimeStamp(int param, int? param2)
        {
            throw new NotImplementedException();
        }

        public short FindNextOrder(int WeldingStandardID)
        {
            throw new NotImplementedException();
        }

        public AccessViewModel GetByComposedKey(int param1, int param2)
        {
            return AutoMapper.Mapper.Map<Access, AccessViewModel>(_accessService.GetByComposedKey(param1, param2));
        }

        public List<string> Delete(AccessViewModel obj)
        {
            throw new NotImplementedException();
        }

    }
}

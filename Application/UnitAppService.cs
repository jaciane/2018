using System;
using System.Collections.Generic;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using Application.ViewModels;
using System.Linq;
using System.Collections;
using System.Linq.Expressions;

namespace Application
{
    //public class UnitAppService : GenericAppService, IUnitAppService
    //{
    //    private readonly IUnitService _unitService;
    //    private readonly IUnitOfWork _uow;

    //    public UnitAppService(IUnitService unitService, IUnitOfWork uow) : base(uow)
    //    {
    //        _unitService = unitService;
    //        _uow = uow;
    //    }

    //    public void Delete(int id)
    //    {
    //        BeginTransaction();
    //        _unitService.Delete(id);
    //        Commit();
    //    }

    //    public IEnumerable<UnitViewModel> GetAll()
    //    {
    //        return AutoMapper.Mapper.Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(_unitService.GetAll());
    //    }

    //    public UnitViewModel GetById(int id)
    //    {
    //        return AutoMapper.Mapper.Map<Unit, UnitViewModel>(_unitService.GetById(id));
    //    }

    //    public void Insert(UnitViewModel obj)
    //    {
    //        BeginTransaction();
    //        Unit unit = AutoMapper.Mapper.Map<UnitViewModel, Unit>(obj);
    //        _unitService.Insert(unit);
    //        Commit();
    //    }

    //    public void Update(UnitViewModel obj)
    //    {
    //        BeginTransaction();
    //        Unit unit = AutoMapper.Mapper.Map<UnitViewModel, Unit>(obj);
    //        _unitService.Update(unit);
    //        Commit();
    //    }

    //    public bool VerifyUnitExists(UnitViewModel unitViewModel)
    //    {
    //        Unit unit = AutoMapper.Mapper.Map<UnitViewModel, Unit>(unitViewModel);
    //        if (VerifyUnitExistsBySymbol(unitViewModel))
    //            return true;
    //        //description
    //        else
    //        return false;
    //    }

    //    public bool VerifyUnitExistsBySymbol(UnitViewModel unitViewModel)
    //    {
    //        Expression<Func<UnitViewModel, bool>> filter = (UnitViewModel p) => p.Symbol.ToUpper() == unitViewModel.Symbol;
    //        var result = Get(filter, null, "");
    //        return (result!=null) ? true : false;
    //    }

    //    public bool VerifyUnitExistsByDescription()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<UnitViewModel> Get(Expression<Func<UnitViewModel, bool>> filter = null, Func<IQueryable<UnitViewModel>, IOrderedQueryable<UnitViewModel>> orderBy = null, string includeProperties = "")
    //    {
    //        var filterNew = filter!=null ? AutoMapper.Mapper.Map<Expression<Func<UnitViewModel, bool>>, Expression<Func<Unit, bool>>>(filter) : null;
    //        var orderByNew = orderBy != null ? AutoMapper.Mapper.Map<Func<IQueryable<Unit>, IOrderedQueryable<Unit>>> (orderBy) : null;
    //        return AutoMapper.Mapper.Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(_unitService.Get(filterNew, null, includeProperties));
    //    }

    //}
}

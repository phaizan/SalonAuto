﻿using AutoMapper;
using Logic.DtoModels.Filters;
using Logic.Interfaces.Repositories;
using Logic.Interfaces.Services;
using SalonAuto.Features.DtoModels.Center;
using SalonAuto.Features.Interfaces.Managers;
using Storage.Database;
using Storage.Models;

namespace SalonAuto.Features.Managers
{
    public class CenterManager : ICenterManager
    {
        private readonly IMapper _mapper;
        private readonly ICenterRepository _centerRepository;
        private readonly ICenterService _centerService;
        private readonly DataContext _dataContext;

        public CenterManager(
            IMapper mapper,
            ICenterRepository centerRepository, 
            ICenterService centerService, 
            DataContext dataContext)
        {
            _mapper = mapper; 
            _centerRepository = centerRepository;
            _centerService = centerService;
            _dataContext = dataContext;
        }

        public void Create(EditCenter editCenter)
        {
            var center = new Center
            {
                IsnNode = editCenter.IsnNode,
                Code = editCenter.Code,
                Name = editCenter.Name,
            };
            _centerRepository.Create(_dataContext, center);

            _dataContext.SaveChanges();
        }

        public void Update(EditCenter updateCenter) 
        {
            var center = _mapper.Map<Center>(updateCenter);

            _centerRepository.Update(_dataContext, center);

            _dataContext.SaveChanges();
        }

        public void Delete(Guid isnNode) 
        {
            _centerRepository.Delete(_dataContext, isnNode);

            _dataContext.SaveChanges();
        }

        public CenterDto GetCenter(Guid isnNode) 
        {
            var center = _centerRepository.GetById(_dataContext, isnNode);
            return _mapper.Map<CenterDto>(center);
        }

        public CenterDto[] GetListCenters(CenterFilterDto centerFilter) 
        {
            var center = _centerService.GetCenterQueryble(_dataContext, centerFilter, true)
                .Select(x => new CenterDto
                 {
                     IsnNode = x.IsnNode,
                     Name = x.Name,
                     Code = x.Code,
                 })
                .ToArray();

            return center;
        }
    }
}

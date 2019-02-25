﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLA_task.BLL.Interface;
using MLA_task.BLL.Interface.Exceptions;
using DemoError = MLA_task.BLL.Interface.Exceptions.DemoServiceException.ErrorType;
using MLA_task.BLL.Interface.Models;
using MLA_task.DAL.Interface;
using MLA_task.DAL.Interface.Entities;
using AutoMapper;

namespace MLA_task.BLL
{
    public class DemoModelService : IDemoModelService
    {
        private readonly IDemoDbModelRepository _demoDbModelRepository;

        public DemoModelService(IDemoDbModelRepository demoDbModelRepository)
        {
            _demoDbModelRepository = demoDbModelRepository;
        }

        public async Task<IEnumerable<DemoModel>> GetAllDemoModelsAsync()
        {
            var dbModels = await _demoDbModelRepository.GetAllAsync();

            return Mapper.Map<IEnumerable<DemoDbModel>,IEnumerable<DemoModel>>(dbModels);
        }

        public async Task<DemoModel> GetDemoModelByIdAsync(int id)
        {
            if (id == 23)
            {
                throw new DemoServiceException(DemoError.WrongId);
            }

            var dbModel = await _demoDbModelRepository.GetByIdAsync(id);

            return Mapper.Map<DemoModel>(dbModel);
        }

        public async Task<DemoModel> CreateDemoModelAsync(CreateUpdateDemoModel newDemoModel)
        {
            if (newDemoModel.Name == "bla-bla")
            {
                throw new DemoServiceException(DemoError.WrongName);
            }

            var dbModel = Mapper.Map<CreateUpdateDemoModel, DemoDbModel>(newDemoModel);
            DemoDbModel demoDbModel = await _demoDbModelRepository.AddDemoModelAsync(dbModel);

            return Mapper.Map<DemoModel>(demoDbModel);
        }

        public async Task DeleteDemoModelAsync(int id)
        {
            if (id == 1)
            {
                throw new DemoServiceException(DemoError.WrongId);
            }

            await _demoDbModelRepository.DeleteDemoModelAsync(id);
        }
    }
}

using System;
using AutoMapper;
using MLA_task.DAL.Interface.Entities;
using MLA_task.BLL.Interface.Models;

namespace MLA_task.BLL.Mappers
{
    public class DemoModelMappingProfile : Profile
    {
        public DemoModelMappingProfile()
        {
            CreateMap<DemoDbModel, DemoModel>()
                .ForMember(demoModel => demoModel.CommonInfo, opt => opt.MapFrom(src => src.DemoCommonInfoModel.CommonInfo));

            CreateMap<DemoDbModel, CreateUpdateDemoModel>();

            CreateMap<CreateUpdateDemoModel, DemoDbModel>()
                .ForMember(dbModel => dbModel.Modified, opt => opt.MapFrom(p => DateTime.UtcNow))
                .ForMember(dbModel => dbModel.Created, model => model.Ignore())
                .ForMember(dbModel => dbModel.Id, model => model.Ignore())
                .ForMember(dbModel => dbModel.DemoCommonInfoModel, model => model.Ignore());     
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

           // CreateMap<DemoDbModel, CreateUpdateDemoModel>()
              //  .
        }
    }
}

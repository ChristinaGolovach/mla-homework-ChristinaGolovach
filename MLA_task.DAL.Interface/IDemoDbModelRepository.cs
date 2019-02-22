using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLA_task.DAL.Interface.Entities;

namespace MLA_task.DAL.Interface
{
    public interface IDemoDbModelRepository
    {
        Task<IEnumerable<DemoDbModel>> GetAllAsync();

        Task<DemoDbModel> GetByIdAsync(int id);

        // почему этот метод здесь, если это репозитоий для DemoDbModel
        Task<DemoCommonInfoDbModel> GetCommonInfoByDemoIdAsync(int demoDbModelId);        
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using MLA_task.BLL.Interface.Models;

namespace MLA_task.BLL.Interface
{
    public interface IDemoModelService
    {
        Task<DemoModel> GetDemoModelByIdAsync(int id);

        Task<IEnumerable<DemoModel>> GetAllDemoModelsAsync();

        Task<DemoModel> CreateDemoModelAsync(CreateUpdateDemoModel newDemoModel);

        Task DeleteDemoModelAsync(int id);
    }
}
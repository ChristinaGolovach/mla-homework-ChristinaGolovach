using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MLA_task.DAL.EF;
using MLA_task.DAL.Interface;
using MLA_task.DAL.Interface.Entities;

namespace MLA_task.DAL.Repositories
{
    public class DemoDbModelRepository : IDemoDbModelRepository
    {
        private readonly DemoContext _context;

        public DemoDbModelRepository(DemoContext context)
        {
            _context = context;
        }

        // TODO IOrderedEnumerable ???
        public async Task<IEnumerable<DemoDbModel>> GetAllAsync()
        {
            var dbModels = await _context.DemoDbModels.Include(model => model.DemoCommonInfoModel).OrderBy( m => m.Id).ToListAsync();

            return dbModels;
        }

        public async Task<DemoDbModel> GetByIdAsync(int id)
        {
            var model = await _context.DemoDbModels.SingleAsync(item => item.Id == id);

            return model;
        }

        public async Task<DemoCommonInfoDbModel> GetCommonInfoByDemoIdAsync(int demoDbModelId)
        {
            var demoModel = await _context.DemoDbModels.SingleAsync(item => item.Id == demoDbModelId);

            var commonInfo = await _context.DemoCommonInfoModels.SingleAsync(item => item.Id == demoModel.DemoCommonInfoModelId);

            return commonInfo;
        }

        public async Task<DemoDbModel> AddDemoModelAsync(DemoDbModel newDemoModel)
        {
            _context.DemoDbModels.Add(newDemoModel);

            await _context.SaveChangesAsync();

            return newDemoModel;
        }

        public async Task DeleteDemoModelAsync(int id)
        {
            var dbModel = await _context.DemoDbModels.FirstOrDefaultAsync(m => m.Id == id);

            if (dbModel == null)
            {
                //TODO change to custom exception ??? - NotFound - or check maybe this not required.
                throw new ArgumentException($"The model with id {id} not found");
            }

            _context.DemoDbModels.Remove(dbModel);

            await _context.SaveChangesAsync();
        }
    }
}
using System;

namespace MLA_task.DAL.Interface.Entities
{
    public class DemoDbModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Modified { get; set; } = DateTime.UtcNow;

        public int DemoCommonInfoModelId { get; set; }

        public virtual DemoCommonInfoDbModel DemoCommonInfoModel { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA_task.BLL.Interface.Models
{
    public class CreateUpdateDemoModel
    {
        public string Name { get; set; }

        // и здесь дата и время и в EF модели снова мы присваиваем новое значение ?
        //public DateTime Created { get; set; } = DateTime.UtcNow;

        //public DateTime Modified { get; set; } = DateTime.UtcNow;

        public int DemoCommonInfoModelId { get; set; }
    }
}

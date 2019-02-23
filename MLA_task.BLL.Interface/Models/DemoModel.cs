using System;

namespace MLA_task.BLL.Interface.Models
{
    public class DemoModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // и здесь дата и время и в EF модели снова мы присваиваем новое значение ?
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Modified { get; set; } = DateTime.UtcNow;

        public string CommonInfo { get; set; }
    }
}
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using MLA_task.DAL.Interface.Entities;

namespace MLA_task.DAL.EF
{
    public class DemoCommonInfoDbModelConfig : EntityTypeConfiguration<DemoCommonInfoDbModel>
    {
        public DemoCommonInfoDbModelConfig()
        {
            ToTable("DemoCommonInfoTable");
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.CommonInfo).IsRequired().IsUnicode().HasMaxLength(50).IsVariableLength();
        }
    }
}
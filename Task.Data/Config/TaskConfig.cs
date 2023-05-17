using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManage.ViewModels;

namespace TaskManage.Data.Config
{
    public class TaskConfig : IEntityTypeConfiguration<TaskVM>
    {

        public void Configure(EntityTypeBuilder<TaskVM> builder)
        {
            builder.ToTable("Task");
        }
    }
}

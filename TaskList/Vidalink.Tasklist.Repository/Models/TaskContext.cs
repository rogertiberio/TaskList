using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidalink.Tasklist.Repository.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("DefaultConnection")
        {
        }

        public DbSet<Task> Task { get; set; }
    }
}

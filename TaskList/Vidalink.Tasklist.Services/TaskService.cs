using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vidalink.Tasklist.Repository.Models;

namespace Vidalink.Tasklist.Services
{
    public class TaskService : BaseService<Task>
    {
        public override void Edit(Task item)
        {
            if (item.DataExecucao <= DateTime.Now)
            {   
                throw new Exception("Somente é permitido alterar tarefas futuras ");
            }
            else
            {
                base.Edit(item);
            }
        }
    }
}

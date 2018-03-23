using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidalink.Tasklist.Repository.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Titulo { get; set; }            
        public string Descricao { get; set; }
        public DateTime DataExecucao { get; set; }
    }
}

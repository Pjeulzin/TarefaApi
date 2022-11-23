using System;
using System.ComponentModel.DataAnnotations;

namespace TarefaApi.Models
{

    public class Tarefa
    {
        [Key]
        public int Codigo { get; set;}
        
        [Required]
        public string Descricao { get; set; }
        
        [MaxLength(1)]
        public string Status { get; set; }
    }
}

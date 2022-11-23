using System.ComponentModel.DataAnnotations;

namespace TarefaApi.Models
{
    public class UpdateTarefa
    {
        [Required]
        public string Descricao { get; set; }
        public string Status { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TarefaApi.Models
{
    public class AddTarefa
    {
        [Required]
        public string Descricao { get; set; }
    }
}

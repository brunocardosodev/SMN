using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Tarefa
    {
        [Key]
        public int idTarefa { get; set; }

        [Required(ErrorMessage = "O nome da tarefa é obrigatório")]
        [StringLength(400, MinimumLength = 15, ErrorMessage = "O nome deve ter entre 15 e 400 caracteres")]
        [DisplayName("Tarefa")]
        public string nmTarefa { get; set; }

        public string image { get; set; }

        [DisplayName("Concluído")]
        public bool icConcluido { get; set; }
    }
}
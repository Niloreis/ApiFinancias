using System.ComponentModel.DataAnnotations;

namespace ApiFinancias.Services.Models
{
    public class FinanciasPutModel
    {
        [Required(ErrorMessage = "Por favor, informe um Id desejado.")]
        public Guid? IdFinancias { get; set; }

        [Required(ErrorMessage = "Por favor, informe um Id desejado.")]
        public Guid? IdTpFinancias { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe um nome.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe um valor.")]
        public string? Valor { set; get; }

        [Required(ErrorMessage = "Por favor, informe uma data.")]
        public string? Date { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor de uma meta.")]
        public string? Meta { get; set; }

        //Sem Erro Menssage
        public string? Obs { get; set; }
    }
}

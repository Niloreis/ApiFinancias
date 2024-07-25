
using System.ComponentModel.DataAnnotations;

namespace ApiFinancias.Services.Models
{
    public class FinanciasGetModel
    {
        public Guid? IdFinancias { get; set; }
        public Guid? IdTpFinancias { get; set; }
        public string? Nome { get; set; }
        public string? Valor { set; get; }
        public string? Date { get; set; }
        public string? Obs { get; set; }
        public string? Meta { get; set; }
    }
}

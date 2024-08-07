﻿using System.ComponentModel.DataAnnotations;

namespace ApiFinancias.Services.Models
{
    public class TpFinanciasPutModel
    {
        [Required(ErrorMessage = "Por favor, informe um Id desejado.")]
        public Guid? IdTpFinancias { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe um nome.")]
        public string? Nome { get; set; }
    }
}

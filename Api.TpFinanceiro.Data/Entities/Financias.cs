using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.TpFinanceiro.Data.Entities
{
    public class Financias
    {
        private Guid? _idFinancias;
        private string? _nome;
        private string? _valor;
        private string? _date;
        private string? _obs;
        private string? _meta;
        private Guid? _idTpFinancias;  
        private TpFinancias? _Tpfinancias;

        public Guid? IdFinancias { get => _idFinancias; set => _idFinancias = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Date { get => _date; set => _date = value; }
        public string? Obs { get => _obs; set => _obs = value; }
        public TpFinancias? Tpfinancias { get => _Tpfinancias; set => _Tpfinancias = value; }
        public Guid? IdTpFinancias { get => _idTpFinancias; set => _idTpFinancias = value; }
        public string? Valor { get => _valor; set => _valor = value; }
        public string? Meta { get => _meta; set => _meta = value; }
    }
}

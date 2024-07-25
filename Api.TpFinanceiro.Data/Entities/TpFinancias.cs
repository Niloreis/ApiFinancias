using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.TpFinanceiro.Data.Entities
{
    public class TpFinancias
    {
        private Guid? _idTPFinancias;
        private string? _Nome;
        private List<Financias>? _financias;

        public Guid? IdTPFinancias { get => _idTPFinancias; set => _idTPFinancias = value; }
        public string? Nome { get => _Nome; set => _Nome = value; }
        public List<Financias>? Financias { get => _financias; set => _financias = value; }
    }
}

using Api.TpFinanceiro.Data.Entities;
using ApiFinancias.Services.Models;
using AutoMapper;

namespace ApiFinancias.Services.Mapping
{
    public class EntityToModelMap: Profile
    {
        public EntityToModelMap()
        {
            CreateMap<TpFinancias, TpFinanciasGetModel>();
            CreateMap<Financias, FinanciasGetModel>();
        }

    }
}

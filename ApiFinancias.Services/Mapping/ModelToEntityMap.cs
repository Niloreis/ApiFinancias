using Api.TpFinanceiro.Data.Entities;
using ApiFinancias.Services.Models;
using AutoMapper;

namespace ApiFinancias.Services.Mapping
{
    public class ModelToEntityMap:Profile
    {
        //método construtor
        public ModelToEntityMap()
        {
            CreateMap<TpFinanciasPostmodel, TpFinancias>()
                .AfterMap((src, dest) =>
                {
                    dest.IdTPFinancias = Guid.NewGuid();
                });

            CreateMap<TpFinanciasPutModel, TpFinancias>();

            CreateMap<TpFinanciasPutModel, TpFinancias>()
                .AfterMap((src, dest) =>
                {
                    dest.IdTPFinancias = Guid.NewGuid();
                });

            CreateMap<TpFinanciasPutModel, TpFinancias>();




            CreateMap<FinanciasPostModel, Financias>()
                .AfterMap((dest, src) => 
                {
                    dest.IdTpFinancias = Guid.NewGuid();
                });
            CreateMap<FinanciasPutModel, Financias>();

            CreateMap<FinanciasPutModel, Financias>()
               .AfterMap((src, dest) =>
               {
                   dest.IdFinancias = Guid.NewGuid();
               });

            CreateMap<FinanciasPutModel, Financias>();
        }

    }
}

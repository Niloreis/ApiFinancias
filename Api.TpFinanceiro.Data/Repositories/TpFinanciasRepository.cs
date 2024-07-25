using Api.TpFinanceiro.Data.Contextes;
using Api.TpFinanceiro.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.TpFinanceiro.Data.Repositories
{
    public class TpFinanciasRepository : IRepository<TpFinancias>
    {
        public void Add(TpFinancias entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.TpFinancias.Add(entity);
                dataContext.SaveChanges();
            }

        }

        public void Delete(TpFinancias entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.TpFinancias.Remove(entity);
                dataContext.SaveChanges();
            }

        }
            public List<TpFinancias> GetAll()
        {
                using (var dataContext = new DataContext())
                {
                    return dataContext.TpFinancias
                        .OrderBy(c => c.Nome)
                        .ToList();
                }

            }

        public TpFinancias GetById(Guid? id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.TpFinancias
                    .Where(c => c.IdTPFinancias == id)
                    .FirstOrDefault();
            }

        }

        public void Update(TpFinancias entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }

        }
    }
}

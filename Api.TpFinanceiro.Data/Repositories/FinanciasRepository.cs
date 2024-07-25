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
    public class FinanciasRepository : IRepository<Financias>
    {
        public void Add(Financias entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Financias.Add(entity);
                dataContext.SaveChanges();
            }

        }

        public void Delete(Financias entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Financias.Remove(entity);
                dataContext.SaveChanges();
            }

        }

        public List<Financias> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Financias
                    .Include(p => p.Tpfinancias)
                    .OrderBy(p => p.Nome)
                    .ToList();
            }

        }

        public Financias GetById(Guid? id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Financias
                    .Include(p => p.Tpfinancias)
                    .Where(p => p.IdFinancias == id)
                    .FirstOrDefault();
            }

        }

        public void Update(Financias entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }

        }
    }
}

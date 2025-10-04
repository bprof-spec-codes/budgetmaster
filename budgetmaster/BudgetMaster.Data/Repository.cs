using BudgetMaster.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMaster.Data
{
    public class Repository<T> where T : class, IEntityBase
    {
        BudgetMasterDBContext _ctx;
        public Repository(BudgetMasterDBContext ctx)
        {
                this._ctx = ctx;
        }
        public void Create(T entity) 
        {
            _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();
        }
        public T FindById(int id) 
        {
            return _ctx.Set<T>().First(x => x.Id == id);
        }

        public void DeleteById(int id) 
        {
            var entity = FindById(id);
            _ctx.Set<T>().Remove(entity);
            _ctx.SaveChanges();
        }

        public IQueryable<T> GetAll() 
        {
            return _ctx.Set<T>();
        }

        public void Update(T entity) 
        {

            var old = FindById(entity.Id);
            if (old == null)
                throw new Exception("Entity not found");
            foreach (var prop in typeof(T).GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }
            _ctx.SaveChanges();
        }



    }
}

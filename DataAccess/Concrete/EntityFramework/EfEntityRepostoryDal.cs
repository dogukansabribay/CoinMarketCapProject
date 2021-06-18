using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataAccess.Abstract;



namespace DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryDal<T> : IEntityRepostory<T> where T : class, IEntity, new()
    {
        private readonly CoinContext context;
      
        public EfEntityRepositoryDal(CoinContext context)
        {
            this.context = context;
         
        }
        public void Add(T entity)
        {
          
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Add(List<T> entities)
        {
            context.Set<T>().AddRange(entities);
            context.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Any(filter);
        }

        public void Delete(T entity)
        {
          
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    context.Set<T>().Remove(entity);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetAll(filter);


                    foreach (var item in collection)
                    {
                        Delete(item);
                    }

                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter).FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return context.Set<T>().Where(filter).ToList();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
           
            try
            {
                context.Set<T>().Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}


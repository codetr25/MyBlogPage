using MyBlogPage.DAL;
using MyBlogPage.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogPage.Business
{
    public class ManagerBase<T> : IDapperRepository<T> where T : class
    {
        private Repository<T> repository=  new Repository<T>();
        public bool Delete(T entity)
        {
            return repository.Delete(entity);
        }

        public int Execute(string sql)
        {
           return repository.Execute(sql);
        }

        public int Execute(string sql, object param)
        {
           return repository.Execute(sql, param);

        }

        public T Find(int id)
        {
            return repository.Find(id);
        }

        public T Find(string sql)
        {
           return repository.Find(sql);
        }

        public T Find(string sql, object param)
        {
          return repository.Find(sql, param);
        }

        public long Insert(T entity)
        {
            return repository.Insert(entity);
        }

        public IEnumerable<T> Query(string sql)
        {
           return repository.Query(sql);
        }

        public IEnumerable<T> Query(string sql, object param)
        {
           return repository.Query(sql, param);
        }

        public object Scalar(string sql)
        {
           return repository.Scalar(sql);
        }

        public object Scalar(string sql, object param)
        {
           return repository.Scalar(sql,param);
        }

        public bool Update(T entity)
        {
           return repository.Update(entity);
        }
    }
}
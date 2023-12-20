using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogPage.DAL.Abstract
{
    internal interface IDapperRepository<T>
    {
        long Insert(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T Find(int id);
        T Find(string sql);
        T Find(string sql,object param);
        IEnumerable<T> Query(string sql);
        IEnumerable<T> Query(string sql,object param);

        int Execute(string sql);
        int Execute(string sql, object param);
        object Scalar(string sql);
        object Scalar(string sql,object param);
    }
}

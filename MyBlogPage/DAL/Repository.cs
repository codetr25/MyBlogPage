using Dapper;
using Dapper.Contrib.Extensions;
using MyBlogPage.DAL.Abstract;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyBlogPage.DAL
{
    public class Repository<T> : IDapperRepository<T> where T : class
    {
        private MySqlConnection GetOpenConnection()
        {
            string dbContext = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(dbContext);
            mySqlConnection.Open();
            return mySqlConnection;
        }
        public bool Delete(T entity)
        {
            bool res;
            using (var conn= GetOpenConnection())
            {
                res=conn.Delete(entity);
            }
            return res;
        }

        public int Execute(string sql)
        {
            int res;
            using (var conn = GetOpenConnection())
            {
                res = conn.Execute(sql);
            }
            return res;
        }

        public int Execute(string sql, object param)
        {
            int res;
            using (var conn = GetOpenConnection())
            {
                res = conn.Execute(sql,param);
            }
            return res;
        }

        public T Find(int id)
        {
            T res;
            using (var conn = GetOpenConnection())
            {
                res = conn.Get<T>(id);
            }
            return res;
        }

        public T Find(string sql)
        {
            T res;
            using (var conn = GetOpenConnection())
            {
                res = conn.QueryFirstOrDefault<T>(sql);
            }
            return res;
        }

        public T Find(string sql, object param)
        {
            T res;
            using (var conn = GetOpenConnection())
            {
                res = conn.QueryFirstOrDefault<T>(sql,param);
            }
            return res;
        }

        public long Insert(T entity)
        {
            long res;
            using (var conn = GetOpenConnection())
            {
                res = conn.Insert<T>(entity);
            }
            return res;
        }

        public IEnumerable<T> Query(string sql)
        {
            IEnumerable<T> res;
            using (var conn = GetOpenConnection())
            {
                res = conn.Query<T>(sql);
            }
            return res;
        }

        public IEnumerable<T> Query(string sql, object param)
        {
            IEnumerable<T> res;
            using (var conn = GetOpenConnection())
            {
                res = conn.Query<T>(sql,param);
            }
            return res;
        }

        public object Scalar(string sql)
        {
            object res;
            using (var conn = GetOpenConnection())
            {
                res = conn.ExecuteScalar<T>(sql);
            }
            return res;
        }

        public object Scalar(string sql, object param)
        {
            object res;
            using (var conn = GetOpenConnection())
            {
                res = conn.ExecuteScalar<T>(sql, param);
            }
            return res;
        }

        public bool Update(T entity)
        {
            bool res;
            using (var conn = GetOpenConnection())
            {
                res = conn.Update<T>(entity);
            }
            return res;
        }
    }
}
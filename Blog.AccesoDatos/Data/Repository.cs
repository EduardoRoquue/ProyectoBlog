using Blog.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.AccesoDatos.Data
{
    //Clase del repositorio
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;
        //Constructor 
        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        //Metodos generados desde la interfaz (Implementacion)

        //Metodo para añadir a la DB
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        //Metodo para obtener de la DB
        public T Get(int id)
        {
            return dbSet.Find(id);
        }


        //Metodo para obtener bajo criterios
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            //Filtro de los datos
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties separadas por comas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            //Validar ordenamiento
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            //Retorna el ordenamiento
            return query.ToList();

        }

        //Metodo para obetener el primero o el de defecto
        //Se reutilizó el código de arriba
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties separadas por comas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        //Metodo para eliminar por ID
        public void Remove(int id)
        {
            T entityRemove = dbSet.Find(id);
            Remove(entityRemove);
        }

        //Metodo para eliminar por la entidad
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.AccesoDatos.Data.Repository
{
    //Interfaz del repositorio (Generacion de los metodos) 
    public interface IRepository<T> where T : class
    {
        //Metodo para obtener todo

        //Obtener un registro
        T Get(int id);

        //Obtener registro ordenados o filtrados
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null 
            );

        //Obtener el primero o el de defecto
        T GetFirstOrDefault(
             Expression<Func<T, bool>> filter = null,
             string includeProperties = null
            );

        //Para agregar
        void Add(T entity);

        //Para remover por ID
        void Remove(int id);

        //Remover por entidad
        void Remove(T entity);

    }
}

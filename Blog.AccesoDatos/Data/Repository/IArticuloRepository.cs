using Blog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.AccesoDatos.Data.Repository
{
    //Interfaz de la categoría
    public interface IArticuloRepository : IRepository<Articulo>
    {

        //Metodo para actualizar el registro
        void Update(Articulo articulo);
    }
}

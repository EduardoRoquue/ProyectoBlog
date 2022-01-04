using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.AccesoDatos.Data.Repository
{
    //Interfaz contenedora de todos los repositorios
    public interface IContenedorTrabajo : IDisposable
    {
        //Aqui es donde se almacenan y procesan los repositorios ya creados
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }

        void Save();
    }
}

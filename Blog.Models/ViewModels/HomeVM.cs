using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Articulo> ListaArticulo { get; set; }
    }
}

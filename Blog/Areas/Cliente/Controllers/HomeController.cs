using Blog.AccesoDatos.Data.Repository;
using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                //Aqui van los elementos a mostrar
                Slider = _contenedorTrabajo.Slider.GetAll(),
                ListaArticulo = _contenedorTrabajo.Articulo.GetAll()
                //Agregar aqui la lista de nosotros y acerca de
            };

            return View(homeVM);
        }
    }
}

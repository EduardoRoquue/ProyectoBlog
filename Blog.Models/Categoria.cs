using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Models
{
    //Modelo de la tabla Categoría de la DB
    public class Categoria
    {
        //Campos de la tabla

        //Campo del ID como llave primaria
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ingresa un nombre para la categoría")]
        [Display(Name ="Nombre categoría")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Orden de visualizacion")]
        public int Orden { get; set; }
    }
}

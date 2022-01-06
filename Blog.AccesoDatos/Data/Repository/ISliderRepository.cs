using Blog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.AccesoDatos.Data.Repository.IRepository
{
    public interface ISliderRepository : IRepository<Slider>
    {
        void Update(Slider slider);
    }
}

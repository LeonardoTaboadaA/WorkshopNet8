using AutoMapper;
using Jazani.Application.Dtos.Libros;
using Jazani.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Prestamos.Profiles
{
    public class PrestamoProfile : Profile
    {
        public PrestamoProfile()
        {
            CreateMap<Prestamo, PrestamoDto>();
            CreateMap<Prestamo, PrestamoMediumDto>();
            CreateMap<Prestamo, PrestamoSmallDto>();
            CreateMap<Prestamo, PrestamoBodyDto>().ReverseMap();


        }
    }
}

using AutoMapper;
using Jazani.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Libros.Profiles
{
    public class LibroProfile : Profile
    {
        public LibroProfile()
        {
            CreateMap<Libro, LibroDto>();

            CreateMap<Libro, LibroMediumDto>();
            CreateMap<Libro, LibroSmallDto>();

            CreateMap<Libro, LibroBodyDto>().ReverseMap();


        }
    }
}

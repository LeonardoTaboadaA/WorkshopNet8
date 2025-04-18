using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jazani.Domain.Models;

namespace Jazani.Application.Dtos.Editoriales.Profiles
{
    public class EditorialProfile : Profile
    {
        public EditorialProfile()
        {
            CreateMap<Editorial, EditorialSmallDto>();
            CreateMap<Editorial, EditorialDto>();
            CreateMap<Editorial, EditorialBodyDto>().ReverseMap();


        }
    }
}

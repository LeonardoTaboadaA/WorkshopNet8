using AutoMapper;
using Jazani.Application.Dtos.Editoriales;
using Jazani.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Dtos.Solicitantes.Profiles
{
    public class SolicitanteProfile : Profile
    {
        public SolicitanteProfile()
        {
            CreateMap<Solicitante, SolicitanteSmallDto>();
            CreateMap<Solicitante, SolicitanteDto>();
            CreateMap<Solicitante, SolicitanteBodyDto>().ReverseMap();
        }
    }
}

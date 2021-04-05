using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ProjetoNegocie.Contratos.Models;
using ProjetoNegocie.Negocio.Dominio;

namespace ProjetoNegocie.DAL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Endereco, EnderecoDTO>()
                .ReverseMap()
                .EqualityComparison( ( d, e ) => d.Id == e.Id );
        }

    }
}

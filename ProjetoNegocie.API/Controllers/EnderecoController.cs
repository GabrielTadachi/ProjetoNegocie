using System;
using System.Linq;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoNegocie.Contratos.Models;
using ProjetoNegocie.DAL.Data;
using ProjetoNegocie.Negocio.Dominio;

namespace ProjetoNegocie.API.Controllers
{
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EnderecoController( DataContext context, IMapper mapper )
        {
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet( ApiRoutes.Endereco.GetFromDB )]
        public IActionResult GetEnderecoFromDB( string cep )
        {
            try
            {
                var endereco = this._context.Enderecos.SingleOrDefault( e => e.Cep.Replace( "-", "" ) == cep.Replace( "-", "" ) );

                if( endereco != null && endereco.IsValid() )
                {
                    var enderecoDTO = this._mapper.Map<EnderecoDTO>( endereco );
                    return this.Ok( enderecoDTO );
                }
            }
            catch( Exception ex )
            {
                return this.Problem( $"Ocorreu um erro inesperado! Detalhes: {ex.Message}" );
            }

            return this.Problem( "Endereço não cadastrado no Banco de Dados!" );
        }

        [HttpGet( ApiRoutes.Endereco.GetFromAPI )]
        public IActionResult GetEnderecoFromAPI( string cep )
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri( "https://viacep.com.br/" );
                client.DefaultRequestHeaders.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

                var response = client.GetAsync( $"/ws/{cep}/json/" ).Result;

                if( response.IsSuccessStatusCode )
                {
                    var endereco = JsonConvert.DeserializeObject<Endereco>( response.Content.ReadAsStringAsync().Result );

                    if( endereco.IsValid() )
                    {
                        var enderecoDTO = this._mapper.Map<EnderecoDTO>( endereco );
                        return this.Ok( enderecoDTO );
                    }
                }
            }
            catch( Exception ex )
            {
                return this.Problem( $"Ocorreu um erro inesperado! Detalhes: {ex.Message}" );
            }

            return this.Problem( "Endereço não encontrado!" );
        }

        [HttpPost( ApiRoutes.Endereco.PostDB )]
        public IActionResult Post( EnderecoDTO dto )
        {
            try
            {
                if( this._context.Enderecos.SingleOrDefault( e => e.Cep.Replace( "-", "" ) == dto.Cep.Replace( "-", "" ) ) != null )
                    return this.Problem( "Endereço já existe no Banco de Dados!" );

                var endereco = this._mapper.Map<Endereco>( dto );

                this._context.Enderecos.Add( endereco );
                this._context.SaveChanges();

                return this.Ok();
            }
            catch( Exception ex )
            {
                return this.Problem( $"Ocorreu um erro inesperado! Detalhes: {ex.Message}" );
            }
        }

    }
}

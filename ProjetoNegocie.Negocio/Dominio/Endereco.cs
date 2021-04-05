using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoNegocie.Negocio.Dominio
{
    [Table( "app_negocie_endereco" )]
    public class Endereco
    {
        [Key]
        [Column( "id" )]
        public long Id { get; set; }

        [Column( "cep" )]
        public string Cep { get; set; }

        [Column( "logradouro" )]
        public string Logradouro { get; set; }

        [Column( "complemento" )]
        public string Complemento { get; set; }

        [Column( "bairro" )]
        public string Bairro { get; set; }

        [Column( "localidade" )]
        public string Localidade { get; set; }

        [Column( "uf" )]
        public string UF { get; set; }

        [Column( "ibge" )]
        public string IBGE { get; set; }

        [Column( "gia" )]
        public string GIA { get; set; }

        [Column( "ddd" )]
        public int DDD { get; set; }

        [Column( "siafi" )]
        public string SIAFI { get; set; }

        public bool IsValid()
        {
            return this.Cep != null && this.Logradouro != null && this.Complemento != null && this.Bairro != null && this.Localidade != null && this.UF != null && this.IBGE != null && this.GIA != null && this.DDD != 0 && this.SIAFI != null;
        }
    }
}

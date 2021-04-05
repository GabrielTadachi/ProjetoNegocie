using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjetoNegocie.Negocio.Dominio;

namespace ProjetoNegocie.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext( DbContextOptions<DataContext> options ) :
           base( options )
        {
        }

        public virtual DbSet<Endereco> Enderecos { get; set; }

    }
}

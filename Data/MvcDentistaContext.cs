using Microsoft.EntityFrameworkCore;

using MvcDentista.Models;


namespace MvcDentista.Data

{

    public class MvcDentistaContext : DbContext

    {

        public MvcDentistaContext(DbContextOptions<MvcDentistaContext> options)

            : base(options)

        {

        }


        public DbSet<Paciente> Paciente { get; set; }

    }

}
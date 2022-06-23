using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcDentista.Data;
using System;
using System.Linq;


namespace MvcDentista.Models

{

    public static class SeedData

    {

        public static void Initialize(IServiceProvider serviceProvider)

        {

            using (var context = new MvcDentistaContext(

                serviceProvider.GetRequiredService<

                    DbContextOptions<MvcDentistaContext>>()))

            {

                // Look for any movies.

                if (context.Paciente.Any())

                {

                    return;   // DB has been seeded

                }


                context.Paciente.AddRange(

                    new Paciente

                    {

                        Nombre = "Juan",
                        Apellido = "Pintos",
                        FechaAsistencia = DateTime.Parse("22-5-2022"),
                        Domicilio = "Av. Piedrabuena 3200",
                        Localidad="CABA",
                        Profesion = "Carpintero",
                        Edad = 40

                    },


                    new Paciente

                    {

                        Nombre = "Gabriel",
                        Apellido = "Fernandez",
                        FechaAsistencia = DateTime.Parse("24-5-2022"),
                        Domicilio = "Av. Eva Peron 5090",
                        Localidad = "CABA",
                        Profesion = "Cerrajero",
                        Edad = 47

                    },


                    new Paciente

                    {

                        Nombre = "Pedro",
                        Apellido = "Paz",
                        FechaAsistencia = DateTime.Parse("25-5-2022"),
                        Domicilio = "Calle Falsa 123",
                        Localidad = "Buenos Aires",
                        Profesion = "Programador",
                        Edad = 30

                    },


                    new Paciente

                    {

                        Nombre = "Miguel",
                        Apellido = "Lopez",
                        FechaAsistencia = DateTime.Parse("28-5-2022"),
                        Domicilio = "Av. Rivadavia 3310",
                        Localidad = "CABA",
                        Profesion = "Albañil",
                        Edad = 34

                    }

                );

                context.SaveChanges();

            }

        }

    }

}

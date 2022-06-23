using System;
using System.ComponentModel.DataAnnotations;


namespace MvcDentista.Models
{
    public class Paciente

    {

        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }


        [StringLength(60, MinimumLength = 3)]
        public string Apellido { get; set; }


        [Display(Name = "Fecha de Asistencia"), DataType(DataType.DateTime)]
        public DateTime FechaAsistencia { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string Domicilio { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string Localidad { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(5)]
        public string Profesion { get; set; }

        
        public int Edad { get; set; }



    }

}


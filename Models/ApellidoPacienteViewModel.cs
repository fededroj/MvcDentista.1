using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcDentista.Models
{
    public class ApellidoPacienteViewModel
    {
        public List<Paciente> Pacientes { get; set; }
        public SelectList Apellido { get; set; }
        public string ApellidoPaciente { get; set; }
        public string SearchString { get; set; }
    }
}

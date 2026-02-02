using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPenas.Domain.Entities
{
    public class Persona
    {
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string NIF { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public bool ConAntecedentes { get; set; }
        
    }
}

using CalculadoraPenas.Domain.Enums;

namespace CalculadoraPenas.Domain.Entities
{
    public class Delito
    {
        public TiposDelito TipoDelito { get; set; }

        public GravedadDelito GravedadDelito { get; set; }
        
    }
}

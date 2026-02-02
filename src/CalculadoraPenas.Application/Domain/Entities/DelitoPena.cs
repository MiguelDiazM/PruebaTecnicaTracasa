using CalculadoraPenas.Domain.Enums;

namespace CalculadoraPenas.Domain.Entities
{
    public class DelitoPena
    {
        public Pena? PenaLeve { get; set; }    

        public Pena? PenaModerada { get; set; }

        public Pena? PenaGrave { get; set; }

    }
}

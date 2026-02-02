using CalculadoraPenas.Domain.Entities;

namespace CalculadoraPenas.Application.Services
{
    public interface ICalculadoraPenasService
    {
        /// <summary>
        /// Calcula la pena en años en base a los delitos y si tiene antecedentes
        /// </summary>
        public Pena CalcularPena(List<Delito> delitos);

        /// <summary>
        /// Dada una fecha de entrada en prisión calcula la fecha de salida en base a los delitos y si tiene antecedentes
        /// 
        public DateTime CalcularFechaSalida(DateTime fechaEntrada, List<Delito> delitos, bool conAntecedentes);
    }
}

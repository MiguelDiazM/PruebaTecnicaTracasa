using CalculadoraPenas.Application.Services;
using CalculadoraPenas.Domain.Entities;
using CalculadoraPenas.Domain.Enums;
using FluentAssertions;

namespace CalculadoraPenas.Test.Application.Services
{
    public class CalculadoraPenasServiceTest
    {
        private readonly CalculadoraPenasService _calculadoraPenasService;

        public CalculadoraPenasServiceTest()
        {
            _calculadoraPenasService = new CalculadoraPenasService();
        }

        [Fact]
        public void CalcularPena_SinDelitos_DebeDevolverCero()
        {
            // Arrange
            var delitos = new List<Delito>();

            // Act
            Pena penaCalculada = _calculadoraPenasService.CalcularPena(delitos);

            // Assert
           penaCalculada.Años.Should().Be(0);
           penaCalculada.Meses.Should().Be(0);
        }

        [Fact]
        public void CalcularFechaSalida_SinDelitos_DebeDevolverFechaEntrada()
        {
            // Arrange
            List<Delito> delitos = new();
            DateTime fechaEntrada = new(2025, 1, 15);
            bool conAntecedentes = false;

            // Act
            DateTime fechaSalida = _calculadoraPenasService.CalcularFechaSalida(fechaEntrada, delitos, conAntecedentes);

            // Assert
            fechaSalida.Should().Be(fechaEntrada);
        }

        [Fact]
        public void CalcularPena_ConDelitosEjemplo1_DebeDevolverPenaTotal()
        {
            // Arrange
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Asalto, GravedadDelito = GravedadDelito.Moderada }
            ];

            // Act
            Pena penaCalculada = _calculadoraPenasService.CalcularPena(delitos);

            // Assert
            penaCalculada.Años.Should().Be(4);
            penaCalculada.Meses.Should().Be(0);
        }

        [Fact]
        public void CalcularFechaSalida_ConDelitosEjemplo1_DebeDevolverFechaSalida()
        {
            // Arrange
            DateTime fechaEntrada = new(2025, 1, 15);
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Asalto, GravedadDelito = GravedadDelito.Moderada }
            ];

            // Act
            DateTime fechaSalida = _calculadoraPenasService.CalcularFechaSalida(fechaEntrada, delitos, conAntecedentes: false);

            // Assert
            fechaSalida.Should().Be(new DateTime(2029, 1, 15));
        }   


        [Fact]
        public void CalcularPena_ConDelitosEjemplo2_DebeDevolverPenaTotal()
        {
            // Arrange
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Asalto, GravedadDelito = GravedadDelito.Moderada },
                new Delito { TipoDelito = TiposDelito.Homicidio, GravedadDelito = GravedadDelito.Moderada }
            ];

            // Act
            Pena penaCalculada = _calculadoraPenasService.CalcularPena(delitos);

            // Assert
            penaCalculada.Años.Should().Be(14);
            penaCalculada.Meses.Should().Be(0);
        }

        [Fact]
        public void CalcularFechaSalida_ConDelitosEjemplo2_DebeDevolverFechaSalida()
        {
            // Arrange
            DateTime fechaEntrada = new(2025, 1, 15);
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Asalto, GravedadDelito = GravedadDelito.Moderada },
                new Delito { TipoDelito = TiposDelito.Homicidio, GravedadDelito = GravedadDelito.Moderada }
            ];

            // Act
            DateTime fechaSalida = _calculadoraPenasService.CalcularFechaSalida(fechaEntrada, delitos, conAntecedentes: false);

            // Assert
            fechaSalida.Should().Be(new DateTime(2039, 1, 15));
        }

        [Fact]
        public void CalcularPena_ConDelitosEjemplo3_DebeDevolverPenaTotal()
        {
            // Arrange
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Hurto, GravedadDelito = GravedadDelito.Leve },
                new Delito { TipoDelito = TiposDelito.Fraude, GravedadDelito = GravedadDelito.Leve }
            ];

            // Act
            Pena penaCalculada = _calculadoraPenasService.CalcularPena(delitos);

            // Assert
            penaCalculada.Años.Should().Be(0);
            penaCalculada.Meses.Should().Be(6);
        }

        [Fact]
        public void CalcularFechaSalida_ConDelitosEjemplo3_DebeDevolverFechaSalida()
        {
            // Arrange
            DateTime fechaEntrada = new(2025, 1, 15);
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Hurto, GravedadDelito = GravedadDelito.Leve },
                new Delito { TipoDelito = TiposDelito.Fraude, GravedadDelito = GravedadDelito.Leve }
            ];

            // Act
            DateTime fechaSalida = _calculadoraPenasService.CalcularFechaSalida(fechaEntrada, delitos, conAntecedentes: false);

            // Assert
            fechaSalida.Should().Be(new DateTime(2025, 1, 15));
        }

        [Fact]
        public void CalcularPena_ConDelitosEjemplo4_DebeDevolverPenaTotal()
        {
            // Arrange
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Fraude, GravedadDelito = GravedadDelito.Grave },
                new Delito { TipoDelito = TiposDelito.Asalto, GravedadDelito = GravedadDelito.Grave },
                new Delito { TipoDelito = TiposDelito.Homicidio, GravedadDelito = GravedadDelito.Grave }
            ];

            // Act
            Pena penaCalculada = _calculadoraPenasService.CalcularPena(delitos);

            // Assert
            penaCalculada.Años.Should().Be(30);
            penaCalculada.Meses.Should().Be(0);
        }

        [Fact]
        public void CalcularFechaSalida_ConDelitosEjemplo4_DebeDevolverFechaSalida()
        {
            // Arrange
            DateTime fechaEntrada = new(2025, 1, 15);
            List<Delito> delitos =
            [
                new Delito { TipoDelito = TiposDelito.Fraude, GravedadDelito = GravedadDelito.Grave },
                new Delito { TipoDelito = TiposDelito.Asalto, GravedadDelito = GravedadDelito.Grave },
                new Delito { TipoDelito = TiposDelito.Homicidio, GravedadDelito = GravedadDelito.Grave }
            ];

            // Act
            DateTime fechaSalida = _calculadoraPenasService.CalcularFechaSalida(fechaEntrada, delitos, conAntecedentes: false);

            // Assert
            fechaSalida.Should().Be(new DateTime(2055, 1, 15));
        }

       


       


       
    }
}

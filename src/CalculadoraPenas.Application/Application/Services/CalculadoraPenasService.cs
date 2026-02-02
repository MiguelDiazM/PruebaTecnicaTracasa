using CalculadoraPenas.Domain.Entities;
using CalculadoraPenas.Domain.Enums;
using System.Data;

namespace CalculadoraPenas.Application.Services
{
    public class CalculadoraPenasService : ICalculadoraPenasService
    {
        private readonly Dictionary<TiposDelito, DelitoPena> penasPorTipoDelito = new Dictionary<TiposDelito, DelitoPena>
        {
            {
                TiposDelito.Hurto, new DelitoPena
                { PenaLeve = new Pena { Meses = 3},
                  PenaModerada = new Pena { Meses = 12},
                  PenaGrave = new Pena { Meses = 18}
                }
            },
            {
                TiposDelito.Robo, new DelitoPena
                { PenaLeve = new Pena { Años = 1},
                  PenaModerada = new Pena { Años = 1, Meses = 6},
                  PenaGrave = new Pena { Años = 3}
                }
            },
            {
                TiposDelito.Asalto, new DelitoPena
                { PenaLeve = new Pena { Años = 3},
                  PenaModerada = new Pena { Años = 4},
                  PenaGrave = new Pena { Años = 6}
                }
            },
            {
                TiposDelito.Fraude, new DelitoPena
                { PenaLeve = new Pena { Meses = 3},
                  PenaModerada = new Pena { Años = 1, Meses = 6},
                  PenaGrave = new Pena { Años = 5}
                }
            },
            {
                TiposDelito.Homicidio, new DelitoPena
                {
                  PenaModerada = new Pena { Años = 10},
                  PenaGrave = new Pena { Años = 20}
                }
            }
         };

        public DateTime CalcularFechaSalida(DateTime fechaEntrada, List<Delito> delitos, bool conAntecedentes)
        {
            throw new NotImplementedException();
        }

        public Pena CalcularPena(List<Delito> delitos)
        {
            foreach(Delito delito in delitos)
            {
                Console.WriteLine(delito.ToString());
                return new Pena();
            }
        }
    } 
}

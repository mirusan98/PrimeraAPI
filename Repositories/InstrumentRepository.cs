using System.Collections.Generic;

namespace PrimeraAPI.Repositories
{
    public class InstrumentRepository
    {
        public List<string> Instruments { get; set; }   

        public InstrumentRepository()
        {
            Instruments = new List<string> { "Guitarra", "Batería", "Piano" };
        }
    }
}

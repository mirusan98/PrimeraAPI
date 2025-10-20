using Microsoft.AspNetCore.Mvc;
using PrimeraAPI.Repositories;

namespace PrimeraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly InstrumentRepository _repository;

        public InstrumentsController()
        {
            _repository = new InstrumentRepository();
        }

        // GET: api/instruments
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_repository.Instruments);
        }

        // POST: api/instruments
        [HttpPost]
        public ActionResult<string> Post([FromBody] string instrumento)
        {
            if (string.IsNullOrWhiteSpace(instrumento))
                return BadRequest("No puede estar vacio");

            _repository.Instruments.Add(instrumento);
            return Ok($"Se agrego el instrumento: {instrumento}");
        }

        // PUT: api/instruments/{index}
        [HttpPut("{index}")]
        public ActionResult<string> Put(int index, [FromBody] string instrumento)
        {
            if (index < 0 || index >= _repository.Instruments.Count)
                return NotFound($"No existe un instrumento en la posicion {index}.");

            _repository.Instruments[index] = instrumento;
            return Ok($"Instrumento en posición {index} actualizado a: {instrumento}");
        }

        // DELETE: api/instruments/{index}
        [HttpDelete("{index}")]
        public ActionResult<string> Delete(int index)
        {
            if (index < 0 || index >= _repository.Instruments.Count)
                return NotFound($"No existe un instrumento en la posición {index}.");

            string borrado = _repository.Instruments[index];
            _repository.Instruments.RemoveAt(index);
            return Ok($"Instrumento eliminado: {borrado}");
        }
    }
}

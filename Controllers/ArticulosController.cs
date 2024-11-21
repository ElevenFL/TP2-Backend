using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorio;
using ArticulosAPI.Dto;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IRepositorio _articuloRepositorio;

        public ArticulosController(IRepositorio articuloRepositorio)
        {
            _articuloRepositorio = articuloRepositorio;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDto>>> GetArticulos()
        {
            var articulos = await _articuloRepositorio.GetArticulos();
            return Ok(articulos);
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDto>> GetArticulo(int id)
        {
            var articulo = await _articuloRepositorio.GetArticuloById(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, ArticuloDto articulo)
        {
            if (articulo == null)
            {
                return BadRequest("El ID del artículo esta mal");
            }

            var articuloActualizado = await _articuloRepositorio.CrearOActualizar(articulo, id);

            if (articuloActualizado == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Articulos
        [HttpPost]
        public async Task<ActionResult<ArticuloDto>> PostArticulo(ArticuloDto articulo)
        {
            if (articulo == null)
            {
                return BadRequest("El artículo no puede ser nulo");
            }

            var nuevoArticulo = await _articuloRepositorio.CrearOActualizar(articulo);
            return Ok(nuevoArticulo);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var eliminado = await _articuloRepositorio.EliminarArticulo(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

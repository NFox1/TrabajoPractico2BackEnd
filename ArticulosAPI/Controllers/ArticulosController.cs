using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticulosAPI.Data;
using ArticulosAPI.Modelos;
using ArticulosAPI.Repositorios;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IRepositorioArticulo _repositorio;

        public ArticulosController(IRepositorioArticulo repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/Articulos
        [HttpGet]
        public ActionResult<IEnumerable<Articulo>> GetArticulos()
        {
            var articulos = _repositorio.ObtenerTodos();
            return Ok(articulos);
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public ActionResult<Articulo> GetArticulo(int id)
        {
            try
            {
                var articulo = _repositorio.ObtenerPorId(id);
                return Ok(articulo);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public IActionResult PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest();
            }

            try
            {
                _repositorio.Actualizar(articulo);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: api/Articulos
        [HttpPost]
        public ActionResult<Articulo> PostArticulo(Articulo articulo)
        {
            _repositorio.Agregar(articulo);
            return CreatedAtAction("GetArticulo", new { id = articulo.Id }, articulo);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteArticulo(int id)
        {
            try
            {
                _repositorio.Eliminar(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
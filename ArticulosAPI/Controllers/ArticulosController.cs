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
using AutoMapper;
using ArticulosAPI.Dto;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IRepositorioArticulo _repositorio;
        private readonly IMapper _mapper;

        public ArticulosController(IRepositorioArticulo repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: api/Articulos
        [HttpGet]
        public ActionResult<IEnumerable<ArticuloDto>> GetArticulos()
        {
            var articulos = _repositorio.ObtenerTodos();
            var articuloDtos = _mapper.Map<IEnumerable<ArticuloDto>>(articulos);
            return Ok(articuloDtos);
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public ActionResult<ArticuloDto> GetArticulo(int id)
        {
            try
            {
                var articulo = _repositorio.ObtenerPorId(id);
                var articuloDto = _mapper.Map<ArticuloDto>(articulo);
                return Ok(articuloDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public IActionResult PutArticulo(int id, ArticuloDto articuloDto)
        {
            if (id != articuloDto.Id)
            {
                return BadRequest();
            }

            try
            {
                var articulo = _mapper.Map<Articulo>(articuloDto);
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
        public ActionResult<ArticuloDto> PostArticulo(ArticuloDto articuloDto)
        {
            var articulo = _mapper.Map<Articulo>(articuloDto);
            _repositorio.Agregar(articulo);
            return CreatedAtAction("GetArticulo", new { id = articulo.Id }, articuloDto);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("gerente")]
    public class GerenteController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GerenteController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadGerenteByID), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IActionResult ReadGerente()
        {
            return Ok(_context.Gerentes);
        }

        [HttpGet("{id}")]
        public IActionResult ReadGerenteByID(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _mapper.Map<ReadGerenteDto>(gerente);
            return Ok(gerente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id); 
            if (gerente == null)
            {
                return NotFound();
            }
            _context.Gerentes.Remove(gerente);
            return NoContent();
        }
    }
}

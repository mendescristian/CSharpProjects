using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("endereco")]
    public class EnderecoController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public EnderecoController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadEnderecoByID), new { Id = endereco.Id }, endereco);

        }

        [HttpGet]
        public IActionResult ReadEndereco()
        {
            var endereco = _context.Endereco;
            _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(endereco);
        }

        [HttpGet("{id}")]
        public IActionResult ReadEnderecoByID(int id)
        {
            var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                NotFound();
            }
            _mapper.Map<ReadEnderecoDto>(endereco);
            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                NotFound();
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveEndereco(int id)
        {
            var endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

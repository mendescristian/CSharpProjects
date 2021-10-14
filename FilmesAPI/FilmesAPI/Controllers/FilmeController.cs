using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context; //Adicionando o FilmeContext para ler no banco.

        public FilmeController(FilmeContext context) //Iniciando o FilmeContext através de um construtor.
        {
            _context = context;
        }
 

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme); //Utilizando o DBSet "Filmes" para ADICIONAR um filme no banco.
            _context.SaveChanges(); //Salvando a adição do filme no banco.
            return CreatedAtAction(nameof(RetornarFilmeById), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RetornarFilme()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RetornarFilmeById(int id)
        {
            Filme filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme.Id != null)
            {
                return Ok(filme);
            }
            else
            {
                return NotFound();
            }
        }

    }
}

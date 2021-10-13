using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RetornarFilmeById), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RetornarFilme()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RetornarFilmeById(int id)
        {
            Filme filme =  filmes.FirstOrDefault(filme => filme.Id == id);
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

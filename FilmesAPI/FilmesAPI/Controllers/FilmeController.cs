using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using AutoMapper;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context; //Adicionando o FilmeContext para ler no banco.
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper) //Iniciando o FilmeContext e o Mapper através de um construtor.
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto); //Transformando o filmeDto em Filme.
            _context.Filmes.Add(filme); //Utilizando o DBSet "Filmes" para ADICIONAR um filme no banco.
            _context.SaveChanges(); //Salvando a adição do filme no banco.
            return CreatedAtAction(nameof(RetornarFilmeById), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RetornarFilme()
        {
            return Ok(_context.Filmes); //Retornando os filmes do banco de dados. 
        }

        [HttpGet("{id}")]
        public IActionResult RetornarFilmeById(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); //Filtrando no banco de dados o  ID informado no caminho. 

            
            if (filme.Id != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDto>(filme); //Mapeando os filmes para o Dto
                return Ok(filmeDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto updateFilmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); //Filtrando o filme por ID do banco de dados. 
            if(filme == null)
            {
                return NotFound();
            }

            _mapper.Map(updateFilmeDto, filme); //Passando as alterações informadas pelo Json para o banco de dados.
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); //Filtrando por ID
            _context.Filmes.Remove(filme); //Removendo o filme filtrado
            _context.SaveChanges();
            return NoContent();
        }
    }
}

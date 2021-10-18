using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O Nome fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }
    }
}

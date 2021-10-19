using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }
    }
}

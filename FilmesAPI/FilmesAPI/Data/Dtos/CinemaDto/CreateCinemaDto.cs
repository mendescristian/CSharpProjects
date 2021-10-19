using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.CinemaDto
{
    public class CreateCinemaDto
    {
        public string NomeFantasia { get; set; }
        public int EnderecoID { get; set; }
        public int GerenteID { get; set; }
    }
}

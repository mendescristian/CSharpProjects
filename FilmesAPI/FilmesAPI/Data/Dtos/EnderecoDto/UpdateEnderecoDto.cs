using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.EnderecoDto
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Número é obrigatório.")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string Bairro { get; set; }
    }
}

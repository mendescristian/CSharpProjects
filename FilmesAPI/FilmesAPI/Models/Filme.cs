using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário inserir o titulo!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "É necessário inserir o diretor!")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range(1,300, ErrorMessage = "Duração invalida.")]
        public int Duracao { get; set; }
    }
}

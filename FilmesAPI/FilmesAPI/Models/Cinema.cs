using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome fantasia é obrigatório.")]
        public string NomeFantasia { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoID { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteID { get; set; }


    }
}

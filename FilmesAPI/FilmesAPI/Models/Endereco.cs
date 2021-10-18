﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Número é obrigatório.")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório.")]
        public string Bairro { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}

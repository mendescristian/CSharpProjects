﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos.EnderecoDto
{
    public class ReadEnderecoDto
    {
 
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public Cinema Cinema { get; set; }
    }
}
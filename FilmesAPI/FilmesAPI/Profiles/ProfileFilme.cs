using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.CinemaDto;
using FilmesAPI.Data.Dtos.EnderecoDto;
using FilmesAPI.Data.Dtos.GerenteDto;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class ProfileFilme : Profile
    {
        public ProfileFilme()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();

            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema,ReadCinemaDto>();
            CreateMap<UpdateCinemaDto, Cinema>();

            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>();

            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
            CreateMap<UpdateGerenteDto, Gerente>();
        }
    }
}

using AutoMapper;
using CiResultAPI.Models;
using CiResultAPI.Models.DTOs;
using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Profiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultDto>();
            CreateMap<ResultDtoForCreating, Result>();
        }
    }
}

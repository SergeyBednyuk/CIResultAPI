﻿using AutoMapper;
using CiResultAPI.Models;
using CiResultAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiResultAPI.Profiles
{
    public class ErrorImageProfile : Profile
    {
        public ErrorImageProfile()
        {
            CreateMap<ErrorImage, ErrorImageDto>();
        }
    }
}

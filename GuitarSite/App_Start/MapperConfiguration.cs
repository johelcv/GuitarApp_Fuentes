using AutoMapper;
using Guitar.Entities;
using GuitarSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarSite.App_Start
{
    public class MapperConfiguration
    {
        public static void Map()
        {
            Mapper.CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(prod => prod.Name))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(prod => prod.Description))
                .ForMember(dest => dest.Body, opts => opts.MapFrom(prod => prod.Body))
                .ForMember(dest => dest.Bridge, opts => opts.MapFrom(prod => prod.Bridge))
                .ForMember(dest => dest.Neck, opts => opts.MapFrom(prod => prod.Neck))
                .ForMember(dest => dest.Pickup, opts => opts.MapFrom(prod => prod.Pickup))
                .ForMember(dest => dest.ImgProject, opts => opts.MapFrom(prod => prod.ImgProject));
        }
    }
}
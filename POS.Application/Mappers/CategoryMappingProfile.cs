﻿using AutoMapper;
using POS.Application.DTOs.Request;
using POS.Application.DTOs.Response;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases.Response;
using POS.Utilities.Static;

namespace POS.Application.Mappers;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryResponseDto>()
            .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
            .ReverseMap();

        CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
            .ReverseMap();

        CreateMap<CategoryRequestDto, Category>()
            .ReverseMap();

        CreateMap<Category, CategorySelectResponseDto>()
            .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Id))
            .ReverseMap();
    }
}

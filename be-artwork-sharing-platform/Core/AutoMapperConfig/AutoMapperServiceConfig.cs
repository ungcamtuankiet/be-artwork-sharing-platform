﻿using AutoMapper;
using be_artwork_sharing_platform.Core.Dtos.Artwork;
using be_artwork_sharing_platform.Core.Dtos.Category;
using be_artwork_sharing_platform.Core.Entities;

namespace be_artwork_sharing_platform.Core.AutoMapperConfig
{
    public class AutoMapperServiceConfig : Profile
    {
        public AutoMapperServiceConfig()
        {
            //Category
            CreateMap<Category, CategoryDto>();

            //Artwork
        }
    }
}

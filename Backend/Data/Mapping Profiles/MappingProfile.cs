﻿using AutoMapper;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;

namespace Merchanmusic.Data.Mapping_Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientUpdateDto, Client>();
            CreateMap<SellerUpdateDto, Seller>();
            CreateMap<SaleOrderDto, SaleOrder>();
            CreateMap<SaleOrderLineDto, SaleOrderLine>();
        }
    }
}

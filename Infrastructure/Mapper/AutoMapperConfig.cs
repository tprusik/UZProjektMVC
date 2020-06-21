using AutoMapper;
using Core.Domain;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Address, AddressDTO>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}

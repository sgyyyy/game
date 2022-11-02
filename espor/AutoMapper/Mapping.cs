using AutoMapper;
using EntityLayer;
using espor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace espor.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TournamentsModel, Tournaments>().ReverseMap();
            CreateMap<ContactModel, Contact>().ReverseMap();
        }
    }
}

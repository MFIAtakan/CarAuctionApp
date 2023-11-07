using AutoMapper;
using Carties.DTOs;
using Carties.Entities;

namespace Carties.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auction, AuctionDTO>().IncludeMembers(x => x.Item);
            CreateMap<Item, AuctionDTO>();
            CreateMap<CreateAuctionDTO, Auction>()
                .ForMember(d => d.Item, o => o.MapFrom(s => s));
            CreateMap<CreateAuctionDTO, Item>();
            
        }
    }
}

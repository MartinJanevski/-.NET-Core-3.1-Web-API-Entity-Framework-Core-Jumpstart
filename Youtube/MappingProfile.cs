using AutoMapper;
using Youtube.Dtos.Character;
using Youtube.Models;

namespace Youtube
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {

            {
                CreateMap<Character, GetCharacterDto>();
                CreateMap<AddCharacterDto, Character>();

            }
        }
    }
}
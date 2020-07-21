using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Dtos.Character;
using Youtube.Models;

namespace Youtube.Services.CharacterSrvice
{
    public class CharacterService : ICharacterService
    {

        
        public static List<Character> characters = new List<Character> {
            new Character(),
            new Character{ Id =1, Name="Sam" }
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServeceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServeceResponse<List<GetCharacterDto>> serveceResponse = new ServeceResponse<List<GetCharacterDto>>();
            Character character= (_mapper.Map<Character>(newCharacter));
            character.Id = characters.Max(c=>c.Id) + 1;
            characters.Add(character);
            serveceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serveceResponse;
        }

        public async Task<ServeceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServeceResponse<List<GetCharacterDto>> serveceResponse = new ServeceResponse<List<GetCharacterDto>>();
            serveceResponse.Data = (characters.Select(c=> _mapper.Map<GetCharacterDto>(c))).ToList();
            return serveceResponse;
        }

        public async Task<ServeceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServeceResponse<GetCharacterDto> serveceResponse = new ServeceResponse<GetCharacterDto>();
            serveceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serveceResponse;
        }

        Task<ServeceResponse<List<GetCharacterDto>>> ICharacterService.AddCharacter(AddCharacterDto newCharacter)
        {
            throw new NotImplementedException();
        }
    }
}

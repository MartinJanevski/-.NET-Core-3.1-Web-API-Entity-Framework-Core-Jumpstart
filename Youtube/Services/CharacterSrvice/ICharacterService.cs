using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Dtos.Character;
using Youtube.Models;

namespace Youtube.Services.CharacterSrvice
{
   public  interface ICharacterService
    {
        Task<ServeceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServeceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServeceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    }
}

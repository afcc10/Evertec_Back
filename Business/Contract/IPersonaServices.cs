using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IPersonaServices
    {
        Task<Response<List<PersonaDto>>> GetPersona();

        Task<Response<bool>> CreatePersona(PersonaDto persona);

        Task<Response<PersonaDto>> GetByIdPersona(int id);

        Task<Response<bool>> UpdatePersona(PersonaDto persona);

        Task<Response<bool>> DeleteByIdPersona(int id);
    }
}

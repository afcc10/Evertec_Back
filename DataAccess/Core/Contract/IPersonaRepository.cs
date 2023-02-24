using Common.Utilities.Services;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IPersonaRepository
    {
        Task<Response<Object>> GetPersona();

        Task<Response<bool>> CreatePersona(PersonaDto persona);

        Task<Response<PersonaDto>> GetByIdPersona(int id);

        Task<Response<bool>> UpdatePersona(PersonaDto persona);

        Task<Response<bool>> DeleteByIdPersona(int id);
    }
}

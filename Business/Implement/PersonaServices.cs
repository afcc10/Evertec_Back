using AutoMapper;
using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class PersonaServices : IPersonaServices
    {
        #region Propierties
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public PersonaServices(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        
        #endregion

        public async Task<Response<List<PersonaDto>>> GetPersona()
        {
            var result = await _personaRepository.GetPersona();

            Response<List<PersonaDto>> response = new()
            {
                Status = result.Status,
                Message = result.Message,
                ObjectResponse = result.ObjectResponse != null ? _mapper.Map<List<PersonaDto>>(result.ObjectResponse)
                                    : null
            };

            return response;
        }

        public async Task<Response<bool>> UpdatePersona(PersonaDto student)
        {
            var result = await _personaRepository.UpdatePersona(student);
            return result;
        }

        public async Task<Response<bool>> CreatePersona(PersonaDto student)
        {
            var result = await _personaRepository.CreatePersona(student);
            return result;
        }

        public async Task<Response<bool>> DeleteByIdPersona(int id)
        {
            var result = await _personaRepository.DeleteByIdPersona(id);
            return result;
        }

        public async Task<Response<PersonaDto>> GetByIdPersona(int id)
        {
            var result = await _personaRepository.GetByIdPersona(id);
            return result;
        }
    }
}

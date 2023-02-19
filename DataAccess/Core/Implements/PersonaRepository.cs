using AutoMapper;
using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Implements
{
    public class PersonaRepository : IPersonaRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<PersonaRepository> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public PersonaRepository(DbCrudContext context,ILogger<PersonaRepository> logger, IMapper mapper)
        {
            this.context = context;
            this._logger = logger;
            _mapper = mapper;
        }
        
        #endregion

        #region Method
        public async Task<Response<Object>> GetPersona()
        {
            Response<Object> response = new();
            try
            {
                List<Models.Persona> query = await context.Persona.ToListAsync();

                response = new()
                {
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa),
                    ObjectResponse = query,
                    Status = true
                };                
                
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response<Object>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        public async Task<Response<bool>> UpdatePersona(PersonaDto _persona)
        {
            Response<bool> response = new();
            try
            {
                var persona = context.Persona.Where(x => x.Id == _persona.Id).FirstOrDefault();

                persona = _mapper.Map<Persona>(_persona);

                context.Update(persona);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateError)
                };
            }
        }

        public async Task<Response<bool>> CreatePersona(PersonaDto _persona)
        {
            Response<bool> response = new();
            try
            {
                Persona persona = new();

                persona = _mapper.Map<Persona>(_persona);

                context.Add(persona);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.CreateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.CreateError)
                };
            }
        }

        public async Task<Response<bool>> DeleteByIdPersona(int id)
        {
            Response<bool> response = new();
            try
            {
                var persona = context.Persona.Where(x => x.Id == id).FirstOrDefault();

                context.Remove(persona);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteError)
                };
            }
        }

        public async Task<Response<PersonaDto>> GetByIdPersona(int id)
        {
            Response<PersonaDto> response = new();
            try
            {
                var persona = context.Persona.Where(x => x.Id == id).FirstOrDefault();
                PersonaDto personaDto = new();

                personaDto = _mapper.Map<PersonaDto>(persona);

                response = new()
                {
                    Status = true,
                    ObjectResponse = personaDto,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<PersonaDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }
        #endregion
    }
}

using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_sqlLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        #region Propierties
        private readonly IPersonaServices Service;
        private readonly ILogger<PersonaController> _logger;
        #endregion

        #region Constructor
        public PersonaController(IPersonaServices service, ILogger<PersonaController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        /// <summary>
        /// Obtener estudiantes
        /// </summary>
        /// <returns>Response model StudentDto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<PersonaDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<PersonaDto>>> Get()
        {
            Response<List<PersonaDto>> response;
            try
            {
                response = await Service.GetPersona();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<PersonaDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// crear estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Post(PersonaDto student)
        {
            Response<bool> response;
            try
            {
                response = await Service.CreatePersona(student);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// actualizar estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Update(PersonaDto student)
        {
            Response<bool> response;
            try
            {
                response = await Service.UpdatePersona(student);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// obtener estudiantes by id
        /// </summary>
        /// <returns>Response studentdto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Response<PersonaDto>), StatusCodes.Status200OK)]
        public async Task<Response<PersonaDto>> GetById(int id)
        {
            Response<PersonaDto> response;
            try
            {
                response = await Service.GetByIdPersona(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<PersonaDto>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// eliminar by id
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> DeleteById(int id)
        {
            Response<bool> response;
            try
            {
                response = await Service.DeleteByIdPersona(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }
    }
}

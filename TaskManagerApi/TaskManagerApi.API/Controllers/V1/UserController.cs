﻿using AutoMapper;
using TaskManagerApi.API.DataContracts.Requests;
using TaskManagerApi.API.DataContracts;
using TaskManagerApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using S = TaskManagerApi.Services.Model;

namespace TaskManagerApi.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region GET
        /// <summary>
        /// Comments and descriptions can be added to every endpoint using XML comments.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            var data = await _service.GetAsync(id);
       
            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<User> CreateUser([FromBody]UserCreationRequest value)
        {       
           
            //TODO: include exception management policy according to technical specifications
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.User == null)
                throw new ArgumentNullException("value.User");


            var data = await _service.CreateAsync(Mapper.Map<S.User>(value.User));

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;

        }
        #endregion

        #region PUT
        [HttpPut()]
        public async Task<bool> UpdateUser(User parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            return await _service.UpdateAsync(Mapper.Map<S.User>(parameter));
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<bool> DeleteDevice(string id)
        {
            return await _service.DeleteAsync(id);
        }
        #endregion
    }
}

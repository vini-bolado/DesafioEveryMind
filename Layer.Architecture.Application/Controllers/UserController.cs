﻿using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Layer.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _userService.Add(user));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserModel user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _userService.Update(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _userService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _userService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _userService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

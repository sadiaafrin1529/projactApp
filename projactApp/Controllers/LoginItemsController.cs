using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.OpenApi.Models;
using ProjectApp.Module;
using System.Runtime.Intrinsics.X86;
using System;

namespace ProjectApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginItemsController : ControllerBase
    {
       private static List<LoginItem> _users = new List<LoginItem>();
        [HttpGet("AllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_users);
        }

        [HttpPost("Create User")]
        public IActionResult Register([FromBody] LoginItem user)
        {
            if (UserExists(user.Id))
            {
                return BadRequest("Id is already in use.");
            }

            user.Id = _users.Count + 1;
            _users.Add(user);

            return Ok(user);
        }

        private bool UserExists(long id)
        {
            return _users.Any(u => u.Id == id);
        }
    }

   



        
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelapi.Config;
using hotelapi.Data;
using hotelapi.DTOs;
using hotelapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace hotelapi.Controllers.v1.auth
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly Utilies utilies;
        public AuthController(AppDbContext _context, Utilies _utilies)
        {
            context = _context;
            utilies = _utilies;
        }

        [HttpPost("Register")]
        [SwaggerOperation(
            Summary = "Register a new employee",
            Description = "This endpoint allows you to register a new employee in the system"
        )]
        [SwaggerResponse(200, "Employee registered successfully")]
        [SwaggerResponse(400, "Invalid request")]
        [SwaggerResponse(409, "Employee with the same identification number already exists")]


        public async Task<IActionResult> AuthRegister([FromBody] EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (context.Employees.Any(u => u.IdentificationNumber == employee.IdentificationNumber))
            {
                return Conflict("the employee already exists in our system");
            }

            employee.Password = utilies.EncryptSHA256(employee.Password);

            Employee _employee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IdentificationNumber = employee.IdentificationNumber,
                Email = employee.Email,
                Password = employee.Password
            };

            await context.Employees.AddAsync(_employee);
            await context.SaveChangesAsync();
            return Ok("successfully registered employee");
        }


        [HttpPost("Login")]
        [SwaggerOperation(
            Summary = "Login into the system",
            Description = "This endpoint allows you to login into the system using your email and password"
        )]
        [SwaggerResponse(200, "Logged in successfully")]
        [SwaggerResponse(401, "Email or password invalid")]
        
        public async Task<IActionResult> AuthLogin(EmployeeLoginDTO employeeLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeFound = await context.Employees.FirstOrDefaultAsync(i => i.Email == employeeLogin.Email);
            if (employeeFound == null)
            {
                return Unauthorized("Email invalido");
            }

            var passwordvalid = employeeFound.Password == utilies.EncryptSHA256(employeeLogin.Password);

            if (passwordvalid == false)
            {
                return Unauthorized("Password invalida");
            }

            //Aqui llamamos el metodo para crear el jwt
            var token = utilies.GenerateJwtToken(employeeFound);

            return Ok(token);
        }
    }
}
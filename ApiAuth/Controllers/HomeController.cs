using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Policy;

namespace ApiAuth.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("anonymus")]
    [AllowAnonymous]
    public string Anonymus() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authorize() => $"Autenticado -  {User.Identity.Name}";

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee, manager")]
    public string Employee() => "Funcionário";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => "Gerente";
}

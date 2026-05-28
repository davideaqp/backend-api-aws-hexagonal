using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAws.Controllers
{
    public class Accounts_1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

    //[ApiController, Route("accounts"), Authorize]
    //public class AccountsController : ControllerBase
    //{
    //    [HttpPost]
    //    public async Task<IActionResult> Create([FromBody] CreateAccountRequest dto)
    //    {
    //        var result = await _useCase.Execute(dto.ToCommand());
    //        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    //    }
    //}
}

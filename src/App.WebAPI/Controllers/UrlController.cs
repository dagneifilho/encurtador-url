using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Application.Interfaces;
using App.Application.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace App.WebAPI.Controllers
{
    [ApiController]
    [Route("url")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlAppService _appService;
        public UrlController(IUrlAppService appService)
        {
            _appService = appService;
        }
        [HttpPost("")]
        public async Task<IActionResult> EncurtarUrl(FiltroUrl filtroUrl)
        {
            if(ModelState.IsValid)
            {
                var result =  await _appService.Encurtar(filtroUrl);
                return Ok(result);
            }
            else 
            {
                var modelState = new ModelStateDictionary(ModelState);

                IEnumerable<string> errors = from state in modelState.Values
                                      from error in state.Errors
                                      select error.ErrorMessage;
                return StatusCode(412, errors.ToList());
            }   
        }
    }
}
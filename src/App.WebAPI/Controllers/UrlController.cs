using System;
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
        //TODO MELHORAR CONTROLLER
        [HttpPost("")]
        public async Task<IActionResult> EncurtarUrl(PostUrl postUrl)
        {
            if(ModelState.IsValid)
            {
                (string result, bool valido) = await _appService.Encurtar(postUrl);
                if (valido)
                    return Created("", result);
                return BadRequest();
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
        [HttpGet("{idUrl}")]
        public async Task<ActionResult> GetUrlOriginal(string idUrl)
        {
            var urlOriginal = await _appService.GetUrlOriginal(idUrl);
            if (urlOriginal == null)
                return NoContent();
            return Ok(urlOriginal);
        }
    }
}
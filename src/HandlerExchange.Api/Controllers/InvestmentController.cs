using System;
using System.Threading.Tasks;
using HandlerExchange.Core.Authorization;
using HandlerExchange.Core.DTO.Investment;
using HandlerExchange.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HandlerExchange.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")] 
    public class InvestmentController : Controller
    {
        private readonly IInvestmentService _investmentService;
        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpPost]
        public async  Task<IActionResult> Post(RequestInvestmentDto dto)
        {
            await _investmentService.Add(dto);
            return CreatedAtAction(nameof(Get), new {dto.Id}, null);
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult> Get(Guid id) => Ok((await _investmentService.GetAsync(id)));
    }
    
}
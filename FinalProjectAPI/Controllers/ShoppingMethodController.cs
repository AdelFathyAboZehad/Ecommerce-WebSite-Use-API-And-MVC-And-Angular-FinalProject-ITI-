using Application.Features.ShoppingMethods.Commands.CreateShoppingMethod;
using Application.Features.ShoppingMethods.Commands.DeleteShoppingMethod;
using Application.Features.ShoppingMethods.Queries.GetAllShoppingMethods;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingMethodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingMethodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetShiping")]
        public async Task<IActionResult> GetAll([FromQuery]GetAllShoppingMethodsQuery com) {
            
            return Ok(await _mediator.Send(com));
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateShopingMethod([FromBody]CreateShoppingMethodCommand com)
        //{
            
        //    return Ok(_mediator.Send(com));
        //}
        //[HttpDelete]
        //public async Task<IActionResult> DeleteShoppingMethod([FromBody] DeleteShoppingMethodCommand com)
        //{
        //    return Ok(_mediator.Send(com));
        //}
    }
}

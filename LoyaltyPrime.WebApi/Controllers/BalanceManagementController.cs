﻿using System.Threading.Tasks;
using LoyaltyPrime.Services.Contexts.BalanceManagementServices.Commands;
using LoyaltyPrime.WebApi.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoyaltyPrime.WebApi.Controllers
{
    [ApiController]
    [Route("api/balance-management")]
    public class BalanceManagementController : BaseController
    {
        public BalanceManagementController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost("collect-points")]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> CollectPoints([FromBody]CollectPointCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.StatusCode, result.Message);
        }

        [HttpPost("redeem-points")]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> RedeemPoints([FromBody]RedeemPointCommand command)
        {
            var result = await Mediator.Send(command);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
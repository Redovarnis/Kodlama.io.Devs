using Application.Features.Technologies.Commands.RemoveTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Queries.GetListTechnologyByDynamic;
using Application.Features.Technologies.Queries.GetListTechnology;
using Application.Features.Technologies.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Queries.GetByIdTechnology;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            TechnologyGetByIdDto technologyGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(technologyGetByIdDto);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
            [FromBody] Dynamic dynamic)
        {
            GetListTechnologyByDynamicQuery getListByDynamicTechnologyQuery = new GetListTechnologyByDynamicQuery()
                { PageRequest = pageRequest, Dynamic = dynamic };

            TechnologyListModel result = await Mediator.Send(getListByDynamicTechnologyQuery);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveTechnologyCommand removeTechnologyCommand)
        {
            RemovedTechnologyDto result = await Mediator.Send(removeTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }
    }
}
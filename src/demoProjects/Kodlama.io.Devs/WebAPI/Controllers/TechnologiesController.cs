using Application.Features.Models.Queries.GetListModelByDynamic;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery() { PageRequest = pageRequest };
            TechnologyListModel result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
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
    }
}
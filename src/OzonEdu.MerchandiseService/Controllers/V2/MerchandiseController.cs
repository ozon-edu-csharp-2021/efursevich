using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Models;

namespace OzonEdu.MerchandiseService.Controllers.V2
{
    [ApiController]
    [Route("v2/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<MerchandiseRequest>> GetException(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
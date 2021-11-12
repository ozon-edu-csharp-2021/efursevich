using System;
using Microsoft.AspNetCore.Mvc;

namespace OzonEdu.MerchandiseService.Controllers.V2
{
    [ApiController]
    [Route("v2/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        [HttpGet]
        public void GetException()
        {
            throw new NotImplementedException();
        }
    }
}
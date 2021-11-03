using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseRequestService _merchandiseRequestService;

        public MerchandiseController(IMerchandiseRequestService merchandiseRequestService)
        {
            _merchandiseRequestService = merchandiseRequestService;
        }
        
        [HttpGet("{id:long}")] 
        public async Task<ActionResult<MerchandiseRequestStatus>> GetInformationAboutMerchandiseRequest(long id, 
            CancellationToken token)
        {
            var merchandiseRequest = await _merchandiseRequestService.GetById(id, token);
            if (merchandiseRequest is null)
            {
                return NotFound();
            }

            var merchandiseRequestStatus = new MerchandiseRequestStatus(
                merchandiseRequest.FirstName, 
                merchandiseRequest.LastName, 
                merchandiseRequest.MerchPackageType, 
                merchandiseRequest.ClothingSize,
                merchandiseRequest.RequestStatus, 
                merchandiseRequest.CreatedAt, 
                merchandiseRequest.CompletedAt);
            return merchandiseRequestStatus;
        }

        [HttpPost]
        public async Task<ActionResult<MerchandiseRequest>> RequestMerchandise(
            MerchandiseRequestCreationModel creationModel, CancellationToken token)
        {
            var createdStockItem = await _merchandiseRequestService.Add(creationModel, token);
            return Ok(createdStockItem);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Mappings;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchRequestRepository _merchRequestRepository;

        public MerchandiseController(IMerchRequestRepository merchRequestRepository)
        {
            _merchRequestRepository = merchRequestRepository;
        }
        
        [HttpGet("{id:long}")] 
        public async Task<ActionResult<MerchRequestDTO>> GetInformationAboutMerchandiseRequest(long id, 
            CancellationToken token)
        {
            var merchRequest = await _merchRequestRepository.GetById(id, token);
            if (merchRequest is null)
            {
                return NotFound();
            }

            var merchRequestDTO = Mapper.MerchRequestToDTO(merchRequest);
            return Ok(merchRequestDTO);
        }

        [HttpPost]
        public async Task<ActionResult<MerchRequestDTO>> RequestMerchandise(MerchRequestCreationModelDTO creationModelDTO, 
            CancellationToken token)
        {
            var creationModel = Mapper.Map(creationModelDTO);
            if (creationModel.ClothingSize is null || creationModel.MerchType is null)
            {
                return BadRequest();
            }
            
            var createdMerchRequest = await _merchRequestRepository.Add(creationModel, token);
            var merchRequestDTO = Mapper.MerchRequestToDTO(createdMerchRequest);
            return Ok(merchRequestDTO);
        }
    }
}
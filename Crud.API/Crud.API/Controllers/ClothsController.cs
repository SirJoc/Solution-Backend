using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Crud.API.Domain.Models;
using Crud.API.Domain.Services;
using Crud.API.Extensions;
using Crud.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Crud.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class ClothsController : ControllerBase
    {
        private readonly IClothService _clothService;
        private readonly IMapper _mapper;

        public ClothsController(IClothService clothService, IMapper mapper)
        {
            _clothService = clothService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ClothResource>> GetAllAsync()
        {
            var cloths = await _clothService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Cloth>, IEnumerable<ClothResource>>(cloths);
            return resources;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveClothResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cloth = _mapper.Map<SaveClothResource, Cloth>(resource);
            var result = await _clothService.SaveAsync(cloth);

            if (!result.Success)
                return BadRequest(result.Message);

            var clothResource = _mapper.Map<Cloth, ClothResource>(result.Resource);

            return Ok(clothResource);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveClothResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var cloth = _mapper.Map<SaveClothResource, Cloth>(resource);
            var result = await _clothService.UpdateAsync(id, cloth);

            if (!result.Success)
                return BadRequest(result.Message);

            var clothResource = _mapper.Map<Cloth, ClothResource>(result.Resource);

            return Ok(clothResource);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clothService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var clothResource = _mapper.Map<Cloth, ClothResource>(result.Resource);

            return Ok(clothResource);
        }
        
    }
}
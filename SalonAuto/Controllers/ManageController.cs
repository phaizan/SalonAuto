using Logic.DtoModels.Filters;
using Microsoft.AspNetCore.Mvc;
using SalonAuto.Features.DtoModels.Center;
using SalonAuto.Features.Interfaces.Managers;

namespace AutoSalon.Controllers
{
    [Route("Manage")]
    public class ManageController : Controller
    {
        private readonly ICenterManager _centerManager;

        public ManageController(ICenterManager centerManager)
        {
            _centerManager = centerManager;
        }

        [HttpGet(nameof(Center), Name = nameof(Center))]
        public async Task<ActionResult> Center()
        {
            var center = _centerManager.GetListCenters(new CenterFilterDto()).FirstOrDefault();
            return View(center);
        }

        [HttpPost(nameof(CreateCenter), Name = nameof(CreateCenter))]
        public async Task<ActionResult> CreateCenter([FromBody] EditCenter center)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
             
            _centerManager.Create(center);
            return Ok();
        }
        
        [HttpPost(nameof(CreateCenterView), Name = nameof(CreateCenterView))]
        public async Task<ActionResult> CreateCenterView([FromBody] EditCenter center)
        {
            if (!ModelState.IsValid)
                return View(nameof(Center), center);
             
            _centerManager.Create(center);
            return View();
        }

        [HttpPut(nameof(UpdateCenter), Name = nameof(UpdateCenter))]
        public async Task<ActionResult> UpdateCenter([FromBody] EditCenter center)
        {
            _centerManager.Update(center);
            return Ok();
        }

        
        [HttpDelete(nameof(UpdateCenter), Name = nameof(UpdateCenter))]
        public async Task<ActionResult> DeleteCenter([FromBody] Guid isnNode)
        {
            _centerManager.Delete(isnNode);
            return Ok();
        }

        [HttpGet(nameof(GetListCenter), Name = nameof(GetListCenter))]
        public async Task<ActionResult> GetListCenter()
        {
            var centers = _centerManager.GetListCenters(new CenterFilterDto());
            return Ok(centers);
        }
    }
}

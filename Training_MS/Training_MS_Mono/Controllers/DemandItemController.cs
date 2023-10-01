using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Training_MS_Mono.Models;

namespace Training_MS_Mono.Controllers
{
    [ApiController]
    public class DemandItemController : ControllerBase
    {
        private readonly IAFLogisticsContext _context;

        public DemandItemController(IAFLogisticsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("demands")]
        public ActionResult<List<DemandItem>> Get()
        {
            return Ok(_context.DemandItems.ToList());
        }

        [HttpGet]
        [Route("demands/{id}")]
        public ActionResult<DemandItem> GetDemandItemById(int id)
        {
            return Ok(_context.DemandItems.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        [Route("demands")]
        public ActionResult InsertDemandItem(DemandItem item)
        {
            _context.DemandItems.Add(item);
            var result = _context.SaveChangesAsync();
            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            return Ok(result);
        }

        [HttpPut]
        [Route("demands")]
        public ActionResult UpdateDemandItem(DemandItem item)
        {
            _context.DemandItems.Update(item);
            var result = _context.SaveChangesAsync();
            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            return Ok(result);
        }

        [HttpDelete]
        [Route("demands")]
        public ActionResult DeleteDemandItem(int id)
        {
            var demandItem = _context.DemandItems.FirstOrDefault(s=>s.Id == id);
            _context.DemandItems.Remove(demandItem);
            var result = _context.SaveChangesAsync();
            return Ok("DemandItem has been deleted successfully..!!");
        }
    }
}

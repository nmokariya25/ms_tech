﻿using IAFLogistic_DemandManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IAFLogistic_DemandManagementService.Controllers
{
    [ApiController]
    public class DemandController : ControllerBase
    {
        private readonly DemandServiceDbContext _context;

        public DemandController(DemandServiceDbContext context)
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
        public ActionResult InsertDemandItem([FromBody] DemandItem item)
        {
            _context.DemandItems.Add(item);
            var result = _context.SaveChangesAsync();
            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            return Ok(result);
        }

        [HttpPut]
        [Route("demands")]
        public ActionResult UpdateDemandItem([FromBody] DemandItem item)
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
            var demandItem = _context.DemandItems.FirstOrDefault(s => s.Id == id);
            _context.DemandItems.Remove(demandItem);
            var result = _context.SaveChangesAsync();
            return Ok("DemandItem has been deleted successfully..!!");

        }

        [HttpPost]
        [Route("CreateDemand")]
        public async Task<IActionResult> CreateDemand([FromBody] DemandItem demand)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://localhost:5233/materials/{demand.ItemName}");
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return BadRequest("Material doesn't exist or is unavailable.");
                }
            }
            return Ok("Demand has been created successfully.");
        }
    }
}

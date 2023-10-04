using IAFLogistics_MaterialTransferService.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAFLogistics_MaterialTransferService.Controllers
{
    [ApiController]
    public class MaterialTransferController : ControllerBase
    {
        private readonly MaterialTransferDbContext _context;


        public MaterialTransferController(MaterialTransferDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("materials/{itemName}")]
        public async Task<IActionResult> GetMaterialUsingItemName(string itemName)
        {
            var material = _context.MaterialTransfers.FirstOrDefault(s => s.ItemName == itemName);
            if (material != null)
            {
                return Ok(material);
            }
            return BadRequest($"Material doesn't found with ItemName: {itemName}");
        }


        [HttpGet]
        [Route("materials")]
        public ActionResult<List<MaterialTransfer>> Get()
        {
            return Ok(_context.MaterialTransfers.ToList());
        }

        [HttpPost]
        [Route("materials")]
        public ActionResult InsertTransferRequest(MaterialTransfer item)
        {
            _context.MaterialTransfers.Add(item);
            var result = _context.SaveChangesAsync();
            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            return Ok(result);
        }

        [HttpPut]
        [Route("materials")]
        public ActionResult UpdateTransferRequest(MaterialTransfer item)
        {
            _context.MaterialTransfers.Update(item);
            var result = _context.SaveChangesAsync();
            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            return Ok(result);
        }

        [HttpDelete]
        [Route("materials")]
        public ActionResult DeleteTransferRequest(int id)
        {
            var transferRequest = _context.MaterialTransfers.FirstOrDefault(s => s.Id == id);
            _context.MaterialTransfers.Remove(transferRequest);
            _context.SaveChangesAsync();
            return Ok("TransferRequest has been deleted successfully..!!");
        }
    }
}

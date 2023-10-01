using Microsoft.AspNetCore.Mvc;
using Training_MS_Mono.Models;

namespace Training_MS_Mono.Controllers
{
    [ApiController]
    public class TransferRequestController : ControllerBase
    {
        private readonly IAFLogisticsContext _context;

        public TransferRequestController(IAFLogisticsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("transfers")]
        public ActionResult<List<TransferRequest>> Get()
        {
            return Ok(_context.TransferRequests.ToList());
        }

        [HttpGet]
        [Route("transfers/{id}")]
        public ActionResult<TransferRequest> GetTransferRequestById(int id)
        {
            return Ok(_context.TransferRequests.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        [Route("transfers")]
        public ActionResult InsertTransferRequest(TransferRequest item)
        {
            _context.TransferRequests.Add(item);
            var result = _context.SaveChangesAsync();
            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            return Ok(result);
        }

        [HttpPut]
        [Route("transfers")]
        public ActionResult UpdateTransferRequest(TransferRequest item)
        {
            _context.TransferRequests.Update(item);
            var result = _context.SaveChangesAsync();
            if (result.Id == 0)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");

            return Ok(result);
        }

        [HttpDelete]
        [Route("transfers")]
        public ActionResult DeleteTransferRequest(int id)
        {
            var transferRequest = _context.TransferRequests.FirstOrDefault(s => s.Id == id);
            _context.TransferRequests.Remove(transferRequest);
            _context.SaveChangesAsync();
            return Ok("TransferRequest has been deleted successfully..!!");
        }
    }
}

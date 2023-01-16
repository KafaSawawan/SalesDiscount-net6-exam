using Microsoft.AspNetCore.Mvc;
using SalesAPI.Interfaces;
using SalesAPI.Models;

namespace SalesAPI.Controllers
{
    public enum ErrorCode
    {
        SalesDiscountsRequired,
        SalesDiscountsIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }
    [ApiController]
    [Route("api/[controller]")]
    public class SalesDiscountController : Controller
    {
        private readonly ISalesDiscountRepository _discountRepository;

        public SalesDiscountController(ISalesDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_discountRepository.All);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var item = _discountRepository.Find(id);
                if (item == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _discountRepository.Delete(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
            }
            return NoContent();
        }
    }
}


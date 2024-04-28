using GeekShopping.CartAPI.Data.DTOs;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<IActionResult> FindById(string userId)
        {
            var cart = await _cartRepository.FindCartByUserId(userId);
            if (cart == null) return NotFound();
            return Ok(cart);

        }

        [HttpPost("add-cart/{id}")]
        public async Task<IActionResult> AddCart(CartDTO cartDto)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(cartDto);
            if (cart == null) return NotFound();
            return Ok(cart);

        }


        [HttpPut("update-cart/{id}")]
        public async Task<IActionResult> UpdateCart(CartDTO cartDto)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(cartDto);
            if (cart == null) return NotFound();
            return Ok(cart);

        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);

        }
    }
}

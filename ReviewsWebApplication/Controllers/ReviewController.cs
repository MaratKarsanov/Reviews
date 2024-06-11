using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Review.Domain.Models;
using Review.Domain.Services;

namespace ReviewsWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            this.reviewService = reviewService;
        }

        /// <summary>
        /// Добавление отзыва
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] AddReview addReview)
        {
            try
            {
                var result = await reviewService.TryToAddReviewAsync(addReview);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Получение всех отзывов по продукту
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetReviewsByProductId")]
        public async Task<ActionResult<List<Review.Domain.Models.Review>>> GetReviewsByProductIdAsync(Guid productId)
        {
            try
            {
                var result = await reviewService.GetReviewsByProductIdAsync(productId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Получение отзыва
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetReview")]
        public async Task<ActionResult<List<Review.Domain.Models.Review>>> GetReviewAsync(Guid reviewId)
        {
            try
            {
                var result = await reviewService.GetReviewsAsync(reviewId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Удаление отзыва по id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("DeleteReview")]
        public async Task<ActionResult<List<Review.Domain.Models.Review>>> DeleteReviewAsync(Guid reviewId)
        {
            try
            {
                var result = await reviewService.TryToDeleteReviewAsync(reviewId);
                if (result)
                    return Ok();
                return BadRequest(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
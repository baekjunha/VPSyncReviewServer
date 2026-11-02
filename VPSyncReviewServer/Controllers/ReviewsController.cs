
using Microsoft.AspNetCore.Mvc;
using VPSyncReviewServer.Data;
using VPSyncReviewServer.Models;

namespace VPSyncReviewServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // 생성자: DB 접근 객체를 전달받는다.
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. 전체 Review 조회 (GET)
        [HttpGet]
        public List<Review> GetReviews()
        {
            List<Review> results = _context.Reviews
                .OrderByDescending(item => item.CreatedAt)
                .ToList();

            return results;
        }

        // 2. 특정 ID의 Review 조회 (GET)
        [HttpGet("{id:int}")]
        public ActionResult<Review> GetReview(int id)
        {
            Review? review = _context.Reviews
                .FirstOrDefault(item => item.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // 3. 새로운 Review 저장 (POST)
        [HttpPost]
        public bool AddReview([FromBody] Review review)
        {
            // Id는 SQL Server가 자동으로 생성한다.
            review.Id = 0;

            // 저장 시각은 서버에서 지정한다.
            review.CreatedAt = DateTime.UtcNow;

            _context.Reviews.Add(review);

            if (_context.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        // 4. 기존 Review 수정 (PUT)
        [HttpPut]
        public bool UpdateReview([FromBody] Review review)
        {
            Review? findReview = _context.Reviews
                .Where(item => item.Id == review.Id)
                .FirstOrDefault();

            if (findReview == null)
                return false;

            findReview.ShotName = review.ShotName;
            findReview.DrawingData = review.DrawingData;

            _context.SaveChanges();

            return true;
        }

        // 5. 기존 Review 삭제 (DELETE)
        [HttpDelete("{id}")]
        public bool DeleteReview(int id)
        {
            Review? findReview = _context.Reviews
                .Where(item => item.Id == id)
                .FirstOrDefault();

            if (findReview == null)
                return false;

            _context.Reviews.Remove(findReview);

            _context.SaveChanges();

            return true;
        }
    }
}

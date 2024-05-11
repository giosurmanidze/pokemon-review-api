using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pokemon_review_api.Dto;
using pokemon_review_api.Entities;
using pokemon_review_api.Interfaces;

namespace pokemon_review_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewerController : ControllerBase
    { 
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Reviewer>))]
        public ActionResult GetAllReviewers()
        {
            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewers());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewers);
        }
        
        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if(_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            
            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));
 
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("reviews/{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        { 
            var reviews = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GetReviewsByReviewer(reviewerId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

    }
}
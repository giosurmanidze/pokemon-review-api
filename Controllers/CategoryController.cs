using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pokemon_review_api.Dto;
using pokemon_review_api.Entities;
using pokemon_review_api.Interfaces;

namespace pokemon_review_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if(!_categoryRepository.CategoryExists(categoryId))
                return NotFound();
            
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));
 
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetPokemonById(int categoryId)
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryId));

            if(!ModelState.IsValid)
                return BadRequest();

            return Ok(pokemons);
        }

    }
}
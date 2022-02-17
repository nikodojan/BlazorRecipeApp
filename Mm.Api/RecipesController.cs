using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorRecipeApp.Mm.Recipes.Models;
using BlazorRecipeApp.Mm.Shared.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorRecipeApp.Mm.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _service;

        private readonly IMemoryCache _memoryCache;
        private readonly string _recipesGetAllKey = "RecipesGetAllKey";

        public RecipesController(IRecipeService service, IMemoryCache cache)
        {
            _service = service;
            _memoryCache = cache;

        }

        [HttpGet]
        [EnableCors("All")]
        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAll()
        {
            IEnumerable<Recipe> recipes = null;

            if (_memoryCache.TryGetValue(_recipesGetAllKey, out recipes))
            {
                return Ok(recipes);
            }

            recipes = await _service.GetAllRecipesAsync();

            var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
            _memoryCache.Set(_recipesGetAllKey, recipes, cacheOptions);

            return Ok(recipes);
        }

        [HttpGet("titles")]
        [EnableCors("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<string>>> GetRecipeTitles()
        {
            return Ok(await _service.GetAllTitlesAsync());
        }

        [HttpGet("shortinfo")]
        [EnableCors("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<object>>> GetRecipeQuickInfo()
        {
            return Ok(await _service.GetAllShortAsync());
        }

        [HttpGet("{id}")]
        [EnableCors("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Recipe>> GetById(int id)
        {
            var recipe = await _service.GetRecipeByIdAsync(id);
            if (recipe.Id == 0) return NotFound($"Couldn't find recipe with id {id}");
            return Ok(recipe);
        }

        [HttpGet("title/{title}")]
        [EnableCors("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetById(string title)
        {
            return Ok(await _service.GetByTitleAsync(title));
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Recipe>> Post([FromBody] Recipe recipe)
        {
            var result = _service.AddRecipeAsync(recipe);
            if (result is null) return Conflict("An error occurred. Recipe couldn't be added.");
            var url = Request.Path;
            return Created(url + result.Id.ToString(), result);
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

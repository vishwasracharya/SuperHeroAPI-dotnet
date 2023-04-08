using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService) 
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var results = _superHeroService.GetAllHeroes();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var results = _superHeroService.GetSingleHero(id);
            if (results is null)
            {
                return NotFound("Sorry, but this hero doesn't Exists");
            }
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var results = _superHeroService.AddHero(hero);
            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var results = _superHeroService.UpdateHero(id, request);
            if (results == null)
            {
                return NotFound("Sorry, but this hero doesn't Exists");
            }

            return Ok(results);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var results = _superHeroService.DeleteHero(id);
            if (results is null)
            {
                return NotFound("Hero Not Found");
            }
            return Ok(results);
        }
    }
}

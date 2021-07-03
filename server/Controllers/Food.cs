using System;
using System.Collections.Generic;
using System.Linq;
using database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace server.Controllers
{
    [Route("API/Food")]
    [ApiController]
    public class Food : ControllerBase
    {
        private readonly mainContext _context;
        private readonly IConfiguration _configuration;
        public Food(mainContext context,IConfiguration configuration)
        {
            this._configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _context.Recipes.Select(p => p).Include(p=>p.IngredientIndices).ThenInclude(p=>p.IdIngredientNavigation).ThenInclude(p=>p.IdCategoryNavigation).Include(p=>p.IngredientIndices).ThenInclude(p=>p.IdRefNavigation).Include(p=>p.RecipePictureIndices).ThenInclude(p=>p.IdPictureNavigation).Include(p=>p.RecipeTagIndices).ThenInclude(p=>p.IdTagNavigation).Include(p=>p.RecipeUserIndices).ThenInclude(p=>p.IdUserNavigation).Select(p=>p).AsSplitQuery();
        }
        [HttpGet]
        [Route("{id:int}")]
        public Recipe GetSingle(int id)
        {
            var fullEnum = Get();
            try
            {
                return fullEnum.Single(p => p.IdRecipe == id);
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace recipes.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/")]
    [Controller]
    public class FoodController : Controller
    {
        private mainContext Context { get; }
        public FoodController(IConfiguration configuration,mainContext _context)
        {
            Context = _context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(Get());
        }

        [Route("Expanded/{id:int}")]
        public IActionResult Expanded(int id)
        {
            return View(GetSingle(id));
        }

        public IEnumerable<Recipe> Get()
        {
            return Context.Recipes.Select(p => p).Include(p=>p.IngredientIndices).ThenInclude(p=>p.IdIngredientNavigation).ThenInclude(p=>p.IdCategoryNavigation).Include(p=>p.IngredientIndices).ThenInclude(p=>p.IdRefNavigation).Include(p=>p.RecipePictureIndices).ThenInclude(p=>p.IdPictureNavigation).Include(p=>p.RecipeTagIndices).ThenInclude(p=>p.IdTagNavigation).Include(p=>p.RecipeUserIndices).ThenInclude(p=>p.IdUserNavigation).Select(p=>p).AsSplitQuery();
        }
        public Recipe GetSingle(int id)
        {
            var enumerable = Get();
            return enumerable.Single(p => p.IdRecipe == id);
        }
    }
}
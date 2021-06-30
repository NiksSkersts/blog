using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.Models;

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
            return _context.Recipes.Include(p => p.UserIndices).ThenInclude(p => p.IdUserNavigation)
                .Include(p => p.TagIndices).ThenInclude(p => p.IdTagNavigation).Include(p => p.IngredientIndices)
                .ThenInclude(p => p.IdIngredientNavigation).Select(p => p);
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
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using server.Models;

namespace recipes.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/")]
    [Controller]
    public class FoodController : Controller
    {
        private readonly IConfiguration _configuration;
        public FoodController(IConfiguration configuration)
        {
            _configuration = configuration;
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
            var client = new RestClient(_configuration["api_list_food"]) {Timeout = -1};
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<IEnumerable<Recipe>>(response.Content);
        }
        //I could have just created an IEnum<Recipe> [var] and just assigned Get() to it and gotten my result by using .Single().
        //Was a sin to waste perfectly good lines of code I added in server, so I am consuming another API.
        // todo - check out local IEnum solution.
        public Recipe GetSingle(int id)
        {
            var client = new RestClient(_configuration["api_list_food"] + "/" + id) {Timeout = -1};
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Recipe>(response.Content);
        }
    }
}
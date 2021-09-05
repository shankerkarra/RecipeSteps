using System;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeSteps.Models;
using RecipeSteps.Services;
using Microsoft.AspNetCore.Authorization;

namespace RecipeSteps.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipeService _recipeService;

    public RecipesController(RecipeService recipeservice)
    {
      _recipeService = recipeservice;
    }

    [HttpGet]
    public ActionResult<List<recipe>> Get()
    {
      try
      {
        List<recipe> recp = _recipeService.Get();
        return Ok(recp);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<recipe> Get(int id)
    {
      try
      {
        recipe rcp = _recipeService.Get(id);
        return Ok(rcp);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<recipe>> Create([FromBody] recipe newrecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newrecipe.creatorId = userInfo.Id;
        recipe rcp = _recipeService.Create(newrecipe);
        return Ok(rcp);
      }
      catch (Exception err)
      {

        return BadRequest(err.Message);
      }
    }

  }
}

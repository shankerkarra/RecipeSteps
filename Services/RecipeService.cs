using System;
using System.Collections.Generic;
using RecipeSteps.Models;
using RecipeSteps.Repositories;

namespace RecipeSteps.Services
{
  public class RecipeService
  {
    private readonly RecipesRepository _recprepo;

    public RecipeService(RecipesRepository recprepo)
    {
      _recprepo = recprepo;
    }
    internal List<recipe> GetList()
    {
      return _recprepo.Get();
    }

    internal recipe Get(int id)
    {
      recipe rcp = _recprepo.Get(id);
      if (rcp == null)
      {
        throw new Exception("Invalid id");
      }
      return rcp;
    }
    internal recipe Create(recipe newrecipe)
    {
      return _recprepo.Create(newrecipe);
    }

    internal List<recipe> Get()
    {
      return _recprepo.Get();
      throw new NotImplementedException();
    }

    internal void Delete(int recipeId, string userId)
    {
      recipe recipeToDelete = Get(recipeId);
      if (recipeToDelete.creatorId != userId)
      {
        throw new Exception("You do not have permission to delete");
      }
      _recprepo.Delete(recipeId);
    }
  }
}
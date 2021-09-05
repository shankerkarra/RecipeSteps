using System;
using System.Data;
using System.Linq;
using Dapper;
using System.Collections.Generic;
using RecipeSteps.Models;


namespace RecipeSteps.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<recipe> Get()
    {
      string sql = @"
      SELECT 
        a.*,
        r.*
      FROM recipe r
      JOIN accounts a ON r.creatorId = a.id
      ";
      // data type 1, data type 2, return type
      return _db.Query<Account, recipe, recipe>(sql, (account, recipe) =>
      {
        recipe.creatorId = account.Id;
        return recipe;
      }, splitOn: "id").ToList();
    }

    internal recipe Create(recipe newrecipe)
    {
      throw new NotImplementedException();
    }

    internal void Delete(object recipeId)
    {
      throw new NotImplementedException();
    }

    internal recipe Get(int id)
    {
      throw new NotImplementedException();
    }
  }
}
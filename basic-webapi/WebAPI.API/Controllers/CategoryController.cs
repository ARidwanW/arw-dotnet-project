using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Persistence;

namespace WebAPI.API.Controllers;

public class CategoryController : BaseApiController
{
    private readonly MyDatabase _myDatabase;
    public CategoryController(MyDatabase myDatabase)
    {
        _myDatabase = myDatabase;
    }
    #region Action
    public async Task<IActionResult> GetCategories()
    {
        var category = await _myDatabase.Categories.ToListAsync();
        if(category is null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    #endregion
}

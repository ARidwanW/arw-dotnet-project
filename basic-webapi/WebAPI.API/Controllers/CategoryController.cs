using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain;
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
    [HttpGet]   //* api/category
    public async Task<IActionResult> GetCategories()
    {
        var category = await _myDatabase.Categories.ToListAsync();
        if(category is null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    [HttpGet("{id}")]   //* api/category/{id}
    public async Task<IActionResult> GetCategory([FromRoute]Guid id)
    {
        Category? category = await _myDatabase.Categories.FindAsync(id);
        if(category is null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody]Category category)
    {
        _myDatabase.Categories.Add(category);
        await _myDatabase.SaveChangesAsync();
        return Ok(category);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody]Category category)
    {
        _myDatabase.Categories.Update(category);
        await _myDatabase.SaveChangesAsync();
        return Ok(category);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory([FromRoute]Guid id)
    {
        Category? category = await _myDatabase.Categories.FindAsync(id);
        if(category is null)
        {
            return NotFound();
        }
        _myDatabase.Categories.Remove(category);
        await _myDatabase.SaveChangesAsync();
        return Ok(category);
    }
    #endregion
}

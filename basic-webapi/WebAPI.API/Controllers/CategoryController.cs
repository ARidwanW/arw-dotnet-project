using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Domain;
using WebAPI.Domain.DTOs.Request;
using WebAPI.Domain.DTOs.Response;
using WebAPI.Persistence;

namespace WebAPI.API.Controllers;

public class CategoryController : BaseApiController
{
    private readonly MyDatabase _myDatabase;
    private readonly IMapper _map;
    public CategoryController(MyDatabase myDatabase, IMapper mapper)
    {
        _myDatabase = myDatabase;
        _map = mapper;
    }
    #region Action
    [HttpGet]   //* api/category
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _myDatabase.Categories.ToListAsync();
        if(categories is null)
        {
            return NotFound();
        }
        List<CategoryResponse> response = _map.Map<List<CategoryResponse>>(categories);
        return Ok(response);
    }
    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]   //* api/category/{id}
    public async Task<IActionResult> GetCategory([FromRoute]Guid id)
    {
        Category? category = await _myDatabase.Categories.FindAsync(id);
        if(category is null)
        {
            return NotFound();
        }
        CategoryResponse response = _map.Map<CategoryResponse>(category);
        return Ok(response);
    }
    // [HttpPost]
    // public async Task<IActionResult> CreateCategory([FromBody]Category category)
    // {
    //     _myDatabase.Categories.Add(category);
    //     await _myDatabase.SaveChangesAsync();
    //     return Ok(category);
    // }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody]CategoryRequest request)
    {
        Category category = _map.Map<Category>(request);
        _myDatabase.Categories.Add(category);
        await _myDatabase.SaveChangesAsync();
        return Ok(category);
    }
    // [HttpPut]
    // public async Task<IActionResult> UpdateCategory([FromBody]Category category)
    // {
    //     _myDatabase.Categories.Update(category);
    //     await _myDatabase.SaveChangesAsync();
    //     return Ok(category);
    // }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute]Guid id, [FromBody]CategoryRequest request)
    {
        Category? category = await _myDatabase.Categories.FindAsync(id);
        if(category is null)
        {
            return NotFound();
        }
        category.CategoryName = request.CategoryName;
        category.Description = request.Description;
        CategoryResponse response = _map.Map<CategoryResponse>(category);
        _myDatabase.Categories.Update(category);
        await _myDatabase.SaveChangesAsync();
        return Ok(response);
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

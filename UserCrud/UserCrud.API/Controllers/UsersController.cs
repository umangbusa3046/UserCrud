using Microsoft.AspNetCore.Mvc;
using UserCrud.Application.DTOs.User;
using UserCrud.Application.Interfaces;

namespace UserCrud.API.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(
        IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result =
            await _service.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id)
    {
        var result =
            await _service.GetByIdAsync(id);

        if (!result.IsSuccess)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateUserRequest request)
    {
        var result =
            await _service.CreateAsync(request);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Data },
            result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateUserRequest request)
    {
        var result =
            await _service.UpdateAsync(
                id,
                request);

        if (!result.IsSuccess)
        {
            return NotFound(result);
        }

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        var result =
            await _service.DeleteAsync(id);

        if (!result.IsSuccess)
        {
            return NotFound(result);
        }

        return Ok(result);
    }
}
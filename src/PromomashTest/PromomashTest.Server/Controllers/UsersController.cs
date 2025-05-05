using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PromomashTest.Server.Domain.Models;
using PromomashTest.Server.Domain.Services;

namespace PromomashTest.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly ILocationService _locationService;
    private readonly IValidator<CreateUserRequest> _validator;

    public UsersController(IUsersService usersService,
        IValidator<CreateUserRequest> validator,
        ILocationService locationService)
    {
        _usersService = usersService;
        _validator = validator;
        _locationService = locationService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync([FromBody] CreateUserRequest user)
    {
        var validationResult = _validator.Validate(user);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var existingUser = await _usersService.GetUserByEmailAsync(user.Email, CancellationToken.None);
        if (existingUser != null)
        {
            return BadRequest("User with this email already exists.");
        }
        var country = await _locationService.GetCountryByIdAsync(user.CountryId, CancellationToken.None);
        if (country is null)
        {
            return BadRequest("Country not found.");
        }
        if (!country.Provinces.Any(p => p.Id == user.ProvinceId))
        {
            return BadRequest("Province not found in this country.");
        }

        await _usersService.AddUserAsync(user);
        return Ok();
    }
}

using Microsoft.Extensions.Logging;
using UserCrud.Application.Common;
using UserCrud.Application.DTOs.User;
using UserCrud.Application.Interfaces;
using UserCrud.Domain.Entities;
using UserCrud.Domain.Interfaces;

namespace UserCrud.Application.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ILogger<UserService> _logger;

    public UserService(
        IUserRepository repository,
        ILogger<UserService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Result<Guid>> CreateAsync(
        CreateUserRequest request)
    {
        _logger.LogInformation(
            "Creating user with email {Email}",
            request.Email);

        if (await _repository.ExistsByEmailAsync(
            request.Email))
        {
            _logger.LogWarning(
                "Email already exists {Email}",
                request.Email);

            return Result<Guid>.Failure(
                "Email already exists.");
        }

        User user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            CreatedOn = DateTime.UtcNow
        };

        await _repository.AddAsync(user);

        await _repository.SaveChangesAsync();

        _logger.LogInformation(
            "User created successfully. Id: {Id}",
            user.Id);

        return Result<Guid>.Success(
            user.Id,
            "User created successfully.");
    }

    public async Task<Result<UserResponse>> GetByIdAsync(
        Guid id)
    {
        var user =
            await _repository.GetByIdAsync(id);

        if (user is null)
        {
            _logger.LogWarning(
                "User not found. Id: {Id}",
                id);

            return Result<UserResponse>.Failure(
                "User not found.");
        }

        return Result<UserResponse>.Success(
            Map(user),
            "User retrieved successfully.");
    }

    public async Task<Result<List<UserResponse>>> GetAllAsync()
    {
        var users =
            await _repository.GetAllAsync();

        return Result<List<UserResponse>>
            .Success(
                users.Select(Map).ToList(),
                "Users retrieved successfully.");
    }

    public async Task<Result<bool>> UpdateAsync(
        Guid id,
        UpdateUserRequest request)
    {
        var user =
            await _repository.GetByIdAsync(id);

        if (user is null)
        {
            return Result<bool>.Failure(
                "User not found.");
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        _repository.Update(user);

        await _repository.SaveChangesAsync();

        _logger.LogInformation(
            "User updated successfully. Id: {Id}",
            id);

        return Result<bool>.Success(
            true,
            "User updated successfully.");
    }

    public async Task<Result<bool>> DeleteAsync(
        Guid id)
    {
        var user =
            await _repository.GetByIdAsync(id);

        if (user is null)
        {
            return Result<bool>.Failure(
                "User not found.");
        }

        _repository.Delete(user);

        await _repository.SaveChangesAsync();

        _logger.LogInformation(
            "User deleted successfully. Id: {Id}",
            id);

        return Result<bool>.Success(
            true,
            "User deleted successfully.");
    }

    private static UserResponse Map(
        User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }
}
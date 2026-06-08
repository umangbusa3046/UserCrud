using UserCrud.Application.Common;
using UserCrud.Application.DTOs.User;

namespace UserCrud.Application.Interfaces;

public interface IUserService
{
    Task<Result<Guid>> CreateAsync(
        CreateUserRequest request);

    Task<Result<UserResponse>> GetByIdAsync(
        Guid id);

    Task<Result<List<UserResponse>>> GetAllAsync();

    Task<Result<bool>> UpdateAsync(
        Guid id,
        UpdateUserRequest request);

    Task<Result<bool>> DeleteAsync(
        Guid id);
}
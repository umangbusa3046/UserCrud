using UserCrud.Domain.Entities;

namespace UserCrud.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);

    Task<List<User>> GetAllAsync();

    Task<bool> ExistsByEmailAsync(string email);

    Task AddAsync(User user);

    void Update(User user);

    void Delete(User user);

    Task SaveChangesAsync();
}
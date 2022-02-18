using DataAccess.Data.Entities;

namespace Backend.Repository.Interfaces
{
    public interface IUsersRepository
    {
        Task<int> Create(string firstName, string lastName, int age);
        Task<bool> Update(int id, string firstName, string lastName, int age);
        Task<bool> Delete(int id);
        Task<IEnumerable<User>> Read();
    }
}

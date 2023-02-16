using System.Threading.Tasks;

namespace MvcStartAppMy.Models.Db
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task <User []> GetUsers();
    }
}

using System.Threading.Tasks;

namespace MvcStartAppMy.Models.Db
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request []> GetRequests();
    }
}

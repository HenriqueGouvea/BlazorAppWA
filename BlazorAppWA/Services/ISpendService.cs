using BlazorAppWA.Models;

namespace BlazorAppWA.Services
{
    public interface ISpendService
    {
        Task SaveSpends(List<Spend> spends);
        Task<List<Spend>> GetSpends();
    }
}

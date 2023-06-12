using BlazorAppWA.Models;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BlazorAppWA.Services
{
    public class SpendService : ISpendService
    {
        private readonly ILocalStorageService _localStorageService;

        public SpendService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        private string SpendsLocalStorageKey => "spendKey";

        public async Task<List<Spend>> GetSpends()
        {
            var spendJson = await _localStorageService.GetItemAsync<string>(SpendsLocalStorageKey);

            if (string.IsNullOrEmpty(spendJson))
                return new();

            return JsonSerializer.Deserialize<List<Spend>>(spendJson);
        }

        public async Task SaveSpends(List<Spend> spends)
        {
            var spendsJson = JsonSerializer.Serialize(spends);

            await _localStorageService.SetItemAsync(SpendsLocalStorageKey, spendsJson);
        }
    }
}

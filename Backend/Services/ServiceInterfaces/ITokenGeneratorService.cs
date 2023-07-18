using Backend.Models;

namespace Backend.Services.ServiceInterfaces
{
    public interface ITokenGeneratorService
    {
        public Task<string> GenerateTokenAsync(User user);
    }
}

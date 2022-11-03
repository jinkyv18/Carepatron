using api.Models.DTO;

namespace api.Service.Contract
{
    public interface IClientService
    {
        Task<List<ClientDTO>> GetClient();

        Task<string> CreateClient(ClientCreateRequest client);

        Task<string> UpdateClient(ClientDTO client);

        Task<List<ClientDTO>> SearchClient(string searchKey);
    }
}

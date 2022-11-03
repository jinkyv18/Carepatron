using api.Models.SqlModel;

namespace api.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAll();
        Task<bool> Create(Client client);
        Task<bool> Update(Client client);
        Task<List<Client>> Search(string searchKey);
    }
}

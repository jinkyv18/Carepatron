using api.Service.Contract;
using api.Repositories;
using api.Models.DTO;
using AutoMapper;
using api.Models.SqlModel;

namespace api.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Get all the clients from database. This expose the custom model and not the entity.
        /// </summary>
        /// <returns>List of all clientsin the database.</returns>
        public async Task<List<ClientDTO>> GetClient()
        {
            var clients = await _clientRepository.GetAll();            
            return _mapper.Map<List<ClientDTO>>(clients);
        }

        /// <summary>
        /// Creating new client in the database.
        /// </summary>
        /// <returns>Return a string message if success or failed.</returns>
        public async Task<string> CreateClient(ClientCreateRequest client)
        {
            var entity = _mapper.Map<Client>(client);
            var result = await _clientRepository.Create(entity);

            return result ? "Successfully created new client." : "Failed to create new client. Pleasetry again.";
        }

        /// <summary>
        /// Update client by ID in the database.
        /// </summary>
        /// <returns>Return a string message if changes made is success or failed.</returns>
        public async Task<string> UpdateClient(ClientDTO client)
        {
            var entity = _mapper.Map<Client>(client);
            var result = await _clientRepository.Update(entity);

            return result ? "Successfully updated client." : "Failed to update client. Client cannot be found.";
        }

        /// <summary>
        /// Search for clients that contains the searched key for first name and last name in Clients table.
        /// </summary>
        /// <param name="searchKey">String to be searched.</param>
        /// <returns>The list of all clients filtered by search key.</returns>
        public async Task<List<ClientDTO>> SearchClient(string searchKey)
        {
            var clients = await _clientRepository.Search(searchKey);
            return _mapper.Map<List<ClientDTO>>(clients);

        }
    }
}

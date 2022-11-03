using api.Service.Contract;
using api.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using api.Models.SqlModel;

namespace api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ClientDTO>> GetClient()
        {
            try
            {
                return await _service.GetClient();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<string> CreateClient(ClientCreateRequest client)
        {
            try
            {
                return await _service.CreateClient(client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        [HttpPut]
        public async Task<string> UpdateClient(ClientDTO client)
        {
            try
            {
                return await _service.UpdateClient(client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        [HttpGet("searchClient")]
        public async Task<List<ClientDTO>> SearchClient(string searchKey)
        {
            try
            {
                return await _service.SearchClient(searchKey);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}

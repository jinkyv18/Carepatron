using api.Models.DTO;
using api.Models.SqlModel;
using AutoMapper;

public class CommonMappingProfile : Profile
{
    /// <summary>
    /// Mapping configuration used by the system.
    /// </summary>
    public CommonMappingProfile()
    {
        CreateMap<Client, ClientDTO>();
        CreateMap<ClientDTO, Client>();
        CreateMap<ClientCreateRequest, Client>();
    }
}
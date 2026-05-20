using RESTWebApiCodeFirst.DTOs;

namespace RESTWebApiCodeFirst.Services;

public interface IDbService
{
    Task<IEnumerable<GetPCsDTO>> GetAllPCs();
    Task DeletePC(int id);
    Task UpdatePCsAsync(int id, UpdatePCsDTO userDto);
    Task<GetPCsDTO> AddPCAsync(AddPCsDTO userDto);

}
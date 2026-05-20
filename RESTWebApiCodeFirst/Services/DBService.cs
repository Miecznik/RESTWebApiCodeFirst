using RESTWebApiCodeFirst.Data;
using RESTWebApiCodeFirst.DTOs;
using Microsoft.EntityFrameworkCore;
using RESTWebApiCodeFirst.Entities;
using RESTWebApiCodeFirst.Exception;

namespace RESTWebApiCodeFirst.Services;

public class DBService : IDbService
{
    
    private readonly AppDBContext _context;
    
    public DBService(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetPCsDTO>> GetAllPCs()
    {

        var pCs = await _context.PCs.Select(
            e => new GetPCsDTO()
            {
                Id = e.Id,
                Name = e.Name,
                Stock = e.Stock,
                Warranty = e.Warranty,
                CreatedAt = e.CreatedAt,
                Weight = e.Weight
                
            }).ToListAsync();

        return pCs;
    }

    public async Task DeletePC(int pCId)
    {
       var pc = await _context.PCs.FirstOrDefaultAsync(e => e.Id == pCId);
       if (pc == null)
       {
           throw new NotFoundException();
       }
       _context.PCs.Remove(pc);
       await _context.SaveChangesAsync();
    }

    public async Task UpdatePCsAsync(int id, UpdatePCsDTO pCsDto)
    {
        var pCs = await _context.PCs.FirstOrDefaultAsync(e => e.Id == id);
        if (pCs == null)
        {
            throw new NotFoundException();
        }
        
        pCs.Name = pCsDto.Name;
        pCs.Weight = pCsDto.Weight;
        pCs.Warranty = pCsDto.Warranty;
        pCs.CreatedAt = pCsDto.CreatedAt;
        pCs.Stock = pCsDto.Stock;

        await _context.SaveChangesAsync();
    }

    public async Task<GetPCsDTO> AddPCAsync(AddPCsDTO pCDto)
    {

        var pc = new PCs()
        {
            Name = pCDto.Name,
            Weight = pCDto.Weight,
            Warranty = pCDto.Warranty,
            CreatedAt = pCDto.CreatedAt,
            Stock = pCDto.Stock
        };

        await _context.PCs.AddAsync(pc);
        await _context.SaveChangesAsync();

        return new GetPCsDTO
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }
}

    
